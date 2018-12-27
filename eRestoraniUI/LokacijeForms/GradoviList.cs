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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.LokacijeForms
{
    public partial class GradoviList : Form
    {
        WebApiHelper servis = new WebApiHelper("locations/gradovi");

        private Stack<bool> imgLoaderStack = new Stack<bool>();
        private Gradovi_Result grad;

        BindingList<Gradovi_Result> gradoviBindingList, originalGradoviBindingList;
        BindingSource gradoviBindingSource;


        public GradoviList()
        {
            InitializeComponent();

            this.AutoValidate = AutoValidate.Disable;
            dgvGradovi.AutoGenerateColumns = false;
        }

        private void GradoviList_Load(object sender, EventArgs e)
        {
            BindGradoviGrid();
            BindGradForm(new Gradovi_Result());
        }

        private void BindGradForm(Gradovi_Result g)
        {
            grad = g;

            txtNaziv.Text = grad.Naziv;
            txtPostanskiBroj.Text = grad.PostanskiBroj.ToString();

        }

        private async void BindGradoviGrid(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref imgLoaderStack);

            HttpResponseMessage response = await servis.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                gradoviBindingList = originalGradoviBindingList = new BindingList<Gradovi_Result>(response.Content.ReadAsAsync<List<Gradovi_Result>>().Result);
                gradoviBindingSource = new BindingSource();
                gradoviBindingSource.DataSource = gradoviBindingList;

                dgvGradovi.DataSource = gradoviBindingSource;
                lblUkupno.Text = String.Format(lblUkupno.Text, gradoviBindingList.Count);

                if (recheckPretraga)
                {
                    pretragaByString();
                }
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " +
                    response.ReasonPhrase);
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref imgLoaderStack);
        }


        #region FormHandlers
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            BindGradForm(new Gradovi_Result());
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!this.ValidateChildren())
            {
                return;
            }

            grad.Naziv = txtNaziv.Text;
            grad.PostanskiBroj = Convert.ToInt32(txtPostanskiBroj.Text);

            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref imgLoaderStack);
            HttpResponseMessage response = grad.GradID != 0 ? 
                servis.PutResponse(grad.GradID, grad) :
                servis.PostResponse(grad);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(String.Format(ValidationMessages.uspjesno_kreiran_obj, "grad"),
                    ValidationMessages.UspjenoKreiranTitle,
                    MessageBoxButtons.OK);

                grad = response.Content.ReadAsAsync<Gradovi_Result>().Result;
                BindGradoviGrid(recheckPretraga: true);
            } else
            {
                MessageBox.Show(ValidationMessages.GreskaPokusajPonovo);
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref imgLoaderStack);

        }
        #endregion

        #region GridHandlers
        private void pretragaByString()
        {
            gradoviBindingList = new BindingList<Gradovi_Result>(originalGradoviBindingList
                .Where(g => (g.Naziv + " " + g.PostanskiBroj).ToLower().Contains(txtPretraga.Text.ToLower()))
                .ToList());
            gradoviBindingSource.DataSource = gradoviBindingList;
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref imgLoaderStack);
            Gradovi_Result grad = (Gradovi_Result)dgvGradovi.CurrentRow.DataBoundItem;
            if (grad != null)
            {
                var potvrda = MessageBox.Show(String.Format(ValidationMessages.izbrisi_stavku_potvrda, grad.Naziv),
                    ValidationMessages.izbrisi_stavku_potvrda_title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servis.DeleteResponse(grad.GradID);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(ValidationMessages.uspjesno_izbrisan_obj, grad.Naziv),
                            ValidationMessages.uspjesno_izbrisan_title);

                        BindGradoviGrid(recheckPretraga: true);
                    } else
                    {
                        MessageBox.Show(ValidationMessages.GreskaPokusajPonovo);
                    }
                }
            } else
            {
                MessageBox.Show(ValidationMessages.PrvoIzaberiObj, "grad");
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref imgLoaderStack);
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            Gradovi_Result g = (Gradovi_Result)dgvGradovi.CurrentRow.DataBoundItem;
            if (g != null)
            {
                BindGradForm(g);
                splitContainer1.Panel1Collapsed = false;
            } else
            {
                MessageBox.Show(ValidationMessages.PrvoIzaberiObj, "grad");
            }
        }

        private void btnNoviGrad_Click(object sender, EventArgs e)
        {
            BindGradForm(new Gradovi_Result());
            splitContainer1.Panel1Collapsed = false;
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }
        #endregion

        #region Validators
        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtNaziv.Text, @"^(?=.*\p{L})[\p{L}\ ]{4,20}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, String.Format(ValidationMessages.polje_tip_duzina, "naziv", "slova", 4, 20));
            }
        }

        private void txtPostanskiBroj_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtPostanskiBroj.Text, @"^[\d]{4,20}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPostanskiBroj, String.Format(ValidationMessages.polje_tip_duzina, "poštanski broj", "cifre", 4, 20));
            }
        }
        #endregion
    }
}
