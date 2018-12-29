namespace eRestoraniUI.NarudzbeForms
{
    partial class NarudzbeList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NarudzbeList));
            this.label2 = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.cmbStatusi = new System.Windows.Forms.ComboBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNarudzbe = new System.Windows.Forms.DataGridView();
            this.NarudzbaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narucilac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdresaFull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupnaCijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusPromijenioZaposlenik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(11, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(650, 17);
            this.label2.TabIndex = 80;
            this.label2.Text = "Za filtriranje po cijeni narudžbe, koristite \'<\' i \'>\'. Npr. \'>10\' filtrira narud" +
    "žbe sa cijenom od 10 KM i više.";
            // 
            // lblUkupno
            // 
            this.lblUkupno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(1023, 558);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(129, 17);
            this.lblUkupno.TabIndex = 73;
            this.lblUkupno.Text = "Ukupno narudžbi: -";
            // 
            // imgLoader
            // 
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(441, 3);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 77;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzbrisi.Enabled = false;
            this.btnIzbrisi.Location = new System.Drawing.Point(1088, 10);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 76;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // cmbStatusi
            // 
            this.cmbStatusi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusi.Enabled = false;
            this.cmbStatusi.FormattingEnabled = true;
            this.cmbStatusi.Location = new System.Drawing.Point(314, 7);
            this.cmbStatusi.Name = "cmbStatusi";
            this.cmbStatusi.Size = new System.Drawing.Size(121, 24);
            this.cmbStatusi.TabIndex = 78;
            this.cmbStatusi.SelectedIndexChanged += new System.EventHandler(this.cmbStatusi_SelectedIndexChanged);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Enabled = false;
            this.txtPretraga.Location = new System.Drawing.Point(83, 8);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(225, 22);
            this.txtPretraga.TabIndex = 75;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "Pretraga:";
            // 
            // dgvNarudzbe
            // 
            this.dgvNarudzbe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNarudzbe.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaID,
            this.Sifra,
            this.DatumVrijeme,
            this.Narucilac,
            this.AdresaFull,
            this.UkupnaCijena,
            this.StatusNarudzbe,
            this.StatusPromijenioZaposlenik});
            this.dgvNarudzbe.Location = new System.Drawing.Point(9, 37);
            this.dgvNarudzbe.Name = "dgvNarudzbe";
            this.dgvNarudzbe.RowTemplate.Height = 24;
            this.dgvNarudzbe.Size = new System.Drawing.Size(1154, 518);
            this.dgvNarudzbe.TabIndex = 72;
            // 
            // NarudzbaID
            // 
            this.NarudzbaID.DataPropertyName = "NarudzbaID";
            this.NarudzbaID.HeaderText = "NarudzbaID";
            this.NarudzbaID.Name = "NarudzbaID";
            this.NarudzbaID.Visible = false;
            // 
            // Sifra
            // 
            this.Sifra.DataPropertyName = "Sifra";
            this.Sifra.HeaderText = "Šifra";
            this.Sifra.Name = "Sifra";
            // 
            // DatumVrijeme
            // 
            this.DatumVrijeme.DataPropertyName = "DatumVrijeme";
            this.DatumVrijeme.HeaderText = "Vrijeme naručivanja";
            this.DatumVrijeme.Name = "DatumVrijeme";
            // 
            // Narucilac
            // 
            this.Narucilac.DataPropertyName = "Narucilac";
            this.Narucilac.HeaderText = "Naručio";
            this.Narucilac.Name = "Narucilac";
            // 
            // AdresaFull
            // 
            this.AdresaFull.DataPropertyName = "AdresaFull";
            this.AdresaFull.HeaderText = "Dostava na";
            this.AdresaFull.Name = "AdresaFull";
            // 
            // UkupnaCijena
            // 
            this.UkupnaCijena.DataPropertyName = "UkupnaCijena";
            this.UkupnaCijena.HeaderText = "Cijena";
            this.UkupnaCijena.Name = "UkupnaCijena";
            // 
            // StatusNarudzbe
            // 
            this.StatusNarudzbe.DataPropertyName = "StatusNarudzbe";
            this.StatusNarudzbe.HeaderText = "Status";
            this.StatusNarudzbe.Name = "StatusNarudzbe";
            // 
            // StatusPromijenioZaposlenik
            // 
            this.StatusPromijenioZaposlenik.DataPropertyName = "StatusPromijenioZaposlenik";
            this.StatusPromijenioZaposlenik.HeaderText = "Uredio zaposlenik";
            this.StatusPromijenioZaposlenik.Name = "StatusPromijenioZaposlenik";
            // 
            // NarudzbeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 579);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.imgLoader);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.cmbStatusi);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNarudzbe);
            this.Name = "NarudzbeList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Narudžbe";
            this.Load += new System.EventHandler(this.NarudzbeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.ComboBox cmbStatusi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narucilac;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdresaFull;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupnaCijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusPromijenioZaposlenik;
    }
}