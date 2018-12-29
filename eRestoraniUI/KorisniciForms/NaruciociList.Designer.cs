namespace eRestoraniUI.KorisniciForms
{
    partial class NaruciociList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaruciociList));
            this.btnNarudzbe = new System.Windows.Forms.Button();
            this.cmbGradovi = new System.Windows.Forms.ComboBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNarucioci = new System.Windows.Forms.DataGridView();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRegistracije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupnoPotrosio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojNarudzbi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarucioci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNarudzbe
            // 
            this.btnNarudzbe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNarudzbe.Enabled = false;
            this.btnNarudzbe.Location = new System.Drawing.Point(990, 9);
            this.btnNarudzbe.Name = "btnNarudzbe";
            this.btnNarudzbe.Size = new System.Drawing.Size(94, 23);
            this.btnNarudzbe.TabIndex = 70;
            this.btnNarudzbe.Text = "Narudžbe";
            this.btnNarudzbe.UseVisualStyleBackColor = true;
            this.btnNarudzbe.Click += new System.EventHandler(this.btnNarudzbe_Click);
            // 
            // cmbGradovi
            // 
            this.cmbGradovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradovi.Enabled = false;
            this.cmbGradovi.FormattingEnabled = true;
            this.cmbGradovi.Location = new System.Drawing.Point(316, 6);
            this.cmbGradovi.Name = "cmbGradovi";
            this.cmbGradovi.Size = new System.Drawing.Size(121, 24);
            this.cmbGradovi.TabIndex = 69;
            this.cmbGradovi.SelectedIndexChanged += new System.EventHandler(this.cmbGradovi_SelectedIndexChanged);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Enabled = false;
            this.txtPretraga.Location = new System.Drawing.Point(85, 7);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(225, 22);
            this.txtPretraga.TabIndex = 66;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Pretraga:";
            // 
            // dgvNarucioci
            // 
            this.dgvNarucioci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNarucioci.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvNarucioci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarucioci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikID,
            this.Username,
            this.ImePrezime,
            this.Email,
            this.Adresa,
            this.Grad,
            this.DatumRegistracije,
            this.UkupnoPotrosio,
            this.BrojNarudzbi});
            this.dgvNarucioci.Location = new System.Drawing.Point(11, 36);
            this.dgvNarucioci.Name = "dgvNarucioci";
            this.dgvNarucioci.RowTemplate.Height = 24;
            this.dgvNarucioci.Size = new System.Drawing.Size(1154, 518);
            this.dgvNarucioci.TabIndex = 63;
            // 
            // imgLoader
            // 
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(443, 2);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 68;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // lblUkupno
            // 
            this.lblUkupno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(1025, 557);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(136, 17);
            this.lblUkupno.TabIndex = 64;
            this.lblUkupno.Text = "Ukupno naručioca: -";
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzbrisi.Enabled = false;
            this.btnIzbrisi.Location = new System.Drawing.Point(1090, 9);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 67;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.Visible = false;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // ImePrezime
            // 
            this.ImePrezime.DataPropertyName = "ImePrezime";
            this.ImePrezime.HeaderText = "Ime i prezime";
            this.ImePrezime.Name = "ImePrezime";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            // 
            // DatumRegistracije
            // 
            this.DatumRegistracije.DataPropertyName = "DatumRegistracije";
            this.DatumRegistracije.HeaderText = "Datum registracije";
            this.DatumRegistracije.Name = "DatumRegistracije";
            // 
            // UkupnoPotrosio
            // 
            this.UkupnoPotrosio.DataPropertyName = "UkupnoPotrosio";
            this.UkupnoPotrosio.HeaderText = "Ukupno potrošeno";
            this.UkupnoPotrosio.Name = "UkupnoPotrosio";
            // 
            // BrojNarudzbi
            // 
            this.BrojNarudzbi.DataPropertyName = "BrojNarudzbi";
            this.BrojNarudzbi.HeaderText = "Broj narudzbži";
            this.BrojNarudzbi.Name = "BrojNarudzbi";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(13, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(669, 17);
            this.label2.TabIndex = 71;
            this.label2.Text = "Za filtriranje po broju narudžbi, koristite \'<\' i \'>\'. Npr. \'>10\' filtrira naruči" +
    "oce sa 10 i više kreiranih narudžbi.";
            // 
            // NaruciociList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 579);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNarudzbe);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.cmbGradovi);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.imgLoader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNarucioci);
            this.Name = "NaruciociList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naručioci";
            this.Load += new System.EventHandler(this.NaruciociList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarucioci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNarudzbe;
        private System.Windows.Forms.ComboBox cmbGradovi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNarucioci;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumRegistracije;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupnoPotrosio;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojNarudzbi;
        private System.Windows.Forms.Label label2;
    }
}