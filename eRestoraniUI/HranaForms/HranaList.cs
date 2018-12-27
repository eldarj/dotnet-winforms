using eDostava_API.Models;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using eRestoraniUI.ResourceMessages;

namespace eRestoraniUI.HranaUI
{
    public partial class HranaList : Form
    {
        private int restoranId;

        private WebApiHelper servis = new WebApiHelper("restorani/{0}/hrana");
        private WebApiHelper servisTipoviKuhinje = new WebApiHelper("tipovikuhinje");

        private Hrana_Result hranaStavka;
        private BindingList<TipoviKuhinje_Result> tipoviKuhinje;
        private BindingSource tipoviKuhinjeSource = new BindingSource();

        private Image croppedImage;

        public HranaList(int restoranId, string restoranNaziv)
        {
            InitializeComponent();
            servis.Route = String.Format(servis.Route, restoranId);
            this.restoranId = restoranId;
            lblRestoranInfo.Text = "Restoran: " + restoranNaziv;

            this.AutoValidate = AutoValidate.Disable;
            dgvHranaList.AutoGenerateColumns = false;
        }

        private async void HranaList_Load(object sender, EventArgs e)
        {
            await BindHranaGrid();
            BindHranaForm(new Hrana_Result
            {
                Sifra = Guid.NewGuid()
            });
            BindTipoviKuhinjeCmb();
        }

        public async Task BindHranaGrid()
        {
            imgLoader.Visible = true;
            HttpResponseMessage responseHranaGrid = txtPretraga.Text.Length > 3 ?
                await servis.GetResponse("pretraga/" + txtPretraga.Text) :
                await servis.GetResponse();

            if (responseHranaGrid.IsSuccessStatusCode)
            {
                List<Hrana_Result> restorani = responseHranaGrid.Content.ReadAsAsync<List<Hrana_Result>>().Result;
                dgvHranaList.DataSource = restorani;
                dgvHranaList.ClearSelection();
                lblUkupnoStavki.Text = String.Format(lblUkupnoStavki.Text, restorani.Count);
            }
            else
            {
                MessageBox.Show("Error code: " + responseHranaGrid.StatusCode + " Message: " +
                    responseHranaGrid.ReasonPhrase);
            }

            imgLoader.Visible = false;
        }

        private async void BindTipoviKuhinjeCmb()
        {
            HttpResponseMessage response = await servisTipoviKuhinje.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                tipoviKuhinje = new BindingList<TipoviKuhinje_Result>(response.Content.ReadAsAsync<List<TipoviKuhinje_Result>>().Result);
                tipoviKuhinjeSource.DataSource = tipoviKuhinje;

                cmbTipoviKuhinje.DataSource = tipoviKuhinjeSource;
                cmbTipoviKuhinje.ValueMember = "TipKuhinjeID";
                cmbTipoviKuhinje.DisplayMember = "Naziv";
            }
        }

        public void BindHranaForm(Hrana_Result stavka)
        {
            // bind our model
            hranaStavka = stavka;

            // set panel title
            lblHranaFormTitle.Text = hranaStavka.Naziv != null ? hranaStavka.Naziv : "Nova stavka hrane";

            // load data into form
            txtNaziv.Text = hranaStavka.Naziv;
            txtOpis.Text = hranaStavka.Opis;
            txtSifra.Text = hranaStavka.Sifra.ToString();
            txtCijena.Text = UIHelper.GenerateMaskedDecimal(hranaStavka.Cijena);

            cmbTipoviKuhinje.SelectedIndex = cmbTipoviKuhinje.FindStringExact(hranaStavka.TipKuhinjeNaziv);

            pictureBoxSlika.Image = hranaStavka.GetSlikaImage();

            checkCropImage.CheckState = CheckState.Unchecked;
            checkCropImage.Enabled = hranaStavka.GetSlikaThumbImage() == null ? false : true;
            lblCropDisabled.Visible = hranaStavka.GetSlikaThumbImage() == null && hranaStavka.GetSlikaImage() != null ? true : false;
        }

