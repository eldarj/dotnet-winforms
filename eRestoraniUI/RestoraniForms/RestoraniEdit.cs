using eDostava_API.Models;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.RestoraniUI
{
    public partial class RestoraniEdit : Form
    {
        private WebApiHelper servisRestorani = new WebApiHelper("restorani");
        private WebApiHelper servis = new WebApiHelper();

        private Restorani_Result restoranModel;

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();

        // Bindinglist helpers for UI binding
        BindingListHelper<Korisnici_Result> vlasniciRestoranaBox;
        BindingListHelper<Korisnici_Result> zaposleniciRestoranaBox;

        public RestoraniEdit()
        {
            InitializeComponent();
            this.Text = "Novi restoran";
            this.AutoValidate = AutoValidate.Disable;
        }

        public RestoraniEdit(Restorani_Result editRestoran)
        {
            InitializeComponent();
            if (editRestoran != null)
            {
                restoranModel = editRestoran;
                this.Text = String.Format(Messages.uredi_restoran_obj, restoranModel.Naziv);
            }

            this.AutoValidate = AutoValidate.Disable;
        }
        #region Form Initializers
        private async void RestoraniEdit_Load(object sender, EventArgs e)
        {
            if (UserAccessControlHelper.AdminRights)
            {
                lblCmbStatusi.Visible = cmbStatusi.Visible = true;
                pnlEditVlasnici.Visible = btnUkloniVlasnika.Visible = true;
            }
            else
            {
                lblEditVlasnici.Text = "Vlasnik: " + Global.PrijavljeniKorisnik.Ime + " " + Global.PrijavljeniKorisnik.Prezime;
            }

            BindCmbZaposleniciVlasnici();

            if (restoranModel == null)
            {
                BindCmbStatusiBlokovi();
            } else
            {
                await BindCmbStatusiBlokovi();
                FillFormOnEdit();
            }
        }

        private async void FillFormOnEdit()
        {
            txtSifra.Text = restoranModel.Sifra.ToString();
            txtNaziv.Text = restoranModel.Naziv;
            txtEmail.Text = restoranModel.Email;
            txtWebUrl.Text = restoranModel.WebUrl;
            txtOpis.Text = restoranModel.Opis;
            txtMaskTelefon.Text = UIHelper.ExtractPoneNumber(restoranModel.Telefon);
            txtMaskMinCijena.Text = UIHelper.GenerateMaskedDecimal((double)restoranModel.MinimalnaCijenaNarudzbe);

            pictureBoxSlika.Image = restoranModel.GetSlikaImage();

            txtAdresa.Text = restoranModel.Adresa;
            cmbBlokoviGradovi.SelectedIndex = cmbBlokoviGradovi.FindStringExact(restoranModel.BlokNaziv + ", " + restoranModel.GradNaziv);

            lblTrenutniStatus.Text = String.Format(Messages.trenutni_status_restoran, restoranModel.StatusNaziv);
            if (UserAccessControlHelper.AdminRights)
            {
                cmbStatusi.SelectedIndex = cmbStatusi.FindStringExact(restoranModel.StatusNaziv);

                vlasniciRestoranaBox = await UIHelper.GenericBindListBox<Korisnici_Result>(imgLoader, loaderImgStack,
                "restorani/" + restoranModel.RestoranID + "/vlasnici", listBoxVlasnici, "KorisnikID", "ImePrezime");
            }

            zaposleniciRestoranaBox = await UIHelper.GenericBindListBox<Korisnici_Result>(imgLoader, loaderImgStack,
                "restorani/" + restoranModel.RestoranID + "/zaposlenici", listBoxZaposlenici, "KorisnikID", "ImePrezime");
        }
        
        // Void jer hoćemo da setujemo cmb zaposlenike i vlasnike bez čekanja i uvijek asinhrono
        private void BindCmbZaposleniciVlasnici()
        {
            Task bindZaposlenike = UIHelper.GenericBindCmb<Korisnici_Result>(imgLoader, loaderImgStack, "korisnici",
                cmbZaposlenici, "KorisnikID", "ImePrezime", new Dictionary<string, int> { { "uloga", 1 } });

            if (UserAccessControlHelper.AdminRights)
            {
                Task bindVlasnike = UIHelper.GenericBindCmb<Korisnici_Result>(imgLoader, loaderImgStack, "korisnici",
                    cmbVlasnici, "KorisnikID", "ImePrezime", new Dictionary<string, int> { { "uloga", 2 } });
            }
        }

        // Vrača Task, koji možemo vršiti sa 'await' ili bez (jer npr. na edit hoćemo sačekati da popunimo cmb prvo, prije setujemo postojeće podatke)
        private Task BindCmbStatusiBlokovi()
        {
            Task populateStatusi = null;
            if (UserAccessControlHelper.AdminRights)
            {
                populateStatusi = UIHelper.GenericBindCmb<RestoranStatusi_Result>(imgLoader, loaderImgStack, "restorani/statusi",
                cmbStatusi, "RestoranStatusID", "Naziv");
            }
            Task populateBlokovi = UIHelper.GenericBindCmb<Blokovi_Result>(imgLoader, loaderImgStack, "locations/blokovi",
                cmbBlokoviGradovi, "BlokID", "BlogGradFull");

            return UserAccessControlHelper.AdminRights ? Task.WhenAll(populateStatusi, populateBlokovi) : populateBlokovi;
        }
        #endregion

        #region ClickHandlers
        private void btnUkloniZaposlenika_Click(object sender, EventArgs e)
        {
            if (listBoxZaposlenici.SelectedItem != null)
            {
                zaposleniciRestoranaBox.Remove((Korisnici_Result)listBoxZaposlenici.SelectedItem);
            }
        }

        private void btnUkloniVlasnika_Click(object sender, EventArgs e)
        {
            if (listBoxVlasnici.SelectedItem != null)
            {
                vlasniciRestoranaBox.Remove((Korisnici_Result)listBoxVlasnici.SelectedItem);
            }
        }

        private void btnDodajZaposlenika_Click(object sender, EventArgs e)
        {
            lblVecDodanZaposlenik.Visible = false;
            if (cmbZaposlenici.SelectedItem != null)
            {
                Korisnici_Result r = (Korisnici_Result)cmbZaposlenici.SelectedItem;
                if (zaposleniciRestoranaBox == null)
                {
                    zaposleniciRestoranaBox = UIHelper.GenericBindListBox<Korisnici_Result>(listBoxZaposlenici, "KorisnikID",
                        "ImePrezime", new List<Korisnici_Result> { r });
                }
                else if(zaposleniciRestoranaBox.Contains(r))
                {
                    lblVecDodanZaposlenik.Visible = true;
                }
                else
                {
                    zaposleniciRestoranaBox.Add(r);
                }
            }
        }

        private void btnDodajVlasnika_Click(object sender, EventArgs e)
        {
            lblVecDodanVlasnik.Visible = false;
            if(cmbVlasnici.SelectedItem != null)
            {
                Korisnici_Result r = (Korisnici_Result) cmbVlasnici.SelectedItem;
                if (vlasniciRestoranaBox == null)
                {
                    vlasniciRestoranaBox = UIHelper.GenericBindListBox<Korisnici_Result>(listBoxVlasnici, "KorisnikID",
                        "ImePrezime", new List<Korisnici_Result> { r });
                }
                else if(vlasniciRestoranaBox.Contains(r))
                {
                    lblVecDodanVlasnik.Visible = true;
                }
                else
                {
                    vlasniciRestoranaBox.Add(r);
                }
            }
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSlikaName.Text = fileDialog.FileName;

                Image originalImage = Image.FromFile(fileDialog.FileName);
                restoranModel.SetSlikaImage(originalImage);

                int resizedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageWidth"]);
                int resizedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageHeight"]);

                // IF ORIGINAL: veća onda uradi resize
                if (originalImage.Width > resizedImageWidth)
                {
                    Image ResizedImage = UIHelper.ResizeImage(originalImage, new Size(resizedImageWidth, resizedImageHeight));

                    restoranModel.SetSlikaImage(ResizedImage); // bind model
                    pictureBoxSlika.Image = ResizedImage; // bind picture in form
                }
                // ELSE ORIGINAL: ako je originalna manja od resize veličine, odmah stavi original
                else
                {
                    pictureBoxSlika.Image = originalImage;
                }
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            bool isPutRequest = false;
            Restorani restoran = new Restorani();

            if (restoranModel != null)
            {
                restoran = Restorani_Result.GetRestoraniInstance(restoranModel);
                isPutRequest = true;
            }

            restoran.Naziv = txtNaziv.Text;
            restoran.Opis = txtOpis.Text;
            restoran.Email = txtEmail.Text;
            restoran.WebUrl = txtWebUrl.Text;
            restoran.Telefon = UIHelper.ExtractPoneNumber(txtMaskTelefon.Text);
            restoran.MinimalnaCijenaNarudzbe = (decimal)Convert.ToDouble(UIHelper.ExtractDecimalCijena(txtMaskMinCijena.Text));

            restoran.Adresa = txtAdresa.Text;
            restoran.BlokID = Convert.ToInt32(cmbBlokoviGradovi.SelectedValue);
            if (Global.PrijavljeniKorisnik != null && restoran.RestoranStatusID != Convert.ToInt32(cmbStatusi.SelectedValue))
            {
                restoran.KorisnikID = Global.PrijavljeniKorisnik.KorisnikID;
                restoran.RestoranStatusID = Convert.ToInt32(cmbStatusi.SelectedValue);
            }

            List<HttpResponseMessage> responseStatuses = new List<HttpResponseMessage>();

            HttpResponseMessage rMain = isPutRequest ? 
                servisRestorani.PutResponse(restoran.RestoranID, restoran) : 
                servisRestorani.PostResponse(restoran);
            responseStatuses.Add(rMain);

            if (zaposleniciRestoranaBox != null)
            {
                HttpResponseMessage rZaposl = await servisRestorani.PostResponse(restoranModel.RestoranID + "/zaposlenici", zaposleniciRestoranaBox.GetList());
                responseStatuses.Add(rZaposl);
            }

            if (UserAccessControlHelper.AdminRights && vlasniciRestoranaBox != null)
            {
                HttpResponseMessage rVlasnici = await servisRestorani.PostResponse(restoranModel.RestoranID + "/vlasnici", vlasniciRestoranaBox.GetList());
                responseStatuses.Add(rVlasnici);
            }

            if (responseStatuses.Any(s => !s.IsSuccessStatusCode))
            {
                var resp = responseStatuses.Where(s => !s.IsSuccessStatusCode).FirstOrDefault();
                string msg = resp.ReasonPhrase;

                UIHelper.MessageOnApiError(msg);
            } else
            {
                MessageBox.Show(Messages.uspjesno_napravljene_izmjene_body, Messages.uspjeh_save_title);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Validators
        private void inputNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNaziv, Messages.naziv_obavezno_polje);
            }
        }

        private void inputEmail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Messages.email_required_error);
            } else
            {
                try
                {
                    MailAddress mail = new MailAddress(txtEmail.Text);
                } catch (FormatException fe)
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtEmail, Messages.email_format_error);
                }
            }
        }

        private void inputMinCijenaNarudzbe_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaskMinCijena.Text))
            {
                txtMaskMinCijena.Text = "0";
            }
        }
        #endregion
    }
}
