using eDostava_API.Models;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.KorisniciForms
{
    public partial class Zaposlenici : Form
    {
        private WebApiHelper servisKorisnici = new WebApiHelper("korisnici");
        private WebApiHelper servis = new WebApiHelper(); // create just the base api, because we'll handle /korisnici, /restorani, /zaposlenici and /vlasnici

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();
        private Stack<bool> loaderImgStackDetaljno = new Stack<bool>();

        // Zaposlenici grid source
        private BindingList<Korisnici_Result> zaposleniciBindingList, originalZaposleniciBindingList;
        private BindingSource zaposleniciBindingSource = new BindingSource();


        // Zaposlenik detaljno sources
        Korisnici_Result detaljnoZaposlenik;
        List<Restorani_Result> listRestoraniFromApi = new List<Restorani_Result>();

        BindingList<Restorani_Result> restoraniZaposlenikaList = new BindingList<Restorani_Result>();
        BindingSource restoraniZaposlenikaSource = new BindingSource();

        public Zaposlenici()
        {
            InitializeComponent();
            dgvZaposlenici.AutoGenerateColumns = false;
        }

        private void ZaposleniciList_Load(object sender, EventArgs e)
        {
            BindMainGrid();
            BindRestoraniCmb();
        }

        private async void BindRestoraniCmb()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servis.GetResponse("restorani");
            if (response.IsSuccessStatusCode)
            {
                listRestoraniFromApi = response.Content.ReadAsAsync<List<Restorani_Result>>().Result;

                cmbDetaljnoRestorani.DataSource = new List<Restorani_Result>(listRestoraniFromApi);
                cmbDetaljnoRestorani.ValueMember = "RestoranID";
                cmbDetaljnoRestorani.DisplayMember = "Naziv";

                listRestoraniFromApi.Insert(0, new Restorani_Result { RestoranID = 0, Naziv = "Svi restorani" });
                cmbRestorani.DataSource = listRestoraniFromApi;
                cmbRestorani.ValueMember = "RestoranID";
                cmbRestorani.DisplayMember = "Naziv";

                //enable controls
                cmbRestorani.Enabled = true;
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void BindMainGrid(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servisKorisnici.GetResponse(new Dictionary<string, int> { { "uloga", 1} });
            if (response.IsSuccessStatusCode)
            {
                zaposleniciBindingList = originalZaposleniciBindingList = new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
                zaposleniciBindingSource.DataSource = zaposleniciBindingList;

                dgvZaposlenici.DataSource = zaposleniciBindingSource;
                dgvZaposlenici.Columns[dgvZaposlenici.Columns.Count - 1].DefaultCellStyle.Format = "dd.MM.yyyy";

                //enable controls
                txtPretraga.Enabled = true;
                btnDetaljno.Enabled = true;
                btnIzbrisi.Enabled = true;

                if (recheckPretraga)
                {
                    pretragaByString();
                }
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void pretragaByString()
        {
            zaposleniciBindingList = new BindingList<Korisnici_Result>(originalZaposleniciBindingList
                .Where(k => (k.ImePrezime + " " + k.Username + " " + k.Email + " " + k.DatumRegistracije.ToString("dd.MM.yyyy") + " "
                    + k.Adresa + " " + k.Blok + " " + k.Grad + " " + k.Telefon).Contains(txtPretraga.Text))
                .ToList());
            zaposleniciBindingSource.DataSource = zaposleniciBindingList;

            lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "zaposlenika", zaposleniciBindingList.Count);
        }


        #region GridHandlers
        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }

        private async void cmbRestorani_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRestoranValue;
            try
            {
                selectedRestoranValue = (int)cmbRestorani.SelectedValue;
            }
            catch (Exception ex)
            {
                return; // return ako lista još nije učitana na UI threadu
            }
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            HttpResponseMessage response = selectedRestoranValue == 0 ?
                await servisKorisnici.GetResponse(new Dictionary<string, int> { { "uloga", 1 } }) :
                await servis.GetResponse(String.Format("restorani/{0}/zaposlenici", selectedRestoranValue));
            if (response.IsSuccessStatusCode)
            {
                zaposleniciBindingList = originalZaposleniciBindingList = new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
                zaposleniciBindingSource.DataSource = zaposleniciBindingList;

                lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "zaposlenika", zaposleniciBindingList.Count);
                pretragaByString();
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            Korisnici_Result k = (Korisnici_Result)dgvZaposlenici.CurrentRow.DataBoundItem;
            if (k != null)
            {
                var potvrda = MessageBox.Show(String.Format(ValidationMessages.izbrisi_stavku_potvrda, k.ImePrezime),
                    String.Format(ValidationMessages.izbrisi_stavku_potvrda_title, "zaposlenika"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servisKorisnici.DeleteResponse(k.KorisnikID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(ValidationMessages.uspjesno_izbrisan_obj, "zaposlenik " + k.ImePrezime),
                            ValidationMessages.uspjesno_izbrisan_title);
                        BindMainGrid(recheckPretraga: true);
                    }
                    else
                    {
                        MessageBox.Show(ValidationMessages.GreskaPokusajPonovo);
                    }
                }
            }
            else
            {
                MessageBox.Show(ValidationMessages.morate_prvo_izaberite_obj, "korisnika");
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void btnDetaljno_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            detaljnoZaposlenik = (Korisnici_Result)dgvZaposlenici.CurrentRow.DataBoundItem;
            if (detaljnoZaposlenik != null)
            {
                HttpResponseMessage response = await servis.GetResponse(String.Format("zaposlenici/{0}/restorani", detaljnoZaposlenik.KorisnikID));
                if (response.IsSuccessStatusCode)
                {
                    restoraniZaposlenikaList = new BindingList<Restorani_Result>(response.Content.ReadAsAsync<List<Restorani_Result>>().Result);

                    restoraniZaposlenikaSource.DataSource = restoraniZaposlenikaList;
                    listBoxRestorani.DataSource = restoraniZaposlenikaSource;
                    listBoxRestorani.ValueMember = "RestoranID";
                    listBoxRestorani.DisplayMember = "Naziv";

                    lblDetaljnoRestorani.Text = UIHelper.ListToString<Restorani_Result>(delimiter: ", ", 
                        list: restoraniZaposlenikaList.ToList<Restorani_Result>());
                }


                splitContainer1.Panel1Collapsed = false;

                lblDetaljnoImePrezime.Text = detaljnoZaposlenik.ImePrezime ?? "-";
                lblDetaljnoUsername.Text = detaljnoZaposlenik.Username ?? "-";

                lblDetaljnoEmail.Text = detaljnoZaposlenik.Email ?? "-";

                lblDetaljnoTelefon.Text = detaljnoZaposlenik.Telefon ?? "-";

                lblDetaljnoDatumRegistracije.Text = detaljnoZaposlenik.DatumRegistracije != null ? 
                    detaljnoZaposlenik.DatumRegistracije.ToString("dd.MM.yyyy") : "-";

                lblDetaljnoBlok.Text = (detaljnoZaposlenik.Blok ?? "-") + ", " + (detaljnoZaposlenik.Grad ?? "-");
                lblDetaljnoAdresa.Text = detaljnoZaposlenik.Adresa ?? "-";
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }
        #endregion

        #region ZaposlenikDetaljnoHandlers
        private void btnDetaljnoRestorani_Click(object sender, EventArgs e)
        {
            pnlRestoraniZaposlenika.Visible = true;
        }
        private void btnDodajRestoran_Click(object sender, EventArgs e)
        {
            lblVecDodanRestoran.Visible = false;
            try {
                Restorani_Result r = (Restorani_Result)cmbDetaljnoRestorani.SelectedItem;
                if (restoraniZaposlenikaList.Contains(r))
                {
                    lblVecDodanRestoran.Visible = true;
                    return;
                }

                restoraniZaposlenikaList.Add(r);

            }
            catch (Exception ex)
            {
                //
            }
        }
        private void btnUkloniRestoran_Click(object sender, EventArgs e)
        {
            try {
                Restorani_Result r = (Restorani_Result)listBoxRestorani.SelectedItem;
                restoraniZaposlenikaList.Remove(r);
                listBoxRestorani.DataSource = restoraniZaposlenikaList;
            } catch (Exception ex)
            {
                //
            }
        }

        private void btnCloseRestoraniZaposlenika_Click(object sender, EventArgs e)
        {
            pnlRestoraniZaposlenika.Visible = false;
        }

        private void btnCloseZaposlenikDetaljno_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoaderRestorani, ref loaderImgStackDetaljno);

            HttpResponseMessage r = await servis.PostResponse(String.Format("zaposlenici/{0}/restorani", detaljnoZaposlenik.KorisnikID), restoraniZaposlenikaList);
            if (r.IsSuccessStatusCode)
            {
                MessageBox.Show(ValidationMessages.uspjesno_napravljene_izmjene_body, ValidationMessages.uspjesno_napravljene_izmjene_title);

                lblDetaljnoRestorani.Text = UIHelper.ListToString<Restorani_Result>(delimiter: ", ",
                            list: restoraniZaposlenikaList.ToList<Restorani_Result>());
            }

            UIHelper.LoaderImgStackHide(ref imgLoaderRestorani, ref loaderImgStackDetaljno);
        }
        #endregion

    }
}
