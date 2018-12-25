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
        private WebApiHelper servis = new WebApiHelper("http://localhost:58299", "auth");

        public LoginForm()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prijava(object sender, EventArgs e)
        {
            // validate input
            if (txtKorisnickoIme.Text.Length < 1 || txtLozinka.Text.Length < 1)
            {
                MessageBox.Show("Unesite polja!",
                "Upozorenje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }

            HttpResponseMessage response = servis.GetResponse(txtKorisnickoIme.Text).Result;

            // check for any api issues
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                UIHelper.MessageOnApiError(response);
                return;

            } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                CredentialsInvalid();
                return;

            } else if (response.IsSuccessStatusCode)
            {
                Korisnik k = response.Content.ReadAsAsync<Korisnik>().Result;
                if (k.LozinkaHash == UIHelper.GenerateHash(txtLozinka.Text, k.LozinkaSalt))
                {
                    DialogResult = DialogResult.OK;
                    Global.PrijavljeniKorisnik = k;
                } else
                {
                    CredentialsInvalid();
                }
                return;
            }

            UIHelper.MessageGeneralGreska();
        }

        private static void CredentialsInvalid()
        {
            MessageBox.Show(Messages.login_user_fail,
                "Upozorenje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
