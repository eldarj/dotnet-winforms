namespace eRestoraniUI.RestoraniUI
{
    partial class RestoraniEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoraniEdit));
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWebUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDivider = new System.Windows.Forms.Label();
            this.txtMaskMinCijena = new System.Windows.Forms.MaskedTextBox();
            this.pictureBoxSlika = new System.Windows.Forms.PictureBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtSlikaName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.cmbBlokoviGradovi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTrenutniStatus = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbStatusi = new System.Windows.Forms.ComboBox();
            this.lblVecDodanZaposlenik = new System.Windows.Forms.Label();
            this.cmbZaposlenici = new System.Windows.Forms.ComboBox();
            this.btnUkloniZaposlenika = new System.Windows.Forms.Button();
            this.listBoxZaposlenici = new System.Windows.Forms.ListBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDodajZaposlenika = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.lblVecDodanVlasnik = new System.Windows.Forms.Label();
            this.btnDodajVlasnika = new System.Windows.Forms.Button();
            this.cmbVlasnici = new System.Windows.Forms.ComboBox();
            this.btnUkloniVlasnika = new System.Windows.Forms.Button();
            this.listBoxVlasnici = new System.Windows.Forms.ListBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlika)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(141, 74);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(230, 22);
            this.txtNaziv.TabIndex = 0;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.inputNaziv_Validating);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Naziv";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Opis";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(141, 102);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(230, 62);
            this.txtOpis.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(4, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Web Url";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtWebUrl
            // 
            this.txtWebUrl.Location = new System.Drawing.Point(141, 198);
            this.txtWebUrl.Name = "txtWebUrl";
            this.txtWebUrl.Size = new System.Drawing.Size(230, 22);
            this.txtWebUrl.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Email";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(141, 170);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 22);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.inputEmail_Validating);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(4, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 49);
            this.label11.TabIndex = 11;
            this.label11.Text = "Minimalna cijena narudžbe";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(4, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Telefon";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Osnovni podaci";
            // 
            // txtMaskTelefon
            // 
            this.txtMaskTelefon.Location = new System.Drawing.Point(141, 226);
            this.txtMaskTelefon.Mask = "(000) 000 - 000";
            this.txtMaskTelefon.Name = "txtMaskTelefon";
            this.txtMaskTelefon.Size = new System.Drawing.Size(104, 22);
            this.txtMaskTelefon.TabIndex = 14;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(-7, 33);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(725, 2);
            this.lblDivider.TabIndex = 35;
            // 
            // txtMaskMinCijena
            // 
            this.txtMaskMinCijena.Location = new System.Drawing.Point(141, 254);
            this.txtMaskMinCijena.Mask = "00.00  KM";
            this.txtMaskMinCijena.Name = "txtMaskMinCijena";
            this.txtMaskMinCijena.Size = new System.Drawing.Size(104, 22);
            this.txtMaskMinCijena.TabIndex = 36;
            // 
            // pictureBoxSlika
            // 
            this.pictureBoxSlika.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSlika.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.pictureBoxSlika.Location = new System.Drawing.Point(455, 74);
            this.pictureBoxSlika.Name = "pictureBoxSlika";
            this.pictureBoxSlika.Size = new System.Drawing.Size(220, 220);
            this.pictureBoxSlika.TabIndex = 81;
            this.pictureBoxSlika.TabStop = false;
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(141, 46);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.ReadOnly = true;
            this.txtSifra.Size = new System.Drawing.Size(230, 22);
            this.txtSifra.TabIndex = 77;
            // 
            // txtSlikaName
            // 
            this.txtSlikaName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSlikaName.Location = new System.Drawing.Point(452, 46);
            this.txtSlikaName.Name = "txtSlikaName";
            this.txtSlikaName.ReadOnly = true;
            this.txtSlikaName.Size = new System.Drawing.Size(187, 22);
            this.txtSlikaName.TabIndex = 74;
            this.txtSlikaName.Text = "Odaberite sliku...";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(51, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 79;
            this.label4.Text = "Šifra";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(384, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 80;
            this.label13.Text = "Slika";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(4, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 17);
            this.label12.TabIndex = 83;
            this.label12.Text = "Adresa";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(141, 377);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(230, 22);
            this.txtAdresa.TabIndex = 82;
            // 
            // cmbBlokoviGradovi
            // 
            this.cmbBlokoviGradovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlokoviGradovi.Enabled = false;
            this.cmbBlokoviGradovi.FormattingEnabled = true;
            this.cmbBlokoviGradovi.Location = new System.Drawing.Point(141, 408);
            this.cmbBlokoviGradovi.Name = "cmbBlokoviGradovi";
            this.cmbBlokoviGradovi.Size = new System.Drawing.Size(184, 24);
            this.cmbBlokoviGradovi.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 85;
            this.label2.Text = "Blok i grad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-7, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(725, 2);
            this.label3.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 86;
            this.label5.Text = "Lokacija";
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDodajSliku.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDodajSliku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajSliku.Location = new System.Drawing.Point(645, 45);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(30, 23);
            this.btnDodajSliku.TabIndex = 75;
            this.btnDodajSliku.Text = "+";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(415, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 17);
            this.label14.TabIndex = 88;
            this.label14.Text = "Status";
            // 
            // lblTrenutniStatus
            // 
            this.lblTrenutniStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrenutniStatus.AutoSize = true;
            this.lblTrenutniStatus.Location = new System.Drawing.Point(415, 380);
            this.lblTrenutniStatus.Name = "lblTrenutniStatus";
            this.lblTrenutniStatus.Size = new System.Drawing.Size(116, 17);
            this.lblTrenutniStatus.TabIndex = 89;
            this.lblTrenutniStatus.Text = "Trenutni status: -";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(415, 411);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 17);
            this.label16.TabIndex = 90;
            this.label16.Text = "Promijeni status";
            // 
            // cmbStatusi
            // 
            this.cmbStatusi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatusi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusi.Enabled = false;
            this.cmbStatusi.FormattingEnabled = true;
            this.cmbStatusi.Location = new System.Drawing.Point(529, 408);
            this.cmbStatusi.Name = "cmbStatusi";
            this.cmbStatusi.Size = new System.Drawing.Size(146, 24);
            this.cmbStatusi.TabIndex = 91;
            // 
            // lblVecDodanZaposlenik
            // 
            this.lblVecDodanZaposlenik.AutoSize = true;
            this.lblVecDodanZaposlenik.BackColor = System.Drawing.SystemColors.Info;
            this.lblVecDodanZaposlenik.Location = new System.Drawing.Point(229, 774);
            this.lblVecDodanZaposlenik.Name = "lblVecDodanZaposlenik";
            this.lblVecDodanZaposlenik.Size = new System.Drawing.Size(51, 17);
            this.lblVecDodanZaposlenik.TabIndex = 96;
            this.lblVecDodanZaposlenik.Text = "Već tu!";
            this.lblVecDodanZaposlenik.Visible = false;
            // 
            // cmbZaposlenici
            // 
            this.cmbZaposlenici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZaposlenici.Enabled = false;
            this.cmbZaposlenici.FormattingEnabled = true;
            this.cmbZaposlenici.Location = new System.Drawing.Point(111, 716);
            this.cmbZaposlenici.Name = "cmbZaposlenici";
            this.cmbZaposlenici.Size = new System.Drawing.Size(169, 24);
            this.cmbZaposlenici.TabIndex = 94;
            // 
            // btnUkloniZaposlenika
            // 
            this.btnUkloniZaposlenika.Location = new System.Drawing.Point(205, 505);
            this.btnUkloniZaposlenika.Name = "btnUkloniZaposlenika";
            this.btnUkloniZaposlenika.Size = new System.Drawing.Size(75, 23);
            this.btnUkloniZaposlenika.TabIndex = 93;
            this.btnUkloniZaposlenika.Text = "Ukloni";
            this.btnUkloniZaposlenika.UseVisualStyleBackColor = true;
            this.btnUkloniZaposlenika.Click += new System.EventHandler(this.btnUkloniZaposlenika_Click);
            // 
            // listBoxZaposlenici
            // 
            this.listBoxZaposlenici.FormattingEnabled = true;
            this.listBoxZaposlenici.ItemHeight = 16;
            this.listBoxZaposlenici.Location = new System.Drawing.Point(54, 530);
            this.listBoxZaposlenici.Name = "listBoxZaposlenici";
            this.listBoxZaposlenici.Size = new System.Drawing.Size(226, 180);
            this.listBoxZaposlenici.TabIndex = 92;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(415, 470);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 17);
            this.label18.TabIndex = 100;
            this.label18.Text = "Vlasnici";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(-7, 494);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(725, 2);
            this.label19.TabIndex = 99;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 470);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 17);
            this.label20.TabIndex = 98;
            this.label20.Text = "Zaposlenici";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 508);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(165, 17);
            this.label17.TabIndex = 97;
            this.label17.Text = "Zaposleni u restoranu";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDodajZaposlenika
            // 
            this.btnDodajZaposlenika.Location = new System.Drawing.Point(199, 746);
            this.btnDodajZaposlenika.Name = "btnDodajZaposlenika";
            this.btnDodajZaposlenika.Size = new System.Drawing.Size(81, 23);
            this.btnDodajZaposlenika.TabIndex = 95;
            this.btnDodajZaposlenika.Text = "Dodaj";
            this.btnDodajZaposlenika.UseVisualStyleBackColor = true;
            this.btnDodajZaposlenika.Click += new System.EventHandler(this.btnDodajZaposlenika_Click);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.Location = new System.Drawing.Point(403, 508);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 17);
            this.label21.TabIndex = 106;
            this.label21.Text = "Vlasnici restorana";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVecDodanVlasnik
            // 
            this.lblVecDodanVlasnik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVecDodanVlasnik.AutoSize = true;
            this.lblVecDodanVlasnik.BackColor = System.Drawing.SystemColors.Info;
            this.lblVecDodanVlasnik.Location = new System.Drawing.Point(624, 774);
            this.lblVecDodanVlasnik.Name = "lblVecDodanVlasnik";
            this.lblVecDodanVlasnik.Size = new System.Drawing.Size(51, 17);
            this.lblVecDodanVlasnik.TabIndex = 105;
            this.lblVecDodanVlasnik.Text = "Već tu!";
            this.lblVecDodanVlasnik.Visible = false;
            // 
            // btnDodajVlasnika
            // 
            this.btnDodajVlasnika.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDodajVlasnika.Location = new System.Drawing.Point(594, 746);
            this.btnDodajVlasnika.Name = "btnDodajVlasnika";
            this.btnDodajVlasnika.Size = new System.Drawing.Size(81, 23);
            this.btnDodajVlasnika.TabIndex = 104;
            this.btnDodajVlasnika.Text = "Dodaj";
            this.btnDodajVlasnika.UseVisualStyleBackColor = true;
            this.btnDodajVlasnika.Click += new System.EventHandler(this.btnDodajVlasnika_Click);
            // 
            // cmbVlasnici
            // 
            this.cmbVlasnici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVlasnici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVlasnici.Enabled = false;
            this.cmbVlasnici.FormattingEnabled = true;
            this.cmbVlasnici.Location = new System.Drawing.Point(506, 716);
            this.cmbVlasnici.Name = "cmbVlasnici";
            this.cmbVlasnici.Size = new System.Drawing.Size(169, 24);
            this.cmbVlasnici.TabIndex = 103;
            // 
            // btnUkloniVlasnika
            // 
            this.btnUkloniVlasnika.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUkloniVlasnika.Location = new System.Drawing.Point(600, 505);
            this.btnUkloniVlasnika.Name = "btnUkloniVlasnika";
            this.btnUkloniVlasnika.Size = new System.Drawing.Size(75, 23);
            this.btnUkloniVlasnika.TabIndex = 102;
            this.btnUkloniVlasnika.Text = "Ukloni";
            this.btnUkloniVlasnika.UseVisualStyleBackColor = true;
            this.btnUkloniVlasnika.Click += new System.EventHandler(this.btnUkloniVlasnika_Click);
            // 
            // listBoxVlasnici
            // 
            this.listBoxVlasnici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxVlasnici.FormattingEnabled = true;
            this.listBoxVlasnici.ItemHeight = 16;
            this.listBoxVlasnici.Location = new System.Drawing.Point(449, 530);
            this.listBoxVlasnici.Name = "listBoxVlasnici";
            this.listBoxVlasnici.Size = new System.Drawing.Size(226, 180);
            this.listBoxVlasnici.TabIndex = 101;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacuvaj.Location = new System.Drawing.Point(594, 817);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(81, 23);
            this.btnSacuvaj.TabIndex = 107;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.imgLoader);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSacuvaj);
            this.panel1.Controls.Add(this.txtNaziv);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblVecDodanVlasnik);
            this.panel1.Controls.Add(this.txtOpis);
            this.panel1.Controls.Add(this.btnDodajVlasnika);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbVlasnici);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.btnUkloniVlasnika);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.listBoxVlasnici);
            this.panel1.Controls.Add(this.txtWebUrl);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtMaskTelefon);
            this.panel1.Controls.Add(this.lblVecDodanZaposlenik);
            this.panel1.Controls.Add(this.lblDivider);
            this.panel1.Controls.Add(this.btnDodajZaposlenika);
            this.panel1.Controls.Add(this.txtMaskMinCijena);
            this.panel1.Controls.Add(this.cmbZaposlenici);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnUkloniZaposlenika);
            this.panel1.Controls.Add(this.listBoxZaposlenici);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbStatusi);
            this.panel1.Controls.Add(this.btnDodajSliku);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblTrenutniStatus);
            this.panel1.Controls.Add(this.txtSlikaName);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtSifra);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBoxSlika);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAdresa);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbBlokoviGradovi);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 678);
            this.panel1.TabIndex = 108;
            // 
            // imgLoader
            // 
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(706, 3);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 108;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "fileDialogSlika";
            // 
            // RestoraniEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(768, 687);
            this.Controls.Add(this.panel1);
            this.Name = "RestoraniEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(Uredi) restoran -";
            this.Load += new System.EventHandler(this.RestoraniEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlika)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWebUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtMaskTelefon;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.MaskedTextBox txtMaskMinCijena;
        private System.Windows.Forms.PictureBox pictureBoxSlika;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtSlikaName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBlokoviGradovi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.Label lblTrenutniStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbStatusi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVecDodanZaposlenik;
        private System.Windows.Forms.ComboBox cmbZaposlenici;
        private System.Windows.Forms.Button btnUkloniZaposlenika;
        private System.Windows.Forms.ListBox listBoxZaposlenici;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblVecDodanVlasnik;
        private System.Windows.Forms.Button btnDodajVlasnika;
        private System.Windows.Forms.ComboBox cmbVlasnici;
        private System.Windows.Forms.Button btnUkloniVlasnika;
        private System.Windows.Forms.ListBox listBoxVlasnici;
        private System.Windows.Forms.Button btnDodajZaposlenika;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.OpenFileDialog fileDialog;
    }
}