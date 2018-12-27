using eRestoraniUI.KorisniciForms;
using eRestoraniUI.LokacijeForms;
using System;
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
        private static KorisniciList naruciociForm;
        private static UlogeManagement ulogeForm;
        private static Zaposlenici zaposleniciForm;
        private static VlasniciList vlasniciForm;
        #pragma warning restore 0649

        public MainForm()
        {
            InitializeComponent();
            Global.Mdi = this;

            // restoraniToolStripMenuItem_Click(null, null); // na init pokaži formu restorana
            restoraniToolStripMenuItem_Click(null, null); // na init pokaži formu restorana

            //this.Text = String.Format(this.Text, Global.PrijavljeniKorisnik.Username);
            this.Text = String.Format(this.Text, "eldarjahijagic");
        }


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

        private void naručiociToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naruciociForm = new KorisniciList(ulogaKorisnika: 3);
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
        // Skontaj kako od svih ovih click handler-a napravit jedan (možda koristi Tag property u toolstripmenu item-ima?

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
