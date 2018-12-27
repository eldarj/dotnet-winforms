using eDostava_API.Models;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static eRestoraniUI.Utils.KorisnikManagementHelper;

namespace eRestoraniUI.KorisniciForms
{
    public partial class UlogeManagement : Form
    {
        private Stack<bool> loaderImgStack = new Stack<bool>(); // Stack za prikazivanje/sakrivanje loader ikonice

        private WebApiHelper servis = new WebApiHelper("korisnici");
        private WebApiHelper servisUloge = new WebApiHelper("ulogekorisnika");

        private List<UlogeKorisnika_Result> SveUlogeKorisnikaList; // Pohrani sve uloge sa API-a ovdje

        private Dictionary<string, KorisnikListModel> Datasets; // Helper-Dictionary za definisanje list modela, koji čuvaju binding listu, source i tip uloge

        private List<Korisnici_Result> SviKorisniciList = new List<Korisnici_Result>(); // Originalna lista svih korisnika za provjeru kod pravljenja izmjena
        private List<Korisnici_Result> KorisniciToUpdate; // Lista korisnika za update (proslijedi ovo novoj formi)

        public UlogeManagement()
        {
            InitializeComponent();
        }

        private void UlogeManagement_Load(object sender, EventArgs e)
        {
            LoadEntireForm();
        }

        // Main loading -- izdvojeno u funkciju jer ponovo sve load-amo nakon što npr. sačuvamo izmjene
        private async void LoadEntireForm()
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            Datasets = new Dictionary<string, KorisnikListModel>();
            KorisniciToUpdate = new List<Korisnici_Result>();
            btnSaveChanges.Enabled = false;
            btnPonistiIzmjene.Enabled = false;
            //

            // Dohvati sve uloge sa API-a, pa onda kreiraj Datasets Helper-Dictionary za bind liste i source-ove
            HttpResponseMessage responseUloge = await servisUloge.GetResponse();
            if (responseUloge.IsSuccessStatusCode)
            {
                SveUlogeKorisnikaList = responseUloge.Content.ReadAsAsync<List<UlogeKorisnika_Result>>().Result;
                foreach (UlogeKorisnika_Result uloga in SveUlogeKorisnikaList)
                {
                    Datasets.Add(uloga.Uloga, new KorisnikListModel(uloga.UlogaKorisnikaID, uloga.Uloga));
                }
            }

            // Potom za svaki dataset inicijalizuj listu i source, pa onda zakači na odgovarajući ListBox
            foreach (KeyValuePair<string, KorisnikListModel> model in Datasets)
            {
                model.Value.BindingList = await GetApiKorisnici(model.Value.UlogaId);
                model.Value.BindingSource.DataSource = model.Value.BindingList;
            }
            BindListBox(listBoxNarucioci, Datasets["Narucilac"].BindingList, Datasets["Narucilac"].BindingSource);
            BindListBox(listBoxZaposlenici, Datasets["Zaposlenik"].BindingList, Datasets["Zaposlenik"].BindingSource);
            BindListBox(listBoxVlasnici, Datasets["Vlasnik"].BindingList, Datasets["Vlasnik"].BindingSource);
            BindListBox(listBoxAdministratori, Datasets["Administrator"].BindingList, Datasets["Administrator"].BindingSource);

            // Još samo dohvati sve korisnike s API-a za provjeru izmjena
            HttpResponseMessage response = await servis.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                SviKorisniciList = response.Content.ReadAsAsync<List<Korisnici_Result>>().Result;
            }
            updateCounterLabels();
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        // Dohvati korisnike sa API-a za različite uloge
        private async Task<BindingList<Korisnici_Result>> GetApiKorisnici(int korisnikUloga)
        {
            HttpResponseMessage response = await servis.GetResponse(new Dictionary<string, int>() { { "uloga", korisnikUloga } });
            if (response.IsSuccessStatusCode)
            {
                return new BindingList<Korisnici_Result>(response.Content.ReadAsAsync<List<Korisnici_Result>>().Result);
            }
            return null;
        }

        // Bindanje list box-ova na source-ove
        private void BindListBox(ListBox listbox, BindingList<Korisnici_Result> list, BindingSource source)
        {
            source.DataSource = list;
            listbox.DataSource = source;
            listbox.ValueMember = "KorisnikID";
            listbox.DisplayMember = "ImePrezime";
        }

