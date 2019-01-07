using System;
using eDostava_API.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoraniUI.Utils;
using System.Net.Http;
using eRestoraniUI.ResourceMessages;

namespace eRestoraniUI
{
    public partial class LoginForm : Form
    {
        private WebApiHelper servis = new WebApiHelper();

        public LoginForm()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Prijava(object sender, EventArgs e)
        {
            imgLoader.Visible = true;
            if (txtKorisnickoIme.Text.Length < 4 || txtLozinka.Text.Length < 4)
            {
                MessageBox.Show(Messages.login_user_invalid_length, "Upozorenje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                imgLoader.Visible = false;
                return;
            }

            try
            {
                HttpResponseMessage response = await servis.GetResponse("auth/" + txtKorisnickoIme.Text);
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    CredentialsInvalid();
                    imgLoader.Visible = false;
                    return;

                }
                else if (response.IsSuccessStatusCode)
                {
                    string salt = response.Content.ReadAsAsync<string>().Result;
                    string hash = UIHelper.GenerateHash(txtLozinka.Text, salt);
                    Korisnik k = new Korisnik
                    {
                        Username = txtKorisnickoIme.Text,
                        LozinkaSalt = salt,
                        LozinkaHash = hash
                    };

                    HttpResponseMessage responseLogin = await servis.PostResponse("auth", k);
                    if (responseLogin.IsSuccessStatusCode)
                    {
                        k = responseLogin.Content.ReadAsAsync<Korisnik>().Result;
                        if (UserAccessControlHelper.Roles.Select(pair => pair.Key).Contains(k.UlogaKorisnikaID))
                        {
                            Global.PrijavljeniKorisnik = k;

                            DialogResult = DialogResult.OK;
                            imgLoader.Visible = false;
                            return;
                        }
                    }


                    CredentialsInvalid();
                    imgLoader.Visible = false;
                    return;
                }
            }
            catch(Exception ex)
            {
                // ne može se ostvarit konekcija... pusti nek prikaže general grešku
            }
            imgLoader.Visible = false;
            UIHelper.MessageGeneralGreska();
        }

        private static void CredentialsInvalid()
        {
            MessageBox.Show(Messages.login_user_invalid_credentials, Messages.greska_msg_title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void txtKorisnickoIme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Prijava(null, null);
        }

        private void txtLozinka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Prijava(null, null);
        }

        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
