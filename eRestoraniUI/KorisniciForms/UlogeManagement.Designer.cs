namespace eRestoraniUI.KorisniciForms
{
    partial class UlogeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UlogeManagement));
            this.listBoxZaposlenici = new System.Windows.Forms.ListBox();
            this.listBoxNarucioci = new System.Windows.Forms.ListBox();
            this.listBoxVlasnici = new System.Windows.Forms.ListBox();
            this.lblDivider = new System.Windows.Forms.Label();
            this.listBoxAdministratori = new System.Windows.Forms.ListBox();
            this.btnNarucilacToZaposlenik = new System.Windows.Forms.Button();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.btnZaposlenikToVlasnik = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnZaposlenikToNarucilac = new System.Windows.Forms.Button();
            this.btnPonistiIzmjene = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVlasnikToAdministrator = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVlasnikToZaposlenik = new System.Windows.Forms.Button();
            this.btnAdministratorToVlasnik = new System.Windows.Forms.Button();
            this.lblUkupnoNarucioci = new System.Windows.Forms.Label();
            this.lblUkupnoZaposlenici = new System.Windows.Forms.Label();
            this.lblUkupnoAdministratori = new System.Windows.Forms.Label();
            this.lblUkupnoVlasnici = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUkupnoIzmjena = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxZaposlenici
            // 
            this.listBoxZaposlenici.FormattingEnabled = true;
            this.listBoxZaposlenici.ItemHeight = 16;
            this.listBoxZaposlenici.Location = new System.Drawing.Point(287, 75);
            this.listBoxZaposlenici.Name = "listBoxZaposlenici";
            this.listBoxZaposlenici.Size = new System.Drawing.Size(232, 324);
            this.listBoxZaposlenici.TabIndex = 2;
            // 
            // listBoxNarucioci
            // 
            this.listBoxNarucioci.FormattingEnabled = true;
            this.listBoxNarucioci.ItemHeight = 16;
            this.listBoxNarucioci.Location = new System.Drawing.Point(15, 75);
            this.listBoxNarucioci.Name = "listBoxNarucioci";
            this.listBoxNarucioci.Size = new System.Drawing.Size(232, 324);
            this.listBoxNarucioci.TabIndex = 3;
            // 
            // listBoxVlasnici
            // 
            this.listBoxVlasnici.FormattingEnabled = true;
            this.listBoxVlasnici.ItemHeight = 16;
            this.listBoxVlasnici.Location = new System.Drawing.Point(559, 75);
            this.listBoxVlasnici.Name = "listBoxVlasnici";
            this.listBoxVlasnici.Size = new System.Drawing.Size(232, 324);
            this.listBoxVlasnici.TabIndex = 4;
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(-12, 42);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(1112, 2);
            this.lblDivider.TabIndex = 35;
            // 
            // listBoxAdministratori
            // 
            this.listBoxAdministratori.FormattingEnabled = true;
            this.listBoxAdministratori.ItemHeight = 16;
            this.listBoxAdministratori.Location = new System.Drawing.Point(831, 75);
            this.listBoxAdministratori.Name = "listBoxAdministratori";
            this.listBoxAdministratori.Size = new System.Drawing.Size(232, 324);
            this.listBoxAdministratori.TabIndex = 80;
            // 
            // btnNarucilacToZaposlenik
            // 
            this.btnNarucilacToZaposlenik.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNarucilacToZaposlenik.Location = new System.Drawing.Point(253, 208);
            this.btnNarucilacToZaposlenik.Name = "btnNarucilacToZaposlenik";
            this.btnNarucilacToZaposlenik.Size = new System.Drawing.Size(28, 23);
            this.btnNarucilacToZaposlenik.TabIndex = 82;
            this.btnNarucilacToZaposlenik.Text = ">";
            this.btnNarucilacToZaposlenik.UseVisualStyleBackColor = true;
            this.btnNarucilacToZaposlenik.Click += new System.EventHandler(this.btnNarucilacToZaposlenik_Click);
            // 
            // imgLoader
            // 
            this.imgLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(1060, 7);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 83;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // btnZaposlenikToVlasnik
            // 
            this.btnZaposlenikToVlasnik.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnZaposlenikToVlasnik.Location = new System.Drawing.Point(525, 208);
            this.btnZaposlenikToVlasnik.Name = "btnZaposlenikToVlasnik";
            this.btnZaposlenikToVlasnik.Size = new System.Drawing.Size(28, 23);
            this.btnZaposlenikToVlasnik.TabIndex = 84;
            this.btnZaposlenikToVlasnik.Text = ">";
            this.btnZaposlenikToVlasnik.UseVisualStyleBackColor = true;
            this.btnZaposlenikToVlasnik.Click += new System.EventHandler(this.btnZaposlenikToVlasnik_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(958, 442);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(132, 23);
            this.btnSaveChanges.TabIndex = 85;
            this.btnSaveChanges.Text = "Sačuvaj promjene";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnZaposlenikToNarucilac
            // 
            this.btnZaposlenikToNarucilac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnZaposlenikToNarucilac.Location = new System.Drawing.Point(253, 237);
            this.btnZaposlenikToNarucilac.Name = "btnZaposlenikToNarucilac";
            this.btnZaposlenikToNarucilac.Size = new System.Drawing.Size(28, 23);
            this.btnZaposlenikToNarucilac.TabIndex = 86;
            this.btnZaposlenikToNarucilac.Text = "<";
            this.btnZaposlenikToNarucilac.UseVisualStyleBackColor = true;
            this.btnZaposlenikToNarucilac.Click += new System.EventHandler(this.btnZaposlenikToNarucilac_Click);
            // 
            // btnPonistiIzmjene
            // 
            this.btnPonistiIzmjene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPonistiIzmjene.Enabled = false;
            this.btnPonistiIzmjene.Location = new System.Drawing.Point(753, 442);
            this.btnPonistiIzmjene.Name = "btnPonistiIzmjene";
            this.btnPonistiIzmjene.Size = new System.Drawing.Size(75, 23);
            this.btnPonistiIzmjene.TabIndex = 87;
            this.btnPonistiIzmjene.Text = "Poništi";
            this.btnPonistiIzmjene.UseVisualStyleBackColor = true;
            this.btnPonistiIzmjene.Click += new System.EventHandler(this.btnPonistiIzmjene_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 88;
            this.label4.Text = "Poništi sve izmjene";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(842, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 89;
            this.label5.Text = "Sačuvaj izmjene";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(621, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "Da biste promijenili ulogu određenog korisnika, koristite strelice za prebacivanj" +
    "e iz grupe u grupu.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "Naručioci";
            // 
            // btnVlasnikToAdministrator
            // 
            this.btnVlasnikToAdministrator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVlasnikToAdministrator.Location = new System.Drawing.Point(797, 208);
            this.btnVlasnikToAdministrator.Name = "btnVlasnikToAdministrator";
            this.btnVlasnikToAdministrator.Size = new System.Drawing.Size(28, 23);
            this.btnVlasnikToAdministrator.TabIndex = 92;
            this.btnVlasnikToAdministrator.Text = ">";
            this.btnVlasnikToAdministrator.UseVisualStyleBackColor = true;
            this.btnVlasnikToAdministrator.Click += new System.EventHandler(this.btnVlasnikToAdministrator_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 93;
            this.label2.Text = "Zaposlenici";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Vlasnici";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(828, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 95;
            this.label7.Text = "Administratori";
            // 
            // btnVlasnikToZaposlenik
            // 
            this.btnVlasnikToZaposlenik.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVlasnikToZaposlenik.Location = new System.Drawing.Point(525, 237);
            this.btnVlasnikToZaposlenik.Name = "btnVlasnikToZaposlenik";
            this.btnVlasnikToZaposlenik.Size = new System.Drawing.Size(28, 23);
            this.btnVlasnikToZaposlenik.TabIndex = 96;
            this.btnVlasnikToZaposlenik.Text = "<";
            this.btnVlasnikToZaposlenik.UseVisualStyleBackColor = true;
            this.btnVlasnikToZaposlenik.Click += new System.EventHandler(this.btnVlasnikToZaposlenik_Click);
            // 
            // btnAdministratorToVlasnik
            // 
            this.btnAdministratorToVlasnik.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdministratorToVlasnik.Location = new System.Drawing.Point(797, 237);
            this.btnAdministratorToVlasnik.Name = "btnAdministratorToVlasnik";
            this.btnAdministratorToVlasnik.Size = new System.Drawing.Size(28, 23);
            this.btnAdministratorToVlasnik.TabIndex = 97;
            this.btnAdministratorToVlasnik.Text = "<";
            this.btnAdministratorToVlasnik.UseVisualStyleBackColor = true;
            this.btnAdministratorToVlasnik.Click += new System.EventHandler(this.btnAdministratorToVlasnik_Click);
            // 
            // lblUkupnoNarucioci
            // 
            this.lblUkupnoNarucioci.AutoSize = true;
            this.lblUkupnoNarucioci.Location = new System.Drawing.Point(13, 403);
            this.lblUkupnoNarucioci.Name = "lblUkupnoNarucioci";
            this.lblUkupnoNarucioci.Size = new System.Drawing.Size(66, 17);
            this.lblUkupnoNarucioci.TabIndex = 98;
            this.lblUkupnoNarucioci.Text = "Ukupno -";
            // 
            // lblUkupnoZaposlenici
            // 
            this.lblUkupnoZaposlenici.AutoSize = true;
            this.lblUkupnoZaposlenici.Location = new System.Drawing.Point(298, 403);
            this.lblUkupnoZaposlenici.Name = "lblUkupnoZaposlenici";
            this.lblUkupnoZaposlenici.Size = new System.Drawing.Size(66, 17);
            this.lblUkupnoZaposlenici.TabIndex = 99;
            this.lblUkupnoZaposlenici.Text = "Ukupno -";
            // 
            // lblUkupnoAdministratori
            // 
            this.lblUkupnoAdministratori.AutoSize = true;
            this.lblUkupnoAdministratori.Location = new System.Drawing.Point(828, 403);
            this.lblUkupnoAdministratori.Name = "lblUkupnoAdministratori";
            this.lblUkupnoAdministratori.Size = new System.Drawing.Size(66, 17);
            this.lblUkupnoAdministratori.TabIndex = 101;
            this.lblUkupnoAdministratori.Text = "Ukupno -";
            // 
            // lblUkupnoVlasnici
            // 
            this.lblUkupnoVlasnici.AutoSize = true;
            this.lblUkupnoVlasnici.Location = new System.Drawing.Point(560, 403);
            this.lblUkupnoVlasnici.Name = "lblUkupnoVlasnici";
            this.lblUkupnoVlasnici.Size = new System.Drawing.Size(66, 17);
            this.lblUkupnoVlasnici.TabIndex = 100;
            this.lblUkupnoVlasnici.Text = "Ukupno -";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(-7, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1112, 2);
            this.label8.TabIndex = 102;
            // 
            // lblUkupnoIzmjena
            // 
            this.lblUkupnoIzmjena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUkupnoIzmjena.AutoSize = true;
            this.lblUkupnoIzmjena.Location = new System.Drawing.Point(5, 445);
            this.lblUkupnoIzmjena.Name = "lblUkupnoIzmjena";
            this.lblUkupnoIzmjena.Size = new System.Drawing.Size(118, 17);
            this.lblUkupnoIzmjena.TabIndex = 103;
            this.lblUkupnoIzmjena.Text = "Ukupno izmjena -";
            // 
            // UlogeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 473);
            this.Controls.Add(this.lblUkupnoIzmjena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUkupnoAdministratori);
            this.Controls.Add(this.lblUkupnoVlasnici);
            this.Controls.Add(this.lblUkupnoZaposlenici);
            this.Controls.Add(this.lblUkupnoNarucioci);
            this.Controls.Add(this.btnAdministratorToVlasnik);
            this.Controls.Add(this.btnVlasnikToZaposlenik);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVlasnikToAdministrator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPonistiIzmjene);
            this.Controls.Add(this.btnZaposlenikToNarucilac);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnZaposlenikToVlasnik);
            this.Controls.Add(this.imgLoader);
            this.Controls.Add(this.btnNarucilacToZaposlenik);
            this.Controls.Add(this.listBoxAdministratori);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.listBoxVlasnici);
            this.Controls.Add(this.listBoxNarucioci);
            this.Controls.Add(this.listBoxZaposlenici);
            this.Name = "UlogeManagement";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UlogeManagement";
            this.Load += new System.EventHandler(this.UlogeManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxZaposlenici;
        private System.Windows.Forms.ListBox listBoxNarucioci;
        private System.Windows.Forms.ListBox listBoxVlasnici;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.ListBox listBoxAdministratori;
        private System.Windows.Forms.Button btnNarucilacToZaposlenik;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Button btnZaposlenikToVlasnik;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnZaposlenikToNarucilac;
        private System.Windows.Forms.Button btnPonistiIzmjene;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVlasnikToAdministrator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVlasnikToZaposlenik;
        private System.Windows.Forms.Button btnAdministratorToVlasnik;
        private System.Windows.Forms.Label lblUkupnoNarucioci;
        private System.Windows.Forms.Label lblUkupnoZaposlenici;
        private System.Windows.Forms.Label lblUkupnoAdministratori;
        private System.Windows.Forms.Label lblUkupnoVlasnici;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUkupnoIzmjena;
    }
}