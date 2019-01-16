namespace eRestoraniUI.HranaUI
{
    partial class HranaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HranaList));
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRestoranInfo = new System.Windows.Forms.Label();
            this.lblDivider = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHranaFormTitle = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.pictureBoxSlika = new System.Windows.Forms.PictureBox();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlikaName = new System.Windows.Forms.TextBox();
            this.lblCropDisabled = new System.Windows.Forms.Label();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.txtCijena = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoviKuhinje = new System.Windows.Forms.ComboBox();
            this.checkCropImage = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUkupnoStavki = new System.Windows.Forms.Label();
            this.dgvHranaList = new System.Windows.Forms.DataGridView();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlikaBig = new System.Windows.Forms.DataGridViewImageColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipKuhinje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretragaErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.formErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHranaList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pretragaErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "fileDialogSlika";
            this.fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.lblRestoranInfo);
            this.panel1.Location = new System.Drawing.Point(1, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 35);
            this.panel1.TabIndex = 33;
            // 
            // lblRestoranInfo
            // 
            this.lblRestoranInfo.AutoSize = true;
            this.lblRestoranInfo.Location = new System.Drawing.Point(8, 13);
            this.lblRestoranInfo.Name = "lblRestoranInfo";
            this.lblRestoranInfo.Size = new System.Drawing.Size(113, 17);
            this.lblRestoranInfo.TabIndex = 34;
            this.lblRestoranInfo.Text = "Restoran: Petica";
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(3, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(1137, 2);
            this.lblDivider.TabIndex = 34;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.pnlForm);
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.splitContainer1.Panel2.Controls.Add(this.btnTrazi);
            this.splitContainer1.Panel2.Controls.Add(this.imgLoader);
            this.splitContainer1.Panel2.Controls.Add(this.btnUredi);
            this.splitContainer1.Panel2.Controls.Add(this.lblDivider);
            this.splitContainer1.Panel2.Controls.Add(this.btnIzbrisi);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovaStavka);
            this.splitContainer1.Panel2.Controls.Add(this.txtPretraga);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lblUkupnoStavki);
            this.splitContainer1.Panel2.Controls.Add(this.dgvHranaList);
            this.splitContainer1.Size = new System.Drawing.Size(1138, 673);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2125, 2);
            this.label8.TabIndex = 55;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.panel2);
            this.pnlForm.Controls.Add(this.txtNaziv);
            this.pnlForm.Controls.Add(this.pictureBoxSlika);
            this.pnlForm.Controls.Add(this.btnOdustani);
            this.pnlForm.Controls.Add(this.label7);
            this.pnlForm.Controls.Add(this.btnSacuvaj);
            this.pnlForm.Controls.Add(this.txtSifra);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.txtSlikaName);
            this.pnlForm.Controls.Add(this.lblCropDisabled);
            this.pnlForm.Controls.Add(this.btnDodajSliku);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.txtOpis);
            this.pnlForm.Controls.Add(this.txtCijena);
            this.pnlForm.Controls.Add(this.label6);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.cmbTipoviKuhinje);
            this.pnlForm.Controls.Add(this.checkCropImage);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlForm.Location = new System.Drawing.Point(8, 6);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(767, 301);
            this.pnlForm.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.lblHranaFormTitle);
            this.panel2.Controls.Add(this.btnCloseForm);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 21);
            this.panel2.TabIndex = 76;
            // 
            // lblHranaFormTitle
            // 
            this.lblHranaFormTitle.AutoSize = true;
            this.lblHranaFormTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHranaFormTitle.Location = new System.Drawing.Point(4, 1);
            this.lblHranaFormTitle.Name = "lblHranaFormTitle";
            this.lblHranaFormTitle.Size = new System.Drawing.Size(127, 17);
            this.lblHranaFormTitle.TabIndex = 78;
            this.lblHranaFormTitle.Text = "Nova stavka hrane";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCloseForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseForm.BackgroundImage")));
            this.btnCloseForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseForm.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Location = new System.Drawing.Point(748, 5);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(10, 10);
            this.btnCloseForm.TabIndex = 77;
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(115, 29);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(252, 22);
            this.txtNaziv.TabIndex = 56;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // pictureBoxSlika
            // 
            this.pictureBoxSlika.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSlika.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.pictureBoxSlika.Location = new System.Drawing.Point(537, 28);
            this.pictureBoxSlika.Name = "pictureBoxSlika";
            this.pictureBoxSlika.Size = new System.Drawing.Size(220, 220);
            this.pictureBoxSlika.TabIndex = 70;
            this.pictureBoxSlika.TabStop = false;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOdustani.Location = new System.Drawing.Point(601, 271);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 72;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "Naziv";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacuvaj.Location = new System.Drawing.Point(682, 271);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 63;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(115, 239);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.ReadOnly = true;
            this.txtSifra.Size = new System.Drawing.Size(252, 22);
            this.txtSifra.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Opis";
            // 
            // txtSlikaName
            // 
            this.txtSlikaName.Location = new System.Drawing.Point(115, 159);
            this.txtSlikaName.Name = "txtSlikaName";
            this.txtSlikaName.ReadOnly = true;
            this.txtSlikaName.Size = new System.Drawing.Size(252, 22);
            this.txtSlikaName.TabIndex = 59;
            this.txtSlikaName.Text = "Odaberite sliku...";
            // 
            // lblCropDisabled
            // 
            this.lblCropDisabled.BackColor = System.Drawing.SystemColors.Info;
            this.lblCropDisabled.Location = new System.Drawing.Point(112, 211);
            this.lblCropDisabled.Name = "lblCropDisabled";
            this.lblCropDisabled.Size = new System.Drawing.Size(255, 17);
            this.lblCropDisabled.TabIndex = 55;
            this.lblCropDisabled.Text = "Slika zbog dimenzija se ne može isjeći.";
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(373, 158);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(75, 23);
            this.btnDodajSliku.TabIndex = 60;
            this.btnDodajSliku.Text = "Dodaj";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "Cijena";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(115, 57);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(252, 22);
            this.txtOpis.TabIndex = 57;
            this.txtOpis.Validating += new System.ComponentModel.CancelEventHandler(this.txtOpis_Validating);
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(115, 115);
            this.txtCijena.Mask = "00.00  KM";
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(78, 22);
            this.txtCijena.TabIndex = 71;
            this.txtCijena.ValidatingType = typeof(System.DateTime);
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 69;
            this.label6.Text = "Tip kuhinje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 67;
            this.label4.Text = "Šifra";
            // 
            // cmbTipoviKuhinje
            // 
            this.cmbTipoviKuhinje.FormattingEnabled = true;
            this.cmbTipoviKuhinje.Location = new System.Drawing.Point(115, 85);
            this.cmbTipoviKuhinje.Name = "cmbTipoviKuhinje";
            this.cmbTipoviKuhinje.Size = new System.Drawing.Size(252, 24);
            this.cmbTipoviKuhinje.TabIndex = 58;
            this.cmbTipoviKuhinje.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTipoviKuhinje_Validating);
            // 
            // checkCropImage
            // 
            this.checkCropImage.AutoSize = true;
            this.checkCropImage.Location = new System.Drawing.Point(115, 187);
            this.checkCropImage.Name = "checkCropImage";
            this.checkCropImage.Size = new System.Drawing.Size(231, 21);
            this.checkCropImage.TabIndex = 61;
            this.checkCropImage.Text = "Generiši i thumb (cropped) sliku";
            this.checkCropImage.UseVisualStyleBackColor = true;
            this.checkCropImage.Click += new System.EventHandler(this.checkCropImage_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 68;
            this.label5.Text = "Slika";
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(373, 7);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(75, 23);
            this.btnTrazi.TabIndex = 54;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // imgLoader
            // 
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(454, 4);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 53;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // btnUredi
            // 
            this.btnUredi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUredi.Location = new System.Drawing.Point(849, 8);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(75, 23);
            this.btnUredi.TabIndex = 52;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzbrisi.Location = new System.Drawing.Point(930, 8);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 49;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaStavka.Location = new System.Drawing.Point(1011, 8);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(114, 23);
            this.btnNovaStavka.TabIndex = 50;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(114, 8);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(252, 22);
            this.txtPretraga.TabIndex = 47;
            this.txtPretraga.Validating += new System.ComponentModel.CancelEventHandler(this.txtPretraga_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Pretraga";
            // 
            // lblUkupnoStavki
            // 
            this.lblUkupnoStavki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUkupnoStavki.AutoSize = true;
            this.lblUkupnoStavki.Location = new System.Drawing.Point(8, 652);
            this.lblUkupnoStavki.Name = "lblUkupnoStavki";
            this.lblUkupnoStavki.Size = new System.Drawing.Size(147, 17);
            this.lblUkupnoStavki.TabIndex = 45;
            this.lblUkupnoStavki.Text = "Ukupno - stavki hrane";
            // 
            // dgvHranaList
            // 
            this.dgvHranaList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHranaList.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvHranaList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHranaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHranaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sifra,
            this.SlikaBig,
            this.Slika,
            this.Naziv,
            this.Opis,
            this.Cijena,
            this.TipKuhinje});
            this.dgvHranaList.Location = new System.Drawing.Point(8, 39);
            this.dgvHranaList.Name = "dgvHranaList";
            this.dgvHranaList.RowHeadersWidth = 50;
            this.dgvHranaList.RowTemplate.Height = 100;
            this.dgvHranaList.Size = new System.Drawing.Size(1118, 610);
            this.dgvHranaList.TabIndex = 51;
            // 
            // Sifra
            // 
            this.Sifra.DataPropertyName = "Sifra";
            this.Sifra.HeaderText = "Šifra";
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            // 
            // SlikaBig
            // 
            this.SlikaBig.DataPropertyName = "Slika";
            this.SlikaBig.HeaderText = "Slika";
            this.SlikaBig.MinimumWidth = 180;
            this.SlikaBig.Name = "SlikaBig";
            this.SlikaBig.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SlikaBig.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SlikaBig.Width = 180;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "SlikaThumb";
            this.Slika.HeaderText = "Thumb slika";
            this.Slika.MinimumWidth = 120;
            this.Slika.Name = "Slika";
            this.Slika.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Slika.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Slika.Width = 120;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // TipKuhinje
            // 
            this.TipKuhinje.DataPropertyName = "TipKuhinjeNaziv";
            this.TipKuhinje.HeaderText = "Tip kuhinje";
            this.TipKuhinje.Name = "TipKuhinje";
            this.TipKuhinje.ReadOnly = true;
            // 
            // pretragaErrorProvider
            // 
            this.pretragaErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.pretragaErrorProvider.ContainerControl = this;
            // 
            // formErrorProvider
            // 
            this.formErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.formErrorProvider.ContainerControl = this;
            // 
            // HranaList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1139, 704);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "HranaList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restoran {0}";
            this.Load += new System.EventHandler(this.HranaList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHranaList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pretragaErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRestoranInfo;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.Button btnNovaStavka;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUkupnoStavki;
        private System.Windows.Forms.DataGridView dgvHranaList;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label lblCropDisabled;
        private System.Windows.Forms.MaskedTextBox txtCijena;
        private System.Windows.Forms.CheckBox checkCropImage;
        private System.Windows.Forms.ComboBox cmbTipoviKuhinje;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtSlikaName;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxSlika;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewImageColumn SlikaBig;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipKuhinje;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.ErrorProvider pretragaErrorProvider;
        private System.Windows.Forms.ErrorProvider formErrorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHranaFormTitle;
    }
}