using eDostava_API.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.Reports
{
    public partial class ReportViewForm : Form
    {
        public Narudzbe_Result narudzbaStavkeNarudzbe { get; set; } = null;
        public List<Narudzbe_Result> narudzbePoGradovima { get; set; } = null;
        public string statusiNarudzbi { get; set; } = "-";

        public ReportViewForm()
        {
            InitializeComponent();
        }

        private void ReportViewForm_Load(object sender, EventArgs e)
        {
            if (narudzbaStavkeNarudzbe != null)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "eRestoraniUI.Reports.NarudzbaDetails.rdlc";

                ReportDataSource rds = new ReportDataSource("dsStavkeNarudzbi", narudzbaStavkeNarudzbe.StavkeNarudzbe);
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Sifra", narudzbaStavkeNarudzbe.Sifra.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Narucilac", narudzbaStavkeNarudzbe.Narucilac));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Adresa", narudzbaStavkeNarudzbe.AdresaFull));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("UkupnaCijena", String.Format("{0} KM", narudzbaStavkeNarudzbe.UkupnaCijena.ToString("0.00"))));

                this.reportViewer1.RefreshReport();
            }
            else if(narudzbePoGradovima != null)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "eRestoraniUI.Reports.NarudzbeGradovi.rdlc";

                ReportDataSource rds = new ReportDataSource("dsNarudzbeGradovi", narudzbePoGradovima);
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Statusi", statusiNarudzbi));

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