        // Samo radi update labela
        private void updateCounterLabels()
        {
            lblUkupnoIzmjena.Text = String.Format(Messages.ukupno_sta_koliko, "izmjena", KorisniciToUpdate.Count);
            lblUkupnoAdministratori.Text = String.Format(Messages.ukupno_general, Datasets["Administrator"].ListCount);
            lblUkupnoZaposlenici.Text = String.Format(Messages.ukupno_general, Datasets["Zaposlenik"].ListCount);
            lblUkupnoNarucioci.Text = String.Format(Messages.ukupno_general, Datasets["Narucilac"].ListCount);
            lblUkupnoVlasnici.Text = String.Format(Messages.ukupno_general, Datasets["Vlasnik"].ListCount);
        }


        // Na Save click, otvori novu formu sa prikazanim izmjenama, gdje će admin potvrditi iste, te gdje pravimo API request-e za update (Put)
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            UlogeManagementChanges formaPotvrdiPromjene = new UlogeManagementChanges(KorisniciToUpdate);
            if (formaPotvrdiPromjene.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(ValidationMessages.uspjesno_napravljene_izmjene_body, ValidationMessages.uspjesno_napravljene_izmjene_title);
                LoadEntireForm();
            }
        }
        // Na poništi samo učitaj cijelu formu ponovo..
        private void btnPonistiIzmjene_Click(object sender, EventArgs e)
        {
            LoadEntireForm();
        }

        #region ManagementButtonClickHandlers
        // Korisnik <---> Zaposlenik
        private void btnNarucilacToZaposlenik_Click(object sender, EventArgs e)
        {
            userManagementHandler(listBoxNarucioci, Datasets["Narucilac"], Datasets["Zaposlenik"]);
        }
        private void btnZaposlenikToNarucilac_Click(object sender, EventArgs e)
        {
            userManagementHandler(listBoxZaposlenici, Datasets["Zaposlenik"], Datasets["Narucilac"]);
        }

        // Zaposlenik <--> Vlasnik
        private void btnZaposlenikToVlasnik_Click(object sender, EventArgs e)
        {
            userManagementHandler(listBoxZaposlenici, Datasets["Zaposlenik"], Datasets["Vlasnik"]);
        }
        private void btnVlasnikToZaposlenik_Click(object sender, EventArgs e)
        {
            userManagementHandler(listBoxVlasnici, Datasets["Vlasnik"], Datasets["Zaposlenik"]);
        }

        // Vlasnik <---> Administrator
        private void btnVlasnikToAdministrator_Click(object sender, EventArgs e)
        {
            userManagementHandler(listBoxVlasnici, Datasets["Vlasnik"], Datasets["Administrator"]);
        }
        private void btnAdministratorToVlasnik_Click(object sender, EventArgs e)
        {
            userManagementHandler(listBoxAdministratori, Datasets["Administrator"], Datasets["Vlasnik"]);
        }

        // Uzima Korisnik_Resul objekat iz odabrane liste, i uklanja odnosno ubacuje u odabranu grupu (list model)
        private void userManagementHandler(ListBox listBoxElement, KorisnikListModel ukloniIzGrupe, KorisnikListModel dodajUGrupu)
        {
            if (listBoxElement.SelectedItem != null)
            {
                Korisnici_Result k = (Korisnici_Result)listBoxElement.SelectedItem;
                ukloniIzGrupe.BindingList.Remove(k);
                dodajUGrupu.BindingList.Add(k);

                k.UlogaKorisnikaID = dodajUGrupu.UlogaId;
                k.Uloga = dodajUGrupu.UlogaNaziv;

                // Ako u listi za update, već postoji korisnik, ukloni ga ++
                if (KorisniciToUpdate.Where(x => x.KorisnikID == k.KorisnikID).SingleOrDefault() != null) 
                {
                    KorisniciToUpdate.Remove(k);
                }
                // ++ a dodaj ga ponovo samo ako je različit od početnog stanja (npr. vraćanje istog korisnika u originalnu grupu/ulogu)
                if (SviKorisniciList.Where(x => x.KorisnikID == k.KorisnikID && x.UlogaKorisnikaID == k.UlogaKorisnikaID).SingleOrDefault() == null)
                {
                    KorisniciToUpdate.Add(k);
                }

                // update sve labele i button-e
                updateCounterLabels();
                btnSaveChanges.Enabled = KorisniciToUpdate.Count > 0 ? true : false;
                btnPonistiIzmjene.Enabled = KorisniciToUpdate.Count > 0 ? true : false;
            }
        }
        #endregion

    }
}
