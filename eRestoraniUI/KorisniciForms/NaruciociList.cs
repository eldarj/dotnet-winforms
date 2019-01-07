using eDostava_API.Models;
using eRestoraniUI.NarudzbeForms;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.KorisniciForms
{
    public partial class NaruciociList : Form
    {
        private WebApiHelper servisNarucioci = new WebApiHelper("narucioci");
        private WebApiHelper servis = new WebApiHelper();

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();

        // Zaposlenici grid source
        private BindingList<Narucioci_Result> naruciociBindingList, originalNaruciociBindingList;
        private BindingSource naruciociBindingSource = new BindingSource();
        public NaruciociList()
        {
            InitializeComponent();
            dgvNarucioci.AutoGenerateColumns = false;
        }

        private void NaruciociList_Load(object sender, EventArgs e)
        {
            BindMainGrid();
            BindGradoviCmb();
        }

        private async void BindGradoviCmb()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servis.GetResponse("locations/gradovi");
            if (response.IsSuccessStatusCode)
            {
                List<Gradovi_Result> gradovi = response.Content.ReadAsAsync<List<Gradovi_Result>>().Result;
                gradovi.Insert(0, new Gradovi_Result { GradID = 0, Naziv = "Svi gradovi" });
                cmbGradovi.DataSource = gradovi;
                cmbGradovi.ValueMember = "GradID";
                cmbGradovi.DisplayMember = "Naziv";

                //enable controls
                cmbGradovi.Enabled = true;
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void BindMainGrid(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servisNarucioci.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                naruciociBindingList = originalNaruciociBindingList = new BindingList<Narucioci_Result>(response.Content.ReadAsAsync<List<Narucioci_Result>>().Result);
                naruciociBindingSource.DataSource = naruciociBindingList;

                dgvNarucioci.DataSource = naruciociBindingSource;
                dgvNarucioci.Columns[dgvNarucioci.Columns.Count - 3].DefaultCellStyle.Format = "dd.MM.yyyy";

                //enable controls
                txtPretraga.Enabled = true;
                btnNarudzbe.Enabled = true;
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
            List<Narucioci_Result> temp = null;
            if (Regex.IsMatch(txtPretraga.Text, @"^(<|>)[\d]{1,}$")) // special filter za broj narudžbi
            {
                int filterBroj = Convert.ToInt32(txtPretraga.Text.Substring(1, txtPretraga.Text.Length - 1));
                if (txtPretraga.Text[0] == '<')
                {
                    temp = originalNaruciociBindingList.Where(k => k.BrojNarudzbi <= filterBroj || k.UkupnoPotrosio <= filterBroj).ToList();
                }
                else if (txtPretraga.Text[0] == '>')
                {
                    temp = originalNaruciociBindingList.Where(k => k.BrojNarudzbi >= filterBroj || k.UkupnoPotrosio >= filterBroj).ToList();
                }
            }
            else // obični text filter
            {
                temp = originalNaruciociBindingList
                .Where(k => (k.ImePrezime + " " + k.Username + " " + k.Email + " " + k.DatumRegistracije.ToString("dd.MM.yyyy") + " "
                    + k.Adresa + " " + k.Grad + " " + k.UkupnoPotrosio).Contains(txtPretraga.Text))
                .ToList();
            }

            naruciociBindingList = new BindingList<Narucioci_Result>(temp);
            naruciociBindingSource.DataSource = naruciociBindingList;

            lblUkupno.Text = String.Format(Messages.ukupno_type_number, "narucioca", naruciociBindingList.Count);
        }
        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }

        private async void cmbGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRestoranValue;
            try
            {
                selectedRestoranValue = (int)cmbGradovi.SelectedValue;
            }
            catch (Exception ex)
            {
                return; // return ako lista još nije učitana na UI threadu
            }
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            HttpResponseMessage response = selectedRestoranValue == 0 ?
                await servisNarucioci.GetResponse() :
                await servisNarucioci.GetResponse(new Dictionary<string, int> { { "grad", selectedRestoranValue } });
            if (response.IsSuccessStatusCode)
            {
                naruciociBindingList = originalNaruciociBindingList = new BindingList<Narucioci_Result>(response.Content.ReadAsAsync<List<Narucioci_Result>>().Result);
                naruciociBindingSource.DataSource = naruciociBindingList;

                lblUkupno.Text = String.Format(Messages.ukupno_type_number, "zaposlenika", naruciociBindingList.Count);
                pretragaByString();
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void btnNarudzbe_Click(object sender, EventArgs e)
        {
            Narucioci_Result k = (Narucioci_Result)dgvNarucioci.CurrentRow.DataBoundItem;
            if (k != null)
            {
                NarudzbeList f = new NarudzbeList(narucilac: k);
                f.Show();
            } else
            {
                MessageBox.Show(Messages.morate_odabrati_msg_obj, "naručioca");
            }
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            Narucioci_Result k = (Narucioci_Result)dgvNarucioci.CurrentRow.DataBoundItem;
            if (k != null)
            {
                var potvrda = MessageBox.Show(String.Format(Messages.izbrisi_obj_potvrda, k.ImePrezime),
                    String.Format(Messages.izbrisi_obj_potvrda_title, "naručioca"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servis.DeleteResponse("korisnici", k.KorisnikID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(Messages.uspjeh_delete_obj, "naručilac " + k.ImePrezime),
                            Messages.uspjeh_delete_title);
                        BindMainGrid(recheckPretraga: true);
                    }
                    else
                    {
                        MessageBox.Show(Messages.greska_msg_pokusaj_ponovo);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.morate_odabrati_msg_obj, "naručioca");
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }
    }
}
