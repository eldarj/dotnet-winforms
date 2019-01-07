using eDostava_API.Models;
using eRestoraniUI.Reports;
using eRestoraniUI.ResourceMessages;
using eRestoraniUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.NarudzbeForms
{
    public partial class NarudzbaDetaljno : Form
    {
        private WebApiHelper servisNarudzbe = new WebApiHelper("narudzbe");

        // Stack; handle the loading spinner image
        private Stack<bool> loaderImgStack = new Stack<bool>();

        private int narudzbaId;
        private Narudzbe_Result narudzba;
        private BindingList<StavkeNarudzbe_Result> dgvBindingList;
        private BindingSource dgvBindingSource = new BindingSource();

        bool statusChanged = false;

        public NarudzbaDetaljno(int id)
        {
            narudzbaId = id;

            InitializeComponent();
            dgvStavkeNarudzbe.AutoGenerateColumns = false;
        }

        private void NarudzbaDetaljno_Load(object sender, EventArgs e)
        {
            BindMainGridAndDetails();
        }

        private async void BindMainGridAndDetails(bool recheckPretraga = false)
        {
            UIHelper.LoaderImgStackDisplay(ref imgLoader, ref loaderImgStack);
            HttpResponseMessage response = await servisNarudzbe.GetResponse(Convert.ToString(narudzbaId));
            if (response.IsSuccessStatusCode)
            {
                narudzba = await response.Content.ReadAsAsync<Narudzbe_Result>();
                // Bind narudzba details
                lblSifra.Text = narudzba.Sifra.ToString();
                lblDatum.Text = narudzba.DatumVrijeme.ToString("dd.MM.yyyy");
                lblUkupnaCijena.Text = String.Format("{0} KM", narudzba.UkupnaCijena.ToString("0.00"));
                lblUkupnoStavki.Text = Convert.ToString(narudzba.StavkeNarudzbe.Count());
                lblNarucilac.Text = narudzba.Narucilac;
                lblAdresa.Text = narudzba.AdresaFull;
                lblZaposlenikPromijenioStatus.Text = narudzba.StatusPromijenioZaposlenik.ToString();

                // Bind stavke grid
                dgvBindingList = new BindingList<StavkeNarudzbe_Result>(narudzba.StavkeNarudzbe);
                dgvBindingSource.DataSource = dgvBindingList;

                dgvStavkeNarudzbe.DataSource = dgvBindingSource;
            }
            HttpResponseMessage responseStatusi = await servisNarudzbe.GetResponse("statusi");
            if (responseStatusi.IsSuccessStatusCode)
            {
                List<NarudzbeStatusi_Result> statusi = responseStatusi.Content.ReadAsAsync<List<NarudzbeStatusi_Result>>().Result;
                cmbStatus.DataSource = statusi;
                cmbStatus.ValueMember = "NarudzbaStatusID";
                cmbStatus.DisplayMember = "Naziv";

                cmbStatus.SelectedValue = narudzba.NarudzbaStatusID;

                //enable controls
                cmbStatus.Enabled = true;
            }
            UIHelper.LoaderImgStackHide(ref imgLoader, ref loaderImgStack);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (statusChanged)
            {
                narudzba.NarudzbaStatusID = ((NarudzbeStatusi_Result)cmbStatus.SelectedItem).NarudzbaStatusID;
                // narudzba.StatusPromijenioZaposlenikID = Global.PrijavljeniKorisnik.KorisnikID;

                HttpResponseMessage response = servisNarudzbe.PutResponse(narudzba.NarudzbaID, narudzba);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(Messages.uspjesno_napravljene_izmjene_body,
                        Messages.uspjeh_save_title);

                    DialogResult = DialogResult.OK;
                    Close();
                } else
                {
                    MessageBox.Show(Messages.greska_msg_pokusaj_ponovo,
                        Messages.greska_msg_title);
                }
            } else
            {
                this.Close();
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusChanged = ((NarudzbeStatusi_Result)cmbStatus.SelectedItem).NarudzbaStatusID != narudzba.NarudzbaStatusID;
            if (statusChanged)
            {
                btnOk.Text = "Sačuvaj";
            } else
            {
                btnOk.Text = "Nazad";
            }
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            ReportViewForm f = new ReportViewForm();
            f.narudzbaStavkeNarudzbe = this.narudzba;
            f.Show();
        }
    }
}
