using eDostava_API.Models;
using eRestoraniUI.KorisniciForms;
using eRestoraniUI.LokacijeForms;
using eRestoraniUI.NarudzbeForms;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace eRestoraniUI
{
    public partial class MainForm : Form
    {
        // disable "Field is never assigned and might be null" warning jer koristimo generičku funkciju za instanciranje ovih obj.
        #pragma warning disable 0649
        private static RestoraniList restoraniListForm;
        private static BlokoviList blokoviListForm;
        private static GradoviList gradoviListForm;
        private static KorisniciList korisniciForm;
        private static NaruciociList naruciociForm;
        private static UlogeManagement ulogeForm;
        private static ZaposleniciList zaposleniciForm;
        private static VlasniciList vlasniciForm;
        private static NarudzbeList narudzbeForm;
        #pragma warning restore 0649

        public MainForm()
        {
            InitializeComponent();
            Global.Mdi = this;

            //restoraniToolStripMenuItem_Click(null, null); // na init pokaži formu restorana

            this.Text = String.Format(this.Text, Global.PrijavljeniKorisnik.Username);
            //this.Text = String.Format(this.Text, "eldarjahijagic");
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = await new WebApiHelper("narudzbe").GetResponse(new Dictionary<string, int> { { "status", 1 } });
            if (response.IsSuccessStatusCode)
            {
                List<Narudzbe_Result> narudzbeNaCekanju = response.Content.ReadAsAsync<List<Narudzbe_Result>>().Result;
                int brn = narudzbeNaCekanju.Count;
                if (brn > 0)
                {
                    notifyIcon.ShowBalloonTip(4000, "Narudžbe na čekanju", "Imate " + brn + " narudžbi na čekanju!", ToolTipIcon.Info);
                }
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            DisplayForm(narudzbeForm);
        }

        #region ToolstripHandlers
        private void restoraniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(restoraniListForm);
        }

        private void blokoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(blokoviListForm);
        }

        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(gradoviListForm);
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(ulogeForm);
        }

        private void sviKorisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(korisniciForm);
        }

        private void naruciociToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(naruciociForm);
        }
        private void zaposleniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(zaposleniciForm);
        }

        private void vlasniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(vlasniciForm);
        }
        private void sveNarudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm(narudzbeForm);
        }
        // Skontaj kako od svih ovih click handler-a napravit jedan (možda koristi Tag property u toolstripmenu item-ima?
        #endregion

        // Za sve forme, kod otvaranja, prvo provjeri jel već postoji forma, da ne bi pravili duple prozore...
        private void DisplayForm<T>(T forma, bool bindToMdi = true) where T: new()
        {
            Form _forma = forma as Form;

            // ako ne postoji forma, kreiraj novu
            if (_forma == null || _forma.IsDisposed) 
            {
                _forma = new T() as Form; // moramo kreirati novi objekat forme, jer forma nije nikad instancirana

                if (bindToMdi)
                {
                    _forma.MdiParent = this;
                }
                _forma.Show();
            }
            // ako postoji, samo je prikaži
            else
            {
                _forma.BringToFront();
            }
        }
    }
}
