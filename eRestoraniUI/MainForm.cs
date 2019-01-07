using eDostava_API.Models;
using eRestoraniUI.HranaUI;
using eRestoraniUI.KorisniciForms;
using eRestoraniUI.LokacijeForms;
using eRestoraniUI.NarudzbeForms;
using eRestoraniUI.RestoraniUI;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace eRestoraniUI
{
    public partial class MainForm : Form
    {
        // supress "Field is never assigned and might be null" warning jer koristimo generičku funkciju za instanciranje ovih obj.
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

        private List<Narudzbe_Result> narudzbeNaCekanju = new List<Narudzbe_Result>();
        private List<Restorani_Result> restorani = new List<Restorani_Result>();

        public MainForm()
        {
            InitializeComponent();
            Global.Mdi = this;

            restoraniToolStripMenuItem_Click(null, null); // na init pokaži formu restorana
            this.Text = String.Format(this.Text, Global.PrijavljeniKorisnik.Username);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (!UserAccessControlHelper.AdminRights)
            {
                HandleUIForNonadmin();
            }
            else
            {
                fileToolStripMenuItem.Text = "Restorani";

                sveNarudžbeToolStripMenuItem.Visible = true;
                lokacijeToolStripMenuItem.Visible = true;
                korisniciToolStripMenuItem.Visible = true;

                jelovniciToolStripMenuItem.Visible = false;
            }


            // Generate notify baloon
            HttpResponseMessage response = await new WebApiHelper("narudzbe").GetResponse(new Dictionary<string, int> { { "status", 1 } });
            if (response.IsSuccessStatusCode)
                narudzbeNaCekanju.AddRange(response.Content.ReadAsAsync<List<Narudzbe_Result>>().Result);

            if (narudzbeNaCekanju.Count > 0 && UserAccessControlHelper.AdminRights)
                notifyIcon.ShowBalloonTip(4000, "Narudžbe na čekanju", "Imate " + narudzbeNaCekanju.Count + " narudžbi na čekanju!", ToolTipIcon.Info);
        }

        #region OtherHandlers

        private async void HandleUIForNonadmin()
        {
            List<ToolStripMenuItem> narudzbaDropdown = new List<ToolStripMenuItem>();
            restorani = await Global.LoadApiKorisnikRestorani();

            Dictionary<string, List<Restorani_Result>> gradRestoraniDict = restorani.DistinctBy(rx => rx.GradNaziv).ToList()
                .ToDictionary(r => r.GradNaziv, r => restorani.Where(x => x.GradNaziv == r.GradNaziv).ToList());

            // GENERIŠI DROPDOWNE ZA VLASNIKE I ZAPOSLENIKE
            foreach (var pair in gradRestoraniDict)
            {
                ToolStripMenuItem restoraniGradItem = new ToolStripMenuItem { Text = pair.Key };
                ToolStripMenuItem narudzbeGradItem = new ToolStripMenuItem { Text = pair.Key };

                foreach (Restorani_Result restoran in pair.Value)
                {
                    // GENERIŠI RESTORANI-DROPDOWN
                    ToolStripMenuItem restoranItem = new ToolStripMenuItem { Text = "Restoran " + restoran.Naziv };
                    restoranItem.Click += (Object _sender, EventArgs _args) =>
                            Handle_DynamicToolstripItem_Click<HranaList, Restorani_Result>(restoran, _sender, _args);
                    restoraniGradItem.DropDownItems.Add(restoranItem);

                    // GENERIŠI NARUDŽBE-DROPDOWN
                    ToolStripMenuItem narudzbaItem = new ToolStripMenuItem { Text = "Narudžbe restorana " + restoran.Naziv, };
                    narudzbaItem.Click += (Object _sender, EventArgs _args) =>
                            Handle_DynamicToolstripItem_Click<NarudzbeList, Restorani_Result>(restoran, _sender, _args);
                    narudzbeGradItem.DropDownItems.Add(narudzbaItem);
                }

                jelovniciToolStripMenuItem.DropDownItems.Add(restoraniGradItem);
                narudžbeToolStripMenuItem.DropDownItems.Add(narudzbeGradItem);
            }
        }

        private void Handle_DynamicToolstripItem_Click<F, T>(T passingObject, object sender, EventArgs e)
        {
            ToolStripMenuItem clicked = (ToolStripMenuItem)sender;
            Form _f = (F)Activator.CreateInstance(typeof(F), new object[] { passingObject }) as Form; 
            _f.MdiParent = this;
            _f.Show();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            narudzbeForm = DisplayForm(narudzbeForm) as NarudzbeList;
        }
        #endregion

        #region ToolstripHandlers
        private void restoraniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restoraniListForm = DisplayForm(restoraniListForm) as RestoraniList;
        }

        private void blokoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blokoviListForm = DisplayForm(blokoviListForm) as BlokoviList;
        }

        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradoviListForm = DisplayForm(gradoviListForm) as GradoviList;
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ulogeForm = DisplayForm(ulogeForm) as UlogeManagement;
        }

        private void sviKorisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            korisniciForm = DisplayForm(korisniciForm) as KorisniciList;
        }

        private void naruciociToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naruciociForm = DisplayForm(naruciociForm) as NaruciociList;
        }
        private void zaposleniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaposleniciForm = DisplayForm(zaposleniciForm) as ZaposleniciList;
        }

        private void vlasniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vlasniciForm = DisplayForm(vlasniciForm) as VlasniciList;
        }
        private void sveNarudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            narudzbeForm = DisplayForm(narudzbeForm) as NarudzbeList;
        }
        // Skontaj kako od svih ovih click handler-a napravit jedan (možda koristi Tag property u toolstripmenu item-ima?
        #endregion

        // Za sve forme, kod otvaranja, prvo provjeri jel već postoji forma, da ne bi pravili duple prozore...
        private Form DisplayForm<T>(T forma, bool bindToMdi = true) where T: new()
        {
            Form _forma = forma as Form;

            // ako ne postoji forma, kreiraj novu instancu
            if (_forma == null || _forma.IsDisposed) 
            {
                _forma = new T() as Form;

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

            return _forma; // vrati formu da bismo je mogli čuvati kao static instancu
        }
    }
}
