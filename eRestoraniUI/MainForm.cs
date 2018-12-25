using eRestoraniUI.KorisniciForms;
using eRestoraniUI.LokacijeForms;
using eRestoraniUI.LokacijeForms;
using System;
using System.Windows.Forms;

namespace eRestoraniUI
{
    public partial class MainForm : Form
    {
        private static RestoraniList restoraniListForm;
        private static BlokoviList blokoviListForm;
        private static GradoviList gradoviListForm;
        private static KorisniciList korisniciForm;

        public MainForm()
        {
            InitializeComponent();
            Global.Mdi = this;

            // restoraniToolStripMenuItem_Click(null, null); // na init pokaži formu restorana
            blokoviToolStripMenuItem_Click(null, null); // na init pokaži formu restorana

            //this.Text = String.Format(this.Text, Global.PrijavljeniKorisnik.Username);
            this.Text = String.Format(this.Text, "eldarjahijagic");
        }

        private void restoraniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restoraniListForm == null || restoraniListForm.IsDisposed)
            {
                restoraniListForm = new RestoraniList();
            }
            restoraniListForm.MdiParent = this;
            restoraniListForm.Show();
        }

        private void blokoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (blokoviListForm == null || blokoviListForm.IsDisposed)
            {
                blokoviListForm = new BlokoviList();
                blokoviListForm.MdiParent = this;
                blokoviListForm.Show();
            } else
            {
                blokoviListForm.BringToFront();
            }
        }

        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gradoviListForm == null || gradoviListForm.IsDisposed)
            {
                gradoviListForm = new GradoviList();
                gradoviListForm.MdiParent = this;
                gradoviListForm.Show();
            } else
            {
                gradoviListForm.BringToFront();
            }

        }

        private void pregledKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (korisniciForm == null || korisniciForm.IsDisposed)
            {
                korisniciForm = new KorisniciList();
                korisniciForm.MdiParent = this;
                korisniciForm.Show();
            } else
            {
                korisniciForm.BringToFront();
            }
        }
    }
}
