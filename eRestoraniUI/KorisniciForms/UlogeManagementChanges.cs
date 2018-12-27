using eDostava_API.Models;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eRestoraniUI.KorisniciForms
{
    public partial class UlogeManagementChanges : Form
    {
        private WebApiHelper servis = new WebApiHelper("korisnici");

        private Stack<bool> loaderImgStack = new Stack<bool>(); // Stack za prikazivanje/sakrivanje loader ikonice

        private List<Korisnici_Result> korisniciSaIzmjenama; // Lista svih korisnika čija uloga je promijenjena
        private List<string> listaIzmjena = new List<string>(); // Lista poruka koju ćemo prikazati adminu
        private List<string> listaNapomena = new List<string>(); // Lista napomena koju ćemo prikazati adminu (npr. naručilac je prebačen u vlasnike restorana, ali nema definisna restoran...)

        public UlogeManagementChanges(List<Korisnici_Result> KorisniciZaUpdate)
        {
            InitializeComponent();
            korisniciSaIzmjenama = KorisniciZaUpdate;
        }

        private void UlogeManagementChanges_Load(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            lblUkupnoIzmjena.Text = String.Format(Messages.ukupno_general, korisniciSaIzmjenama.Count);

            // Za svakog korisnika generiši poruku
            foreach (Korisnici_Result k in korisniciSaIzmjenama)
            {
                listaIzmjena.Add(String.Format(Messages.uloge_izmjene_pregled, k.ImePrezime, k.Uloga));
                if ((k.UlogaKorisnikaID == 1 || k.UlogaKorisnikaID == 2))
                {
                    listaNapomena.Add(String.Format(Messages.uloge_izmjene_napomene_def_restoran, "(ID" + k.KorisnikID + ") " + k.ImePrezime, k.Uloga));
                }
            }
            // Potom dodaj generisane poruke u listboxove
            listBoxIzmjene.DataSource = listaIzmjena;
            if (listaNapomena.Count > 0)
            {
                listBoxNapomene.DataSource = listaNapomena;
                splitContainer1.Panel2Collapsed = false; // prikaži ga samo ako lista napomena nije prazna
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        // Za svakog od korisnika, poslaće request na API /{korisnikid}/updaterole, ovaj endpoint je u API-u definisan striktno za update uloga
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            foreach (Korisnici_Result k in korisniciSaIzmjenama)
            {
                servis.PutResponse(k.KorisnikID, k, new List<string>() { "updaterole" });
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
            this.DialogResult = DialogResult.OK;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
