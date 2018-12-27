namespace eRestoraniUI.LokacijeForms
{
    partial class BlokoviList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlokoviList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.txtBlokNaziv = new System.Windows.Forms.TextBox();
            this.cmbGradovi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDivider = new System.Windows.Forms.Label();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnUredi = new System.Windows.Forms.Button();
            this.dgvBlokovi = new System.Windows.Forms.DataGridView();
            this.BlokID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivGrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNoviBlok = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlokovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPretraga);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lblDivider);
            this.splitContainer1.Panel2.Controls.Add(this.imgLoader);
            this.splitContainer1.Panel2.Controls.Add(this.btnIzbrisi);
            this.splitContainer1.Panel2.Controls.Add(this.lblUkupno);
            this.splitContainer1.Panel2.Controls.Add(this.btnUredi);
            this.splitContainer1.Panel2.Controls.Add(this.dgvBlokovi);
            this.splitContainer1.Panel2.Controls.Add(this.btnNoviBlok);
            this.splitContainer1.Size = new System.Drawing.Size(677, 618);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSacuvaj);
            this.panel1.Controls.Add(this.btnOdustani);
            this.panel1.Controls.Add(this.txtBlokNaziv);
            this.panel1.Controls.Add(this.cmbGradovi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 111);
            this.panel1.TabIndex = 4;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(200, 80);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 5;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(119, 80);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 4;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtBlokNaziv
            // 
            this.txtBlokNaziv.Location = new System.Drawing.Point(109, 9);
            this.txtBlokNaziv.Name = "txtBlokNaziv";
            this.txtBlokNaziv.Size = new System.Drawing.Size(166, 22);
            this.txtBlokNaziv.TabIndex = 2;
            this.txtBlokNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtBlokNaziv_Validating);
            // 
            // cmbGradovi
            // 
            this.cmbGradovi.FormattingEnabled = true;
            this.cmbGradovi.Location = new System.Drawing.Point(109, 37);
            this.cmbGradovi.Name = "cmbGradovi";
            this.cmbGradovi.Size = new System.Drawing.Size(166, 24);
            this.cmbGradovi.TabIndex = 3;
            this.cmbGradovi.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGradovi_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Naziv bloka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Pripada gradu";
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(82, 9);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(225, 22);
            this.txtPretraga.TabIndex = 12;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pretraga:";
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(0, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(680, 2);
            this.lblDivider.TabIndex = 55;
            // 
            // imgLoader
            // 
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(310, 5);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 54;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzbrisi.Location = new System.Drawing.Point(400, 8);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 14;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // lblUkupno
            // 
            this.lblUkupno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(532, 598);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(136, 17);
            this.lblUkupno.TabIndex = 1;
            this.lblUkupno.Text = "Ukupno blokova: {0}";
            // 
            // btnUredi
            // 
            this.btnUredi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUredi.Location = new System.Drawing.Point(481, 8);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(75, 23);
            this.btnUredi.TabIndex = 13;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
            // 
            // dgvBlokovi
            // 
            this.dgvBlokovi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBlokovi.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvBlokovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlokovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BlokID,
            this.Naziv,
            this.GradID,
            this.NazivGrada});
            this.dgvBlokovi.Location = new System.Drawing.Point(12, 40);
            this.dgvBlokovi.Name = "dgvBlokovi";
            this.dgvBlokovi.RowTemplate.Height = 24;
            this.dgvBlokovi.Size = new System.Drawing.Size(656, 557);
            this.dgvBlokovi.TabIndex = 0;
            // 
            // BlokID
            // 
            this.BlokID.DataPropertyName = "BlokID";
            this.BlokID.HeaderText = "BlokID";
            this.BlokID.Name = "BlokID";
            this.BlokID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Blok";
            this.Naziv.Name = "Naziv";
            // 
            // GradID
            // 
            this.GradID.DataPropertyName = "GradID";
            this.GradID.HeaderText = "GradID";
            this.GradID.Name = "GradID";
            this.GradID.Visible = false;
            // 
            // NazivGrada
            // 
            this.NazivGrada.DataPropertyName = "NazivGrada";
            this.NazivGrada.HeaderText = "Grad";
            this.NazivGrada.Name = "NazivGrada";
            // 
            // btnNoviBlok
            // 
            this.btnNoviBlok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoviBlok.Location = new System.Drawing.Point(562, 8);
            this.btnNoviBlok.Name = "btnNoviBlok";
            this.btnNoviBlok.Size = new System.Drawing.Size(106, 23);
            this.btnNoviBlok.TabIndex = 10;
            this.btnNoviBlok.Text = "Novi blok";
            this.btnNoviBlok.UseVisualStyleBackColor = true;
            this.btnNoviBlok.Click += new System.EventHandler(this.btnNoviBlok_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // BlokoviList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 618);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BlokoviList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlokoviList";
            this.Load += new System.EventHandler(this.BlokoviList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlokovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvBlokovi;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlokID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivGrada;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviBlok;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.TextBox txtBlokNaziv;
        private System.Windows.Forms.ComboBox cmbGradovi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblDivider;
    }
}