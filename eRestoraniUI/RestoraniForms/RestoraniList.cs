using eDostava_API.Models;
using eRestoraniUI.HranaUI;
using eRestoraniUI.RestoraniUI;
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

namespace eRestoraniUI
{
    public partial class RestoraniList : Form
    {
        private WebApiHelper servis = new WebApiHelper("http://localhost:58299", "restorani");

        public RestoraniList()
        {
            InitializeComponent();
            dgvRestorani.AutoGenerateColumns = false;
            
        }

        private void RestoraniList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUcitajRestorane_Click(object sender, EventArgs e)
        {
            LoadData();
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

        public async void LoadData()
        {
            HttpResponseMessage response = txtRestoranFilter.Text.Length > 3 ? 
                await servis.GetResponse("pretraga/" + txtRestoranFilter.Text) : 
                await servis.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Restorani_Result> restorani = response.Content.ReadAsAsync<List<Restorani_Result>>().Result;
                dgvRestorani.DataSource = restorani;
                dgvRestorani.ClearSelection();
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " +
                    response.ReasonPhrase);
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
            } else
            {
                MessageBox.Show("Da biste pregledali jelovnike prvo odaberite restoran", 
                    "Izaberite restoran", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            var r = (Restorani_Result)dgvRestorani.CurrentRow.DataBoundItem;
            var potvrdi = MessageBox.Show("Jeste li sigurni da želite trajno izbrisati restoran " + r.Naziv,
                "Izbriši restoran " + r.Naziv,
                MessageBoxButtons.YesNo);
            if (potvrdi == DialogResult.Yes)
            {
                HttpResponseMessage response = await servis.DeleteResponse(r.RestoranID);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Uspješno ste izbrisali restoran!");
                    LoadData();
                } else
                {
                    MessageBox.Show("Došlo je do greške, restoran nije izbrisan.");
                }
            }
        }
    }
}
