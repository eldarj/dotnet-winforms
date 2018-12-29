using eDostava_API.Models;
using eRestoraniUI.HranaUI;
using eRestoraniUI.NarudzbeForms;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.RestoraniUI;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI
{
    public partial class RestoraniList : Form
    {
        private WebApiHelper servis = new WebApiHelper("http://localhost:58299", "restorani");

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();

        // Restorani grid source
        private BindingList<Restorani_Result> dgvBindingList, dgvOriginalBindingList;
        private BindingSource dgvBindingSource = new BindingSource();

        public RestoraniList()
        {
            InitializeComponent();
            dgvRestorani.AutoGenerateColumns = false;
        }

        private void RestoraniList_Load(object sender, EventArgs e)
        {
            LoadData();
            BindStatusiCmb();
        }
        private async void BindStatusiCmb()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servis.GetResponse("statusi");
            if (response.IsSuccessStatusCode)
            {
                List<RestoranStatusi_Result> statusi = response.Content.ReadAsAsync<List<RestoranStatusi_Result>>().Result;
                statusi.Insert(0, new RestoranStatusi_Result { RestoranStatusID = 0, Naziv = "Svi statusi" });
                cmbStatusi.DataSource = statusi;
                cmbStatusi.ValueMember = "RestoranStatusID";
                cmbStatusi.DisplayMember = "Naziv";

                //enable controls
                cmbStatusi.Enabled = true;
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        public async void LoadData(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            HttpResponseMessage response = await servis.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                dgvBindingList = dgvOriginalBindingList = new BindingList<Restorani_Result>(response.Content.ReadAsAsync<List<Restorani_Result>>().Result);
                dgvBindingSource.DataSource = dgvBindingList;

                dgvRestorani.DataSource = dgvBindingSource;
                dgvRestorani.ClearSelection();

                //enable controls
                txtRestoranFilter.Enabled = true;
                btnIzbrisi.Enabled = true;
                btnUredi.Enabled = true;
                btnVise.Enabled = true;

                if (recheckPretraga)
                {
                    pretragaByString();
                }
            }

            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void pretragaByString()
        {
            List<Restorani_Result> temp = dgvOriginalBindingList
                .Where(r => (r.Sifra + " " + r.Naziv + " " + r.Email + " " + r.WebUrl + " " + " " + r.AdresaFull
                    + r.Telefon + " " + r.MinimalnaCijenaNarudzbe + " " + r.StatusNaziv).Contains(txtRestoranFilter.Text))
                .ToList();

            dgvBindingList = new BindingList<Restorani_Result>(temp);
            dgvBindingSource.DataSource = dgvBindingList;

            lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "restorana", dgvBindingList.Count);
        }

        private void txtRestoranFilter_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }
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
                await GetRestoraniFromApi() :
                await GetRestoraniFromApi(status: selectedValue);
            if (response.IsSuccessStatusCode)
            {
                dgvBindingList = dgvOriginalBindingList = new BindingList<Restorani_Result>(response.Content.ReadAsAsync<List<Restorani_Result>>().Result);
                dgvBindingSource.DataSource = dgvBindingList;

                lblUkupno.Text = String.Format(Messages.grid_ukupno_stavki, "restorana", dgvBindingList.Count);
                pretragaByString();
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void btnUrediRestoran_Click(object sender, EventArgs e)
        {
            RestoraniEdit f = new RestoraniEdit((Restorani_Result)dgvRestorani.CurrentRow.DataBoundItem);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void btnNoviRestoran_Click(object sender, EventArgs e)
        {
            RestoraniEdit f = new RestoraniEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);

            var r = (Restorani_Result) dgvRestorani.CurrentRow.DataBoundItem;
            if (r != null)
            {
                var potvrdi = MessageBox.Show(String.Format(ValidationMessages.izbrisi_stavku_potvrda, "restoran " + r.Naziv),
                    String.Format(ValidationMessages.izbrisi_stavku_potvrda_title, "restoran"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrdi == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servis.DeleteResponse(r.RestoranID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(ValidationMessages.uspjesno_izbrisan_obj, "restoran " + r.Naziv,
                            ValidationMessages.uspjesno_izbrisan_title));
                        LoadData(recheckPretraga: true);
                    }
                    else
                    {
                        MessageBox.Show(ValidationMessages.GreskaPokusajPonovo);
                    }
                }
            }
            else
            {
                MessageBox.Show(ValidationMessages.morate_prvo_izaberite_obj, "restoran");
            }

            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void btnNarudzbe_Click(object sender, EventArgs e)
        {
            if (dgvRestorani.SelectedRows.Count > 0)
            {
                Restorani_Result r = (Restorani_Result)dgvRestorani.SelectedRows[0].DataBoundItem;
                NarudzbeList f = new NarudzbeList(restoran: r);
                f.MdiParent = Global.Mdi;
                f.Show();
            }
            else
            {
                MessageBox.Show(String.Format(ValidationMessages.morate_prvo_izaberite_obj, "restoran"),
                    ValidationMessages.morate_prvo_izabrati_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnJelovnik_Click(object sender, EventArgs e)
        {
            if (dgvRestorani.SelectedRows.Count > 0)
            {
                int restoranId = (int)dgvRestorani.SelectedRows[0].Cells[0].Value;
                string restoranNaziv = (string)dgvRestorani.SelectedRows[0].Cells[2].Value;

                HranaList f = new HranaList(restoranId, restoranNaziv);
                f.MdiParent = Global.Mdi;
                f.Text = String.Format(f.Text, restoranNaziv);

                f.Show();
            }
            else
            {
                MessageBox.Show(String.Format(ValidationMessages.morate_prvo_izaberite_obj, "restoran"),
                    ValidationMessages.morate_prvo_izabrati_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async Task<HttpResponseMessage> GetRestoraniFromApi(int status = 0)
        {
            Dictionary<string, int> queryParams = status != 0 ?
                new Dictionary<string, int>() { { "status", status } } :
                new Dictionary<string, int>();

            return await servis.GetResponse(queryParams);
        }
    }
}
