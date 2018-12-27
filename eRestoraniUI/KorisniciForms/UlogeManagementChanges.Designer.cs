namespace eRestoraniUI.KorisniciForms
{
    partial class UlogeManagementChanges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UlogeManagementChanges));
            this.listBoxIzmjene = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxNapomene = new System.Windows.Forms.ListBox();
            this.lblUkupnoIzmjena = new System.Windows.Forms.Label();
            this.imgLoader = new System.Windows.Forms.PictureBox();
            this.lblDivider = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxIzmjene
            // 
            this.listBoxIzmjene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIzmjene.FormattingEnabled = true;
            this.listBoxIzmjene.ItemHeight = 16;
            this.listBoxIzmjene.Location = new System.Drawing.Point(3, 25);
            this.listBoxIzmjene.Name = "listBoxIzmjene";
            this.listBoxIzmjene.Size = new System.Drawing.Size(790, 228);
            this.listBoxIzmjene.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Izmjene za napraviti";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(632, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Iznad možete vidjeti izmjene koje ste napravili. Jeste li sigurni da navedene izm" +
    "jene želite sačuvati?";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOdustani.Location = new System.Drawing.Point(649, 351);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 3;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacuvaj.Location = new System.Drawing.Point(730, 351);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 4;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 47);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxIzmjene);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxNapomene);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(797, 264);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Napomene";
            // 
            // listBoxNapomene
            // 
            this.listBoxNapomene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNapomene.FormattingEnabled = true;
            this.listBoxNapomene.ItemHeight = 16;
            this.listBoxNapomene.Location = new System.Drawing.Point(3, 24);
            this.listBoxNapomene.Name = "listBoxNapomene";
            this.listBoxNapomene.Size = new System.Drawing.Size(790, 100);
            this.listBoxNapomene.TabIndex = 1;
            // 
            // lblUkupnoIzmjena
            // 
            this.lblUkupnoIzmjena.AutoSize = true;
            this.lblUkupnoIzmjena.Location = new System.Drawing.Point(6, 12);
            this.lblUkupnoIzmjena.Name = "lblUkupnoIzmjena";
            this.lblUkupnoIzmjena.Size = new System.Drawing.Size(118, 17);
            this.lblUkupnoIzmjena.TabIndex = 2;
            this.lblUkupnoIzmjena.Text = "Ukupno izmjena -";
            // 
            // imgLoader
            // 
            this.imgLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoader.Image = ((System.Drawing.Image)(resources.GetObject("imgLoader.Image")));
            this.imgLoader.Location = new System.Drawing.Point(772, 6);
            this.imgLoader.Name = "imgLoader";
            this.imgLoader.Size = new System.Drawing.Size(31, 30);
            this.imgLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader.TabIndex = 84;
            this.imgLoader.TabStop = false;
            this.imgLoader.Visible = false;
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(-6, 40);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(820, 2);
            this.lblDivider.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-6, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(820, 2);
            this.label4.TabIndex = 85;
            // 
            // UlogeManagementChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 379);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.imgLoader);
            this.Controls.Add(this.lblUkupnoIzmjena);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label2);
            this.Name = "UlogeManagementChanges";
            this.ShowIcon = false;
            this.Text = "UlogeManagementChanges";
            this.Load += new System.EventHandler(this.UlogeManagementChanges_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIzmjene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxNapomene;
        private System.Windows.Forms.Label lblUkupnoIzmjena;
        private System.Windows.Forms.PictureBox imgLoader;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Label label4;
    }
}