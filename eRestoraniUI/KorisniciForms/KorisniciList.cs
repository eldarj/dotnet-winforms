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
    public partial class KorisniciList : Form
    {
        private WebApiHelper servis = new WebApiHelper("korisnici");
        private WebApiHelper servisUloge = new WebApiHelper("ulogekorisnika");
        private WebApiHelper servisGradovi = new WebApiHelper("locations/gradovi");

        private BindingList<Korisnici_Result> korisniciBindingList, originalKorisniciBindingList;
        private BindingSource korisniciBindingSource;

        // Stack; handle the loading spinner image, when we have multiple async sources
        private Stack<bool> loaderImgStack = new Stack<bool>();

        private int predefinedUloga;

        public KorisniciList()
        {
            InitializeComponent();

            this.AutoValidate = AutoValidate.Disable;
            dgvKorisnici.AutoGenerateColumns = false;
        }

        public KorisniciList(int ulogaKorisnika)
        {
            InitializeComponent();
            predefinedUloga = ulogaKorisnika;

            this.AutoValidate = AutoValidate.Disable;
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private void KorisniciList_Load(object sender, EventArgs e)
        {
            BindKorisniciGrid();
            BindUlogeCmb();
            BindGradoviCmb();
        }

        private async void BindUlogeCmb()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servisUloge.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<UlogeKorisnika_Result> uloge = response.Content.ReadAsAsync<List<UlogeKorisnika_Result>>().Result;
                uloge.Insert(0, new UlogeKorisnika_Result { UlogaKorisnikaID = 0, Uloga = "Sve uloge" });
                cmbUloge.DataSource = uloge;
                cmbUloge.ValueMember = "UlogaKorisnikaID";
                cmbUloge.DisplayMember = "Uloga";
            }

            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void BindGradoviCmb()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            HttpResponseMessage response = await servisGradovi.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Gradovi_Result> gradovi = response.Content.ReadAsAsync<List<Gradovi_Result>>().Result;
                gradovi.Insert(0, new Gradovi_Result { GradID = 0, Naziv = "Svi gradovi" });
                cmbGradovi.DataSource = gradovi;
                cmbGradovi.ValueMember = "GradID";
                cmbGradovi.DisplayMember = "Naziv";
            }

            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void BindKorisniciGrid(bool recheckPretraga = true)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            HttpResponseMessage response = predefinedUloga != 0 ?
                await servis.GetResponse(new Dictionary<string, int> { { "uloga", predefinedUloga } }) :
                await servis.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                korisniciBindingList = originalKorisniciBindingList = new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
                korisniciBindingSource = new BindingSource();
                korisniciBindingSource.DataSource = korisniciBindingList;

                dgvKorisnici.DataSource = korisniciBindingSource;
                lblUkupno.Text = String.Format(Messages.ukupno_type_number, "korisnika", korisniciBindingList.Count);

                if (recheckPretraga)
                {
                    pretragaByString();
                }
            } else
            {
                MessageBox.Show(Messages.greska_msg_pokusaj_ponovo);
            }

            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }

        private void pretragaByString()
        {
            korisniciBindingList = new BindingList<Korisnici_Result>(originalKorisniciBindingList
                .Where(k => (k.ImePrezime + " " + k.Username + " " + k.Email + " "
                    + k.Adresa + " " + k.Blok + " " + k.Grad + " " + k.Telefon).Contains(txtPretraga.Text))
                .ToList());
            korisniciBindingSource.DataSource = korisniciBindingList;

            lblUkupno.Text = String.Format(Messages.ukupno_type_number, "korisnika", korisniciBindingList.Count);
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            Korisnici_Result k = (Korisnici_Result) dgvKorisnici.CurrentRow.DataBoundItem;
            if (k != null)
            {
                var potvrda = MessageBox.Show(String.Format(Messages.izbrisi_obj_potvrda, k.ImePrezime),
                    String.Format(Messages.izbrisi_obj_potvrda_title, "korisnika"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servis.DeleteResponse(k.KorisnikID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(Messages.uspjeh_delete_obj, "korisnik " + k.ImePrezime),
                            Messages.uspjeh_delete_title);
                        BindKorisniciGrid(recheckPretraga: true);
                    } else
                    {
                        MessageBox.Show(Messages.greska_msg_pokusaj_ponovo);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.morate_odabrati_msg_obj, "korisnika");
            }
        }

        private async void cmbFilterUlogeGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedUlogaValue, selectedGradValue;
            try
            {
                selectedUlogaValue = (int) cmbUloge.SelectedValue;
                selectedGradValue = (int) cmbGradovi.SelectedValue;
            }
            catch (Exception ex)
            {
                // IndexChanged listener radi čim se (UI thread) lista inicijalizira, pa može doći do exception-a
                // kad krene Castati SelectedValue u int, a mi još uvijek nismo dobili (popunili) listu sa API-a
                return;
            }
            Dictionary<string, int> queryParams = new Dictionary<string, int>();
            if (selectedUlogaValue != 0)
            {
                //eg. api/korisnici?uloga=1
                queryParams.Add("uloga", selectedUlogaValue);
            }
            if (selectedGradValue != 0)
            {
                //eg. api/korisnici?uloga=1&grad=1
                queryParams.Add("grad", selectedGradValue);
            }

            HttpResponseMessage response = queryParams.Count > 0 ? 
                await servis.GetResponse(queryParams) : 
                await servis.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                korisniciBindingList = originalKorisniciBindingList = new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
                korisniciBindingSource.DataSource = korisniciBindingList;

                lblUkupno.Text = String.Format(Messages.ukupno_type_number, "korisnika", korisniciBindingList.Count);
                pretragaByString();
            }
        }
    }
}
