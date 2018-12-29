namespace eRestoraniUI
{
    partial class RestoraniList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoraniList));
            this.dgvRestorani = new System.Windows.Forms.DataGridView();
            this.RestoranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimalnaCijenaNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRestoranFilter = new System.Windows.Forms.TextBox();
            this.ucitajRestoraneBtn = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.cmbStatusi = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.noviRestoranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViseJelovnik = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViseNarudzbe = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVise = new eRestoraniUI.CustomControls.ButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestorani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRestorani
            // 
            this.dgvRestorani.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRestorani.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRestorani.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvRestorani.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvRestorani.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRestorani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestorani.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RestoranID,
            this.Sifra,
            this.Naziv,
            this.Adresa,
            this.Email,
            this.WebUrl,
            this.Telefon,
            this.MinimalnaCijenaNarudzbe,
            this.Status});
            this.dgvRestorani.Location = new System.Drawing.Point(9, 38);
            this.dgvRestorani.Name = "dgvRestorani";
            this.dgvRestorani.RowTemplate.Height = 24;
            this.dgvRestorani.Size = new System.Drawing.Size(1298, 605);
            this.dgvRestorani.TabIndex = 1;
            // 
            // RestoranID
            // 
            this.RestoranID.DataPropertyName = "RestoranID";
            this.RestoranID.HeaderText = "RestoranID";
            this.RestoranID.Name = "RestoranID";
            this.RestoranID.Visible = false;
            this.RestoranID.Width = 108;
            // 
            // Sifra
            // 
            this.Sifra.DataPropertyName = "Sifra";
            this.Sifra.HeaderText = "Sifra";
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            this.Sifra.Width = 66;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 72;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "AdresaFull";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.Width = 82;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 71;
            // 
            // WebUrl
            // 
            this.WebUrl.DataPropertyName = "WebUrl";
            this.WebUrl.HeaderText = "Web stranica";
            this.WebUrl.Name = "WebUrl";
            this.WebUrl.ReadOnly = true;
            this.WebUrl.Width = 110;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            this.Telefon.Width = 85;
            // 
            // MinimalnaCijenaNarudzbe
            // 
            this.MinimalnaCijenaNarudzbe.DataPropertyName = "MinimalnaCijenaNarudzbe";
            this.MinimalnaCijenaNarudzbe.HeaderText = "Min. cijena narudžbe";
            this.MinimalnaCijenaNarudzbe.Name = "MinimalnaCijenaNarudzbe";
            this.MinimalnaCijenaNarudzbe.ReadOnly = true;
            this.MinimalnaCijenaNarudzbe.Width = 154;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "StatusNaziv";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pretraga:";
            // 
            // txtRestoranFilter
            // 
            this.txtRestoranFilter.Enabled = false;
            this.txtRestoranFilter.Location = new System.Drawing.Point(79, 7);
            this.txtRestoranFilter.Name = "txtRestoranFilter";
            this.txtRestoranFilter.Size = new System.Drawing.Size(281, 22);
            this.txtRestoranFilter.TabIndex = 4;
            this.txtRestoranFilter.TextChanged += new System.EventHandler(this.txtRestoranFilter_TextChanged);
            // 
            // ucitajRestoraneBtn
            // 
            this.ucitajRestoraneBtn.Location = new System.Drawing.Point(372, 25);
            this.ucitajRestoraneBtn.Name = "ucitajRestoraneBtn";
            this.ucitajRestoraneBtn.Size = new System.Drawing.Size(75, 23);
            this.ucitajRestoraneBtn.TabIndex = 0;
            this.ucitajRestoraneBtn.Text = "Traži";
            this.ucitajRestoraneBtn.UseVisualStyleBackColor = true;
            // 
            // btnUredi
            // 
            this.btnUredi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUredi.Enabled = false;
            this.btnUredi.Location = new System.Drawing.Point(1144, 6);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(75, 23);
            this.btnUredi.TabIndex = 7;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.btnUrediRestoran_Click);
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzbrisi.Enabled = false;
            this.btnIzbrisi.Location = new System.Drawing.Point(1063, 6);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 8;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // imgLoader
            // 
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(493, 2);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 78;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // lblUkupno
            // 
            this.lblUkupno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(7, 646);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(131, 17);
            this.lblUkupno.TabIndex = 79;
            this.lblUkupno.Text = "Ukupno restorana -";
            // 
            // cmbStatusi
            // 
            this.cmbStatusi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusi.Enabled = false;
            this.cmbStatusi.FormattingEnabled = true;
            this.cmbStatusi.Location = new System.Drawing.Point(366, 6);
            this.cmbStatusi.Name = "cmbStatusi";
            this.cmbStatusi.Size = new System.Drawing.Size(121, 24);
            this.cmbStatusi.TabIndex = 80;
            this.cmbStatusi.SelectedIndexChanged += new System.EventHandler(this.cmbStatusi_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviRestoranToolStripMenuItem,
            this.btnViseJelovnik,
            this.btnViseNarudzbe});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 76);
            // 
            // noviRestoranToolStripMenuItem
            // 
            this.noviRestoranToolStripMenuItem.Name = "noviRestoranToolStripMenuItem";
            this.noviRestoranToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.noviRestoranToolStripMenuItem.Text = "Novi restoran";
            this.noviRestoranToolStripMenuItem.Click += new System.EventHandler(this.btnNoviRestoran_Click);
            // 
            // btnViseJelovnik
            // 
            this.btnViseJelovnik.Name = "btnViseJelovnik";
            this.btnViseJelovnik.Size = new System.Drawing.Size(167, 24);
            this.btnViseJelovnik.Text = "Jelovnik";
            this.btnViseJelovnik.Click += new System.EventHandler(this.btnJelovnik_Click);
            // 
            // btnViseNarudzbe
            // 
            this.btnViseNarudzbe.Name = "btnViseNarudzbe";
            this.btnViseNarudzbe.Size = new System.Drawing.Size(167, 24);
            this.btnViseNarudzbe.Text = "Narudžbe";
            this.btnViseNarudzbe.Click += new System.EventHandler(this.btnNarudzbe_Click);
            // 
            // btnVise
            // 
            this.btnVise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVise.Location = new System.Drawing.Point(1225, 7);
            this.btnVise.Menu = this.contextMenuStrip1;
            this.btnVise.Name = "btnVise";
            this.btnVise.Size = new System.Drawing.Size(77, 23);
            this.btnVise.TabIndex = 81;
            this.btnVise.Text = "Više";
            this.btnVise.UseVisualStyleBackColor = true;
            // 
            // RestoraniList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1314, 664);
            this.Controls.Add(this.btnVise);
            this.Controls.Add(this.cmbStatusi);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.imgLoader);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.txtRestoranFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRestorani);
            this.Name = "RestoraniList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restorani";
            this.Load += new System.EventHandler(this.RestoraniList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestorani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvRestorani;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRestoranFilter;
        private System.Windows.Forms.Button ucitajRestoraneBtn;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestoranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimalnaCijenaNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ComboBox cmbStatusi;
        private CustomControls.ButtonList btnVise;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnViseJelovnik;
        private System.Windows.Forms.ToolStripMenuItem btnViseNarudzbe;
        private System.Windows.Forms.ToolStripMenuItem noviRestoranToolStripMenuItem;
    }
}

