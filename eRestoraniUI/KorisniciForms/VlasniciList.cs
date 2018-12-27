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
    public partial class VlasniciList : Form
    {
        private WebApiHelper servisKorisnici = new WebApiHelper("korisnici");
        private WebApiHelper servis = new WebApiHelper(); // create just the base api, because we'll handle /korisnici, /restorani, /zaposlenici and /vlasnici

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();
        private Stack<bool> loaderImgStackDetaljno = new Stack<bool>();

        // Vlasnici grid source
        private BindingList<Korisnici_Result> vlasniciBindingList, originalVlasniciBindingList;
        private BindingSource vlasniciBindingSource = new BindingSource();


        // Vlasnik detaljno sources
        Korisnici_Result detaljnoVlasnik;
        List<Restorani_Result> listRestoraniFromApi = new List<Restorani_Result>();
        BindingSource restoraniVlasnikaSource = new BindingSource();

        BindingList<Restorani_Result> restoraniVlasnikaList = new BindingList<Restorani_Result>();

        public VlasniciList()
        {
            InitializeComponent();
            dgvVlasnici.AutoGenerateColumns = false;
        }

        private void VlasniciList_Load(object sender, EventArgs e)
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
            HttpResponseMessage response = await servisKorisnici.GetResponse(new Dictionary<string, int> { { "uloga", 2 } });
            if (response.IsSuccessStatusCode)
            {
                vlasniciBindingList = originalVlasniciBindingList = new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
                vlasniciBindingSource.DataSource = vlasniciBindingList;

                dgvVlasnici.DataSource = vlasniciBindingSource;
                dgvVlasnici.Columns[dgvVlasnici.Columns.Count - 1].DefaultCellStyle.Format = "dd.MM.yyyy";

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
            vlasniciBindingList = new BindingList<Korisnici_Result>(originalVlasniciBindingList
                .Where(k => (k.ImePrezime + " " + k.Username + " " + k.Email + " " + k.DatumRegistracije.ToString("dd.MM.yyyy") + " "
                    + k.Adresa + " " + k.Blok + " " + k.Grad + " " + k.Telefon).Contains(txtPretraga.Text))
                .ToList());
            vlasniciBindingSource.DataSource = vlasniciBindingList;

            lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "vlasnika", vlasniciBindingList.Count);
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
                await servisKorisnici.GetResponse(new Dictionary<string, int> { { "uloga", 2 } }) :
                await servis.GetResponse(String.Format("restorani/{0}/vlasnici", selectedRestoranValue));
            if (response.IsSuccessStatusCode)
            {
                vlasniciBindingList = originalVlasniciBindingList = new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
                vlasniciBindingSource.DataSource = vlasniciBindingList;

                lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "vlasnika", vlasniciBindingList.Count);
                pretragaByString();
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            Korisnici_Result k = (Korisnici_Result)dgvVlasnici.CurrentRow.DataBoundItem;
            if (k != null)
            {
                var potvrda = MessageBox.Show(String.Format(ValidationMessages.izbrisi_stavku_potvrda, k.ImePrezime),
                    String.Format(ValidationMessages.izbrisi_stavku_potvrda_title, "vlasnika"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servisKorisnici.DeleteResponse(k.KorisnikID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(ValidationMessages.uspjesno_izbrisan_obj, "vlasnika " + k.ImePrezime),
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
                MessageBox.Show(ValidationMessages.PrvoIzaberiObj, "vlasnika");
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void btnDetaljno_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            detaljnoVlasnik = (Korisnici_Result)dgvVlasnici.CurrentRow.DataBoundItem;
            restoraniVlasnikaList = null;
            if (detaljnoVlasnik != null)
            {
                HttpResponseMessage response = await servis.GetResponse(String.Format("vlasnici/{0}/restorani", detaljnoVlasnik.KorisnikID));
                if (response.IsSuccessStatusCode)
                {
                    restoraniVlasnikaList = new BindingList<Restorani_Result>(response.Content.ReadAsAsync<List<Restorani_Result>>().Result);

                    restoraniVlasnikaSource.DataSource = restoraniVlasnikaList;
                    listBoxRestorani.DataSource = restoraniVlasnikaSource;
                    listBoxRestorani.ValueMember = "RestoranID";
                    listBoxRestorani.DisplayMember = "Naziv";

                    lblDetaljnoRestorani.Text = UIHelper.ListToString<Restorani_Result>(delimiter: ", ",
                        list: restoraniVlasnikaList.ToList<Restorani_Result>());
                }


                splitContainer1.Panel1Collapsed = false;

                lblDetaljnoImePrezime.Text = detaljnoVlasnik.ImePrezime ?? "-";
                lblDetaljnoUsername.Text = detaljnoVlasnik.Username ?? "-";

                lblDetaljnoEmail.Text = detaljnoVlasnik.Email ?? "-";

                lblDetaljnoTelefon.Text = detaljnoVlasnik.Telefon ?? "-";

                lblDetaljnoDatumRegistracije.Text = detaljnoVlasnik.DatumRegistracije != null ?
                    detaljnoVlasnik.DatumRegistracije.ToString("dd.MM.yyyy") : "-";

                lblDetaljnoBlok.Text = (detaljnoVlasnik.Blok ?? "-") + ", " + (detaljnoVlasnik.Grad ?? "-");
                lblDetaljnoAdresa.Text = detaljnoVlasnik.Adresa ?? "-";
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }
        #endregion

        #region VlasniDetaljnoHandlers
        private void btnDetaljnoRestorani_Click(object sender, EventArgs e)
        {
            pnlRestoraniVlasnika.Visible = true;
        }
        private void btnDodajRestoran_Click(object sender, EventArgs e)
        {
            lblVecDodanRestoran.Visible = false;
            try
            {
                Restorani_Result r = (Restorani_Result)cmbDetaljnoRestorani.SelectedItem;
                if (restoraniVlasnikaList.Contains(r))
                {
                    lblVecDodanRestoran.Visible = true;
                    return;
                }

                restoraniVlasnikaList.Add(r);

            }
            catch (Exception ex)
            {
                //
            }
        }
        private void btnUkloniRestoran_Click(object sender, EventArgs e)
        {
            try
            {
                Restorani_Result r = (Restorani_Result)listBoxRestorani.SelectedItem;
                restoraniVlasnikaList.Remove(r);
                listBoxRestorani.DataSource = restoraniVlasnikaList;
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void btnCloseRestoraniVlasnika_Click(object sender, EventArgs e)
        {
            pnlRestoraniVlasnika.Visible = false;
        }

        private void btnCloseVlasnikDetaljno_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoaderRestorani, ref loaderImgStackDetaljno);

            HttpResponseMessage r = await servis.PostResponse(String.Format("vlasnici/{0}/restorani", detaljnoVlasnik.KorisnikID), restoraniVlasnikaList);
            if (r.IsSuccessStatusCode)
            {
                MessageBox.Show(ValidationMessages.uspjesno_napravljene_izmjene_body, ValidationMessages.uspjesno_napravljene_izmjene_title);

                lblDetaljnoRestorani.Text = UIHelper.ListToString<Restorani_Result>(delimiter: ", ",
                            list: restoraniVlasnikaList.ToList<Restorani_Result>());
            }

            UIHelper.LoaderImgStackHide(ref imgLoaderRestorani, ref loaderImgStackDetaljno);
        }
        #endregion

    }
}
