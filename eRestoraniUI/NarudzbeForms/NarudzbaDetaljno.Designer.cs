namespace eRestoraniUI.NarudzbeForms
{
    partial class NarudzbaDetaljno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NarudzbaDetaljno));
            this.btnOk = new System.Windows.Forms.Button();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.dgvStavkeNarudzbe = new System.Windows.Forms.DataGridView();
            this.StavkaNarudzbeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HranaNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HranaCijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdresaFull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUkupnoStavki = new System.Windows.Forms.Label();
            this.lblZaposlenikPromijenioStatus = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.lblNarucilac = new System.Windows.Forms.Label();
            this.lblUkupnaCijena = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblSifra = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavkeNarudzbe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(784, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Nazad";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // imgLoader
            // 
            this.imgLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(840, 5);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 78;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // dgvStavkeNarudzbe
            // 
            this.dgvStavkeNarudzbe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStavkeNarudzbe.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvStavkeNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavkeNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StavkaNarudzbeID,
            this.HranaNaziv,
            this.HranaCijena,
            this.Kolicina,
            this.AdresaFull});
            this.dgvStavkeNarudzbe.Location = new System.Drawing.Point(5, 229);
            this.dgvStavkeNarudzbe.Name = "dgvStavkeNarudzbe";
            this.dgvStavkeNarudzbe.RowTemplate.Height = 24;
            this.dgvStavkeNarudzbe.Size = new System.Drawing.Size(866, 388);
            this.dgvStavkeNarudzbe.TabIndex = 79;
            // 
            // StavkaNarudzbeID
            // 
            this.StavkaNarudzbeID.DataPropertyName = "StavkaNarudzbeID";
            this.StavkaNarudzbeID.HeaderText = "StavkaNarudzbeID";
            this.StavkaNarudzbeID.Name = "StavkaNarudzbeID";
            this.StavkaNarudzbeID.Visible = false;
            // 
            // HranaNaziv
            // 
            this.HranaNaziv.DataPropertyName = "HranaNaziv";
            this.HranaNaziv.HeaderText = "Hrana";
            this.HranaNaziv.Name = "HranaNaziv";
            // 
            // HranaCijena
            // 
            this.HranaCijena.DataPropertyName = "HranaCijena";
            this.HranaCijena.HeaderText = "Jed. Cijena";
            this.HranaCijena.Name = "HranaCijena";
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Količina";
            this.Kolicina.Name = "Kolicina";
            // 
            // AdresaFull
            // 
            this.AdresaFull.DataPropertyName = "UkupnaCijena";
            this.AdresaFull.HeaderText = "Ukupno";
            this.AdresaFull.Name = "AdresaFull";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 26);
            this.label1.TabIndex = 80;
            this.label1.Text = "Šifra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-2, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 26);
            this.label2.TabIndex = 81;
            this.label2.Text = "Datum kreiranja";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-2, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 26);
            this.label4.TabIndex = 82;
            this.label4.Text = "Ukupna cijena";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(374, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 40);
            this.label3.TabIndex = 85;
            this.label3.Text = "Status stavke promijenio zaposlenik";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(425, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 26);
            this.label5.TabIndex = 84;
            this.label5.Text = "Adresa za dostavu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(425, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 26);
            this.label6.TabIndex = 83;
            this.label6.Text = "Naručilac";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(425, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 26);
            this.label7.TabIndex = 86;
            this.label7.Text = "Status";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-2, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 26);
            this.label8.TabIndex = 87;
            this.label8.Text = "Ukupno stavki";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUkupnoStavki
            // 
            this.lblUkupnoStavki.AutoSize = true;
            this.lblUkupnoStavki.Location = new System.Drawing.Point(134, 118);
            this.lblUkupnoStavki.Name = "lblUkupnoStavki";
            this.lblUkupnoStavki.Size = new System.Drawing.Size(13, 17);
            this.lblUkupnoStavki.TabIndex = 95;
            this.lblUkupnoStavki.Text = "-";
            // 
            // lblZaposlenikPromijenioStatus
            // 
            this.lblZaposlenikPromijenioStatus.AutoSize = true;
            this.lblZaposlenikPromijenioStatus.Location = new System.Drawing.Point(561, 144);
            this.lblZaposlenikPromijenioStatus.Name = "lblZaposlenikPromijenioStatus";
            this.lblZaposlenikPromijenioStatus.Size = new System.Drawing.Size(13, 17);
            this.lblZaposlenikPromijenioStatus.TabIndex = 94;
            this.lblZaposlenikPromijenioStatus.Text = "-";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(561, 35);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(13, 17);
            this.lblAdresa.TabIndex = 92;
            this.lblAdresa.Text = "-";
            // 
            // lblNarucilac
            // 
            this.lblNarucilac.AutoSize = true;
            this.lblNarucilac.Location = new System.Drawing.Point(561, 9);
            this.lblNarucilac.Name = "lblNarucilac";
            this.lblNarucilac.Size = new System.Drawing.Size(13, 17);
            this.lblNarucilac.TabIndex = 91;
            this.lblNarucilac.Text = "-";
            // 
            // lblUkupnaCijena
            // 
            this.lblUkupnaCijena.AutoSize = true;
            this.lblUkupnaCijena.Location = new System.Drawing.Point(134, 61);
            this.lblUkupnaCijena.Name = "lblUkupnaCijena";
            this.lblUkupnaCijena.Size = new System.Drawing.Size(37, 17);
            this.lblUkupnaCijena.TabIndex = 90;
            this.lblUkupnaCijena.Text = "- KM";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(134, 35);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(13, 17);
            this.lblDatum.TabIndex = 89;
            this.lblDatum.Text = "-";
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Location = new System.Drawing.Point(134, 9);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(13, 17);
            this.lblSifra.TabIndex = 88;
            this.lblSifra.Text = "-";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(562, 115);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbStatus.TabIndex = 96;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzvjestaj.Location = new System.Drawing.Point(693, 200);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(85, 23);
            this.btnIzvjestaj.TabIndex = 97;
            this.btnIzvjestaj.Text = "Izvještaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = true;
            this.btnIzvjestaj.Click += new System.EventHandler(this.btnIzvjestaj_Click);
            // 
            // NarudzbaDetaljno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(877, 622);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblUkupnoStavki);
            this.Controls.Add(this.lblZaposlenikPromijenioStatus);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.lblNarucilac);
            this.Controls.Add(this.lblUkupnaCijena);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStavkeNarudzbe);
            this.Controls.Add(this.imgLoader);
            this.Controls.Add(this.btnOk);
            this.Name = "NarudzbaDetaljno";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalji narudžbe";
            this.Load += new System.EventHandler(this.NarudzbaDetaljno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavkeNarudzbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.DataGridView dgvStavkeNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn StavkaNarudzbeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HranaNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn HranaCijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdresaFull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUkupnoStavki;
        private System.Windows.Forms.Label lblZaposlenikPromijenioStatus;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.Label lblNarucilac;
        private System.Windows.Forms.Label lblUkupnaCijena;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblSifra;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnIzvjestaj;
    }
}