        #region FormHandlers
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            BindHranaForm(new Hrana_Result
            {
                Sifra = Guid.NewGuid()
            });
            splitContainer1.Panel1Collapsed = true;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidatorHelper.ValidateChildren(containerToBeValidated: this, doNotValidate: txtPretraga, doValidate: pnlForm))
            {
                return;
            }
            formErrorProvider.Clear();

            hranaStavka.Naziv = txtNaziv.Text;
            hranaStavka.Opis = txtOpis.Text;
            hranaStavka.TipKuhinjeID = Convert.ToInt16(cmbTipoviKuhinje.SelectedValue);
            hranaStavka.RestoranID = restoranId;
            hranaStavka.Cijena = Convert.ToDouble(UIHelper.ExtractDecimalCijena(txtCijena.Text));

            HttpResponseMessage response = hranaStavka.HranaID != 0 ?
                servis.PutResponse(hranaStavka.HranaID, hranaStavka) :
                servis.PostResponse(hranaStavka);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(String.Format(ValidationMessages.uspjesno_kreiran_obj, "stavku hrane"),
                    ValidationMessages.UspjenoKreiranTitle,
                    MessageBoxButtons.OK);

                hranaStavka = response.Content.ReadAsAsync<Hrana_Result>().Result;
                lblHranaFormTitle.Text = hranaStavka.Naziv;

                await BindHranaGrid();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void checkCropImage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCropImage.CheckState == CheckState.Checked)
            {
                hranaStavka.SetSlikaThumbImage(croppedImage);
                pictureBoxSlika.Image = croppedImage;
            }
            else
            {
                hranaStavka.SetSlikaThumbImage(null);
                pictureBoxSlika.Image = hranaStavka.GetSlikaImage();
            }
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSlikaName.Text = fileDialog.FileName;
                checkCropImage.CheckState = CheckState.Unchecked; // uncheck cropcheckbox
                checkCropImage.Enabled = false; // po defaultu isključi crop opciju (kasnije ćemo uključiti ako je moguće uraditi crop)
                lblCropDisabled.Visible = true;

                Image originalImage = Image.FromFile(fileDialog.FileName);
                hranaStavka.SetSlikaImage(originalImage);

                int resizedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageWidth"]);
                int resizedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageHeight"]);
                int croppedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageWidth"]);
                int croppedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageHeight"]);

                // IF ORIGINAL: veća onda uradi resize
                if (originalImage.Width > croppedImageWidth)
                {
                    Image ResizedImage = UIHelper.ResizeImage(originalImage, new Size(resizedImageWidth, resizedImageHeight));

                    hranaStavka.SetSlikaImage(ResizedImage); // bind model
                    pictureBoxSlika.Image = ResizedImage; // bind picture in form

                    // if: resized veličina veća od cropped, ako nije, nemoj ni stavljati thumb sliku
                    if (ResizedImage.Width >= croppedImageWidth && ResizedImage.Height >= croppedImageHeight)
                    {
                        int xPosition = (ResizedImage.Width - croppedImageWidth) / 2;
                        int yPosition = (resizedImageHeight - croppedImageHeight) / 2;

                        croppedImage = UIHelper.CropImage(ResizedImage,
                            new Rectangle(xPosition, yPosition, croppedImageWidth, croppedImageHeight));

                        checkCropImage.Enabled = true;
                        lblCropDisabled.Visible = false;
                    }
                }
                // ELSE ORIGINAL: ako je originalna manja od resize veličine, odmah stavi original
                else
                {
                    hranaStavka.SetSlikaImage(originalImage);
                    pictureBoxSlika.Image = originalImage;
                }

            }
        }
        #endregion


        #region GridClickHandlers
        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            imgLoader.Visible = true;
            var h = (Hrana_Result)dgvHranaList.CurrentRow.DataBoundItem;
            var potvrda = MessageBox.Show(String.Format(ValidationMessages.izbrisi_stavku_potvrda, h.Naziv),
                String.Format(ValidationMessages.izbrisi_stavku_potvrda_title, h.Naziv),
                MessageBoxButtons.YesNo);
            if (potvrda == DialogResult.Yes)
            {
                HttpResponseMessage response = await servis.DeleteResponse(h.HranaID);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format(ValidationMessages.uspjesno_izbrisan_obj, h.Naziv), 
                        ValidationMessages.izbrisi_stavku_potvrda_title);
                    await BindHranaGrid();
                }
                else
                {
                    MessageBox.Show(ValidationMessages.GreskaPokusajPonovo);
                }
            }
            imgLoader.Visible = false;
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            BindHranaForm(new Hrana_Result
            {
                Sifra = Guid.NewGuid()
            });
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgvHranaList.CurrentRow != null)
            {
                BindHranaForm((Hrana_Result)dgvHranaList.CurrentRow.DataBoundItem);
                splitContainer1.Panel1Collapsed = false;
            } else
            {
                MessageBox.Show(String.Format(ValidationMessages.PrvoIzaberiObj, "stavku hrane"));
            }
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            if (!ValidatorHelper.ValidateChildren(containerToBeValidated: this, doNotValidate: pnlForm, doValidate: txtPretraga))
            {
                return;
            }
            pretragaErrorProvider.Clear();
            await BindHranaGrid();
        }
        #endregion

        #region Validators
        private void txtPretraga_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtPretraga.Text, @"^[a-zA-Z\d\.\ ]*$") && !String.IsNullOrEmpty(txtPretraga.Text))
            {
                e.Cancel = true;
                pretragaErrorProvider.SetError(btnTrazi, 
                    String.Format(ValidationMessages.polje_tip, "za pretragu", "alfa numeričke znakove"));
            } 
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtNaziv.Text, @"^(?=.*[\p{L}])[\p{L}\d\ ]{4,}$"))
            {
                e.Cancel = true;
                formErrorProvider.SetError(txtNaziv, "Polje smije sadržati samo slova i brojeve i mora biti duže od 4 karaktera, " +
                    "sa najmanje jednim slovom!");
            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtOpis.Text, @"^(?=.*[\p{L}])[\p{L}\d\ \,\-\.]{4,}$") && !String.IsNullOrEmpty(txtOpis.Text))
            {
                e.Cancel = true;
                formErrorProvider.SetError(txtOpis, "Polje smije sadržati samo slova i brojeve i mora biti duže od 4 karaktera, " +
                    "sa najmanje jednim slovom!");
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(UIHelper.ExtractDecimalCijena(txtCijena.Text)) == 0)
            {
                e.Cancel = true;
                formErrorProvider.SetError(txtCijena, "Morate unijeti cijenu!");
            }
        }

        private void cmbTipoviKuhinje_Validating(object sender, CancelEventArgs e)
        {
            string error = "Tip kuhinje ne postoji!";
            if (!Regex.IsMatch(cmbTipoviKuhinje.Text, @"^(?=.*[a-zA-Z])[a-zA-Z\ ]{4,20}$"))
            {
                error = String.Format(ValidationMessages.polje_tip_duzina,
                    "tip kuhinje", "slova", 4, 20);
            }
            else if (!tipoviKuhinje.Select(t => t.Naziv).ToList().Contains(cmbTipoviKuhinje.Text))
            {
                var kreiraj = MessageBox.Show(String.Format(ValidationMessages.ObjNePostojiKreirajNovi, "tip kuhinje", cmbTipoviKuhinje.Text),
                    String.Format(ValidationMessages.ObjNePostojiKreirajNoviTitle, "tip kuhinje"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (kreiraj == DialogResult.Yes)
                {
                    HttpResponseMessage apiresponse = servisTipoviKuhinje.PostResponse(new TipoviKuhinje
                    {
                        Naziv = cmbTipoviKuhinje.Text
                    });
                    if (apiresponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show(String.Format(ValidationMessages.uspjesno_kreiran_obj, "tip kuhinje"), 
                            ValidationMessages.UspjenoKreiranTitle, 
                            MessageBoxButtons.OK);

                        TipoviKuhinje_Result novitip = apiresponse.Content.ReadAsAsync<TipoviKuhinje_Result>().Result;
                        tipoviKuhinje.Add(novitip);
                        cmbTipoviKuhinje.SelectedItem = novitip;

                        formErrorProvider.SetError(cmbTipoviKuhinje, "");

                        return;
                    }
                    else
                    {
                        MessageBox.Show(String.Format(ValidationMessages.GreskaKreiranObj, "tip kuhinje"), 
                            ValidationMessages.GreskaKreiranTitle, 
                            MessageBoxButtons.OK);
                    }
                }

            } else
            {
                return;
            }

            e.Cancel = true;
            formErrorProvider.SetError(cmbTipoviKuhinje, error);
        }
        #endregion

        //private void pnlHranaForm_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (splitContainer1.Panel1Collapsed == true)
        //    {
        //        this.Height -= (int)splitContainer1.Panel1.Height;
        //    }
        //    else
        //    {
        //        this.Height += (int)splitContainer1.Panel1.Height;
        //    }
        //}

    }
}
