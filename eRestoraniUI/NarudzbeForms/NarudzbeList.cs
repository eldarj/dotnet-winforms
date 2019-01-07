using eDostava_API.Models;
using eRestoraniUI.Reports;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.NarudzbeForms
{
    public partial class NarudzbeList : Form
    {
        private WebApiHelper servisNarudzbe = new WebApiHelper("narudzbe");

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();

        // Grid source
        private BindingList<Narudzbe_Result> dgvBindingList, dgvOriginalBindingList, dgvOriginalForReporting;
        private BindingSource dgvBindingSource = new BindingSource();

        private Restorani_Result predefinedRestoran;
        private Narucioci_Result predefinedNarucilac;

        private bool IsGridEmpty => dgvBindingList.Count == 0;

        public NarudzbeList()
        {
            InitializeComponent();
            dgvNarudzbe.AutoGenerateColumns = false;
        }
        public NarudzbeList(Restorani_Result restoran = null, Narucioci_Result narucilac = null)
        {
            this.predefinedRestoran = restoran;
            this.predefinedNarucilac = narucilac;

            InitializeComponent();
            dgvNarudzbe.AutoGenerateColumns = false;
        }

        #region Binders
        private void NarudzbeList_Load(object sender, System.EventArgs e)
        {
            if (predefinedRestoran != null)
                this.Text = String.Format(Messages.narudzbe_restorana, predefinedRestoran.Naziv);
            else if (predefinedNarucilac != null)
                this.Text = String.Format(Messages.narudzbe_narucioca, predefinedNarucilac.ImePrezime);
            else
                this.Text = "Sve narudžbe";

            BindMainGrid();
            BindStatusiCmb();
        }
        private async void BindStatusiCmb()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servisNarudzbe.GetResponse("statusi");
            if (response.IsSuccessStatusCode)
            {
                List<NarudzbeStatusi_Result> statusi = response.Content.ReadAsAsync<List<NarudzbeStatusi_Result>>().Result;
                statusi.Insert(0, new NarudzbeStatusi_Result { NarudzbaStatusID = 0, Naziv = "Svi statusi" });
                cmbStatusi.DataSource = statusi;
                cmbStatusi.ValueMember = "NarudzbaStatusID";
                cmbStatusi.DisplayMember = "Naziv";

                //enable controls
                cmbStatusi.Enabled = true;
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }
        private async void BindMainGrid(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await GetNarudzbeFromApi();
            if (response.IsSuccessStatusCode)
            {
                dgvBindingList = dgvOriginalBindingList = new BindingList<Narudzbe_Result>(response.Content.ReadAsAsync<List<Narudzbe_Result>>().Result);
                dgvBindingSource.DataSource = dgvBindingList;

                dgvNarudzbe.DataSource = dgvBindingSource;
                dgvNarudzbe.Columns[2].DefaultCellStyle.Format = "dd.MM.yyyy hh:mm";

                //enable controls
                txtPretraga.Enabled = !IsGridEmpty;
                btnIzbrisi.Enabled = !IsGridEmpty;
                btnDetaljiNarudzbe.Enabled = !IsGridEmpty;
                btnIzvjestajiList.Enabled = !IsGridEmpty;

                if (recheckPretraga)
                {
                    pretragaByString();
                }
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }
        #endregion

        #region UIHandlers
        private async void cmbStatusi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue;
            try
            {
                selectedValue = (int)cmbStatusi.SelectedValue;
            }
            catch (Exception ex)
            {
                return; // return ako lista još nije učitana na UI threadu
            }
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            HttpResponseMessage response = selectedValue == 0 ?
                await GetNarudzbeFromApi() :
                await GetNarudzbeFromApi(status: selectedValue);
            if (response.IsSuccessStatusCode)
            {
                dgvBindingList = dgvOriginalBindingList = dgvOriginalForReporting = new BindingList<Narudzbe_Result>(response.Content.ReadAsAsync<List<Narudzbe_Result>>().Result);
                dgvBindingSource.DataSource = dgvBindingList;

                lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "narudžbi", dgvBindingList.Count);
                pretragaByString();
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            Narudzbe_Result obj = (Narudzbe_Result)dgvNarudzbe.CurrentRow.DataBoundItem;
            if (obj != null)
            {
                var potvrda = MessageBox.Show(String.Format(ValidationMessages.izbrisi_stavku_potvrda, "narudžbu " + obj.Sifra.ToString().Substring(0, 5) + "..."),
                    String.Format(ValidationMessages.izbrisi_stavku_potvrda_title, "narudžbu"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servisNarudzbe.DeleteResponse(obj.NarudzbaID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(ValidationMessages.uspjesno_izbrisan_obj, "naručilac " + obj.Sifra.ToString().Substring(0, 5) + "..."),
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
                MessageBox.Show(ValidationMessages.morate_prvo_izaberite_obj, "narudžbu");
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void btnDetaljiNarudzbe_Click(object sender, EventArgs e)
        {
            if (dgvNarudzbe.CurrentRow == null) return;
            NarudzbaDetaljno n = new NarudzbaDetaljno(((Narudzbe_Result)dgvNarudzbe.CurrentRow?.DataBoundItem).NarudzbaID);
            if (n.ShowDialog() == DialogResult.OK)
            {
                BindMainGrid(true);
            }
        }
        private void trenutnoPrikazaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = ((NarudzbeStatusi_Result)cmbStatusi.SelectedItem).Naziv;

            ReportViewForm f = new ReportViewForm();
            f.narudzbePoGradovima = dgvBindingList.ToList();
            f.statusiNarudzbi = s;
            f.Show();
        }

        private void narudžbePoGradovimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportViewForm f = new ReportViewForm();
            f.narudzbePoGradovima = dgvOriginalForReporting.ToList();
            f.Show();
        }
        #endregion

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }

        private void pretragaByString()
        {
            List<Narudzbe_Result> temp = null;
            if (Regex.IsMatch(txtPretraga.Text, @"^(<|>)[\d]{1,}$")) // special filter za broj narudžbi
            {
                int filterBroj = Convert.ToInt32(txtPretraga.Text.Substring(1, txtPretraga.Text.Length - 1));
                if (txtPretraga.Text[0] == '<')
                {
                    temp = dgvOriginalBindingList.Where(k => k.UkupnaCijena <= filterBroj).ToList();
                }
                else if (txtPretraga.Text[0] == '>')
                {
                    temp = dgvOriginalBindingList.Where(k => k.UkupnaCijena >= filterBroj).ToList();
                }
            }
            else // obični text filter
            {
                temp = dgvOriginalBindingList
                .Where(k => (k.Sifra + " " + k.Narucilac + " " + k.StatusNarudzbe + " " + k.DatumVrijeme.ToString("dd.MM.yyyy") + " "
                    + k.AdresaFull + " " + k.StatusPromijenioZaposlenik).Contains(txtPretraga.Text))
                .ToList();
            }

            dgvBindingList = new BindingList<Narudzbe_Result>(temp);
            dgvBindingSource.DataSource = dgvBindingList;

            lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "narudžba", dgvBindingList.Count);
        }

        private async Task<HttpResponseMessage> GetNarudzbeFromApi(int status = 0)
        {
            Dictionary<string, int> queryParams = status != 0 ?
                new Dictionary<string, int>() { { "status", status } } :
                new Dictionary<string, int>();

            if (predefinedRestoran != null)
            {
                queryParams.Add("restoran", predefinedRestoran.RestoranID);
            }

            if (predefinedNarucilac != null)
            {
                queryParams.Add("narucilac", predefinedNarucilac.KorisnikID);
            }

            return await servisNarudzbe.GetResponse(queryParams);
        }

    }
}
