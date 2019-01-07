using eDostava_API.Models;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace eRestoraniUI.LokacijeForms
{
    public partial class BlokoviList : Form
    {
        private WebApiHelper servis = new WebApiHelper("locations/blokovi");
        private WebApiHelper servisGradovi = new WebApiHelper("locations/gradovi");

        private Stack<bool> imgLoaderStack = new Stack<bool>();

        private Blokovi_Result blok;

        private BindingList<Blokovi_Result> blokoviBindingList, originalBlokoviBindingList;
        private BindingSource blokoviBindingSource;
        private BindingList<Gradovi_Result> gradoviBindingList;
        private BindingSource gradoviBindingSource;

        public BlokoviList()
        {
            InitializeComponent();

            this.AutoValidate = AutoValidate.Disable;
            dgvBlokovi.AutoGenerateColumns = false;
        }

        private void BlokoviList_Load(object sender, EventArgs e)
        {
            BindBlokoviGrid();
            BindBlokForm(new Blokovi_Result());
            BindGradoviCmb();
        }

        private async void BindBlokoviGrid(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref imgLoaderStack);
            HttpResponseMessage response = await servis.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                blokoviBindingList = originalBlokoviBindingList = new BindingList<Blokovi_Result>(response.Content.ReadAsAsync<List<Blokovi_Result>>().Result);
                blokoviBindingSource = new BindingSource();
                blokoviBindingSource.DataSource = blokoviBindingList;

                dgvBlokovi.DataSource = blokoviBindingSource;

                lblUkupno.Text = String.Format(lblUkupno.Text, blokoviBindingList.Count);

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

        private async void BindGradoviCmb()
        {
            HttpResponseMessage response = await servisGradovi.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                gradoviBindingList = new BindingList<Gradovi_Result>(response.Content.ReadAsAsync<List<Gradovi_Result>>().Result);
                gradoviBindingSource = new BindingSource();
                gradoviBindingSource.DataSource = gradoviBindingList;

                cmbGradovi.DataSource = gradoviBindingSource;
                cmbGradovi.ValueMember = "GradID";
                cmbGradovi.DisplayMember = "Naziv";
            }
        }

        private void BindBlokForm(Blokovi_Result b)
        {
            // bind our model
            blok = b;

            // load data into form
            txtBlokNaziv.Text = blok.Naziv;
            cmbGradovi.SelectedIndex = cmbGradovi.FindStringExact(blok.NazivGrada);
        }

        #region GridEventHandlers
        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref imgLoaderStack);
            Blokovi_Result b = (Blokovi_Result) dgvBlokovi.CurrentRow.DataBoundItem;
            if (b != null)
            {
                var potvrda = MessageBox.Show(String.Format(Messages.izbrisi_obj_potvrda, b.Naziv),
                    String.Format(Messages.izbrisi_obj_potvrda_title, b.Naziv),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (potvrda == DialogResult.Yes)
                {
                    HttpResponseMessage response = await servis.DeleteResponse(b.BlokID);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(Messages.uspjeh_delete_obj, b.Naziv),
                            Messages.izbrisi_obj_potvrda_title);
                        BindBlokoviGrid(recheckPretraga: true);
                    }
                    else
                    {
                        UIHelper.MessageOnApiError(response.ReasonPhrase);
                    }
                }
            } else
            {
                MessageBox.Show(Messages.morate_odabrati_msg_obj, "blok");
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref imgLoaderStack);
        }

        private void btnNoviBlok_Click(object sender, EventArgs e)
        {
            BindBlokForm(new Blokovi_Result());
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgvBlokovi.CurrentRow != null)
            {
                BindBlokForm((Blokovi_Result)dgvBlokovi.CurrentRow.DataBoundItem);
                splitContainer1.Panel1Collapsed = false;
            } else
            {
                MessageBox.Show(String.Format(Messages.morate_odabrati_msg_obj, "blok"));
            }
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaByString();
        }
        #endregion

        #region Validators
        private void txtBlokNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtBlokNaziv.Text, @"^[\p{L}\ ]{4,20}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBlokNaziv, String.Format(Messages.polje_type_length_error, "naziv bloka", "slova", 4, 20));
            }
        }

        private void cmbGradovi_Validating(object sender, CancelEventArgs e)
        {
            string error = "Grad ne postoji!";
            if (!Regex.IsMatch(cmbGradovi.Text, @"^(?=.*\p{L})[\p{L}\ ]{4,20}$"))
            {
                error = String.Format(Messages.polje_type_length_error, 
                    "naziv grada", "slova", 4, 20);
            }
            else if(!gradoviBindingList.Select(g => g.Naziv).ToList().Contains(cmbGradovi.Text))
            {
                var kreiraj = MessageBox.Show(String.Format(Messages.obj_ne_postoji_kreiraj_novi_msg, "grad", cmbGradovi.Text),
                    String.Format(Messages.obj_ne_postoji_kreiraj_novi_title, "grad"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (kreiraj == DialogResult.Yes)
                {
                    HttpResponseMessage response = servisGradovi.PostResponse(new Gradovi
                    {
                        Naziv = cmbGradovi.Text
                    });
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(Messages.uspjeh_save_obj, "grad"),
                            Messages.uspjeh_title,
                            MessageBoxButtons.OK);

                        Gradovi_Result novigrad = response.Content.ReadAsAsync<Gradovi_Result>().Result;
                        gradoviBindingList.Add(novigrad);
                        cmbGradovi.SelectedItem = novigrad;

                        errorProvider1.SetError(cmbGradovi, "");

                        return;
                    }
                    else
                    {
                        MessageBox.Show(String.Format(Messages.greska_msg_obj_body, "tip kuhinje"),
                            Messages.greska_msg_title,
                            MessageBoxButtons.OK);
                    }
                }

            } else
            {
                return;
            }

            e.Cancel = true;
            errorProvider1.SetError(cmbGradovi, error);
        }

        private void pretragaByString()
        {
            blokoviBindingList = new BindingList<Blokovi_Result>(originalBlokoviBindingList.Where(b => (b.Naziv + " " + b.NazivGrada).ToLower()
                .Contains(txtPretraga.Text.ToLower()))
                .ToList());
            blokoviBindingSource.DataSource = blokoviBindingList;

            lblUkupno.Text = String.Format(lblUkupno.Text, blokoviBindingList.Count);
        }
        #endregion

        #region FormHandlers
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!this.ValidateChildren())
            {
                return;
            }

            blok.Naziv = txtBlokNaziv.Text;
            blok.GradID = Convert.ToInt32(cmbGradovi.SelectedValue);

            HttpResponseMessage response = blok.BlokID == 0 ?
                servis.PostResponse(blok) :
                servis.PutResponse(blok.BlokID, blok);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(String.Format(Messages.uspjeh_save_obj, "blok"),
                    Messages.uspjeh_title,
                    MessageBoxButtons.OK);
                blok = response.Content.ReadAsAsync<Blokovi_Result>().Result;
                BindBlokoviGrid(recheckPretraga: true);
            } else
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            BindBlokForm(new Blokovi_Result());
            splitContainer1.Panel1Collapsed = true;
        }
        #endregion

    }
}
