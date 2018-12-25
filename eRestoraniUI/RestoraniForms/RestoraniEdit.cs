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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.RestoraniUI
{
    public partial class RestoraniEdit : Form
    {
        private WebApiHelper servis = new WebApiHelper("restorani");
        private Restorani_Result restoran;

        public RestoraniEdit(Restorani_Result r)
        {
            InitializeComponent();
            if (r != null)
            {
                restoran = r;
                FillForm();
            }

            this.AutoValidate = AutoValidate.Disable;
        }

        public RestoraniEdit()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void FillForm()
        {
            inputNaziv.Text = restoran.Naziv;
            inputEmail.Text = restoran.Email;
            inputWebUrl.Text = restoran.WebUrl;
            inputOpis.Text = restoran.Opis;
            inputTelefon.Text = UIHelper.ExtractPoneNumber(restoran.Telefon);
            inputMinCijenaNarudzbe.Text = UIHelper.GenerateMaskedDecimal((double)restoran.MinimalnaCijenaNarudzbe);
        }

        private void btnAddRestoran_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            HttpResponseMessage response;
            if (restoran != null)
            {
                restoran.Naziv = inputNaziv.Text;
                restoran.Opis = inputOpis.Text;
                restoran.Email = inputEmail.Text;
                restoran.WebUrl = inputWebUrl.Text;
                restoran.Telefon = UIHelper.ExtractPoneNumber(inputTelefon.Text);
                restoran.MinimalnaCijenaNarudzbe = (decimal)Convert.ToDouble(UIHelper.ExtractDecimalCijena(inputMinCijenaNarudzbe.Text));

                response = servis.PutResponse(restoran.RestoranID, restoran);
            } else
            {
                Restorani r = new Restorani
                {
                    Naziv = inputNaziv.Text,
                    Opis = inputOpis.Text,
                    Email = inputEmail.Text,
                    WebUrl = inputWebUrl.Text,
                    Telefon = inputTelefon.Text,
                    Sifra = Guid.NewGuid()
                };
                try
                {
                    string str = UIHelper.ExtractDecimalCijena(inputMinCijenaNarudzbe.Text);
                    r.MinimalnaCijenaNarudzbe = str.Length > 0 ?
                            Decimal.Parse(UIHelper.ExtractDecimalCijena(str)) :
                            0;
                } catch (FormatException fe)
                {
                    // handle exception?
                }
                response = servis.PostResponse(r);
            }

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Restoran uspješno sačuvan!");
                DialogResult = DialogResult.OK;
                Close();
            } else
            {
                string msg = response.ReasonPhrase;
                if (!String.IsNullOrEmpty(Messages.ResourceManager.GetString(response.ReasonPhrase)))
                {
                    msg = Messages.ResourceManager.GetString(response.ReasonPhrase);
                }
                
                // TODO: change this to use the above msg
                UIHelper.MessageOnApiError(response);
            }
        }

        private void inputNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(inputNaziv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(inputNaziv, Messages.edit_restoran_obavezno_polje_naziv);
            }
        }

        private void inputEmail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(inputEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(inputEmail, Messages.edit_restoran_obavezno_polje_email);
            } else
            {
                try
                {
                    MailAddress mail = new MailAddress(inputEmail.Text);
                } catch (FormatException fe)
                {
                    e.Cancel = true;
                    errorProvider.SetError(inputEmail, Messages.edit_restoran_email_format_error);
                }
            }
        }
        private void inputMinCijenaNarudzbe_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(inputMinCijenaNarudzbe.Text))
            {
                inputMinCijenaNarudzbe.Text = "0";
            }
        }
    }
}
