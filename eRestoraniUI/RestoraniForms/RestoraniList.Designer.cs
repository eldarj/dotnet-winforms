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
            this.btnUcitajRestorane = new System.Windows.Forms.Button();
            this.dgvRestorani = new System.Windows.Forms.DataGridView();
            this.RestoranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimalnaCijenaNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNoviRestoran = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRestoranFilter = new System.Windows.Forms.TextBox();
            this.ucitajRestoraneBtn = new System.Windows.Forms.Button();
            this.btnJelovnik = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestorani)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUcitajRestorane
            // 
            this.btnUcitajRestorane.Location = new System.Drawing.Point(372, 6);
            this.btnUcitajRestorane.Name = "btnUcitajRestorane";
            this.btnUcitajRestorane.Size = new System.Drawing.Size(75, 23);
            this.btnUcitajRestorane.TabIndex = 0;
            this.btnUcitajRestorane.Text = "Traži";
            this.btnUcitajRestorane.UseVisualStyleBackColor = true;
            this.btnUcitajRestorane.Click += new System.EventHandler(this.btnUcitajRestorane_Click);
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
            this.Email,
            this.WebUrl,
            this.Telefon,
            this.MinimalnaCijenaNarudzbe});
            this.dgvRestorani.Location = new System.Drawing.Point(15, 35);
            this.dgvRestorani.Name = "dgvRestorani";
            this.dgvRestorani.RowTemplate.Height = 24;
            this.dgvRestorani.Size = new System.Drawing.Size(1208, 573);
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
            this.MinimalnaCijenaNarudzbe.HeaderText = "Minimalna cijena narudzbe";
            this.MinimalnaCijenaNarudzbe.Name = "MinimalnaCijenaNarudzbe";
            this.MinimalnaCijenaNarudzbe.ReadOnly = true;
            this.MinimalnaCijenaNarudzbe.Width = 187;
            // 
            // btnNoviRestoran
            // 
            this.btnNoviRestoran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoviRestoran.Location = new System.Drawing.Point(1117, 6);
            this.btnNoviRestoran.Name = "btnNoviRestoran";
            this.btnNoviRestoran.Size = new System.Drawing.Size(106, 23);
            this.btnNoviRestoran.TabIndex = 2;
            this.btnNoviRestoran.Text = "Novi restoran";
            this.btnNoviRestoran.UseVisualStyleBackColor = true;
            this.btnNoviRestoran.Click += new System.EventHandler(this.btnNoviRestoran_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pretraga:";
            // 
            // txtRestoranFilter
            // 
            this.txtRestoranFilter.Location = new System.Drawing.Point(85, 7);
            this.txtRestoranFilter.Name = "txtRestoranFilter";
            this.txtRestoranFilter.Size = new System.Drawing.Size(281, 22);
            this.txtRestoranFilter.TabIndex = 4;
            // 
            // ucitajRestoraneBtn
            // 
            this.ucitajRestoraneBtn.Location = new System.Drawing.Point(372, 25);
            this.ucitajRestoraneBtn.Name = "ucitajRestoraneBtn";
            this.ucitajRestoraneBtn.Size = new System.Drawing.Size(75, 23);
            this.ucitajRestoraneBtn.TabIndex = 0;
            this.ucitajRestoraneBtn.Text = "Traži";
            this.ucitajRestoraneBtn.UseVisualStyleBackColor = true;
            this.ucitajRestoraneBtn.Click += new System.EventHandler(this.btnUcitajRestorane_Click);
            // 
            // btnJelovnik
            // 
            this.btnJelovnik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJelovnik.Location = new System.Drawing.Point(874, 6);
            this.btnJelovnik.Name = "btnJelovnik";
            this.btnJelovnik.Size = new System.Drawing.Size(75, 23);
            this.btnJelovnik.TabIndex = 6;
            this.btnJelovnik.Text = "Jelovnik";
            this.btnJelovnik.UseVisualStyleBackColor = true;
            this.btnJelovnik.Click += new System.EventHandler(this.btnJelovnik_Click);
            // 
            // btnUredi
            // 
            this.btnUredi.Location = new System.Drawing.Point(1036, 6);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(75, 23);
            this.btnUredi.TabIndex = 7;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.btnUrediRestoran_Click);
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Location = new System.Drawing.Point(955, 6);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 8;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // RestoraniList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1235, 613);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.btnJelovnik);
            this.Controls.Add(this.txtRestoranFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNoviRestoran);
            this.Controls.Add(this.dgvRestorani);
            this.Controls.Add(this.btnUcitajRestorane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RestoraniList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restorani";
            this.Load += new System.EventHandler(this.RestoraniList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestorani)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUcitajRestorane;
        private System.Windows.Forms.DataGridView dgvRestorani;
        private System.Windows.Forms.Button btnNoviRestoran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRestoranFilter;
        private System.Windows.Forms.Button ucitajRestoraneBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestoranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimalnaCijenaNarudzbe;
        private System.Windows.Forms.Button btnJelovnik;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnIzbrisi;
    }
}

