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
            this.inputNaziv = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.Label();
            this.inputOpis = new System.Windows.Forms.TextBox();
            this.txtWebUrl = new System.Windows.Forms.Label();
            this.inputWebUrl = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.Label();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputTelefon = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDivider = new System.Windows.Forms.Label();
            this.inputMinCijenaNarudzbe = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // inputNaziv
            // 
            this.inputNaziv.Location = new System.Drawing.Point(194, 46);
            this.inputNaziv.Name = "inputNaziv";
            this.inputNaziv.Size = new System.Drawing.Size(230, 22);
            this.inputNaziv.TabIndex = 0;
            this.inputNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.inputNaziv_Validating);
            // 
            // txtNaziv
            // 
            this.txtNaziv.AutoSize = true;
            this.txtNaziv.Location = new System.Drawing.Point(8, 46);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(43, 17);
            this.txtNaziv.TabIndex = 1;
            this.txtNaziv.Text = "Naziv";
            this.txtNaziv.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOpis
            // 
            this.txtOpis.AutoSize = true;
            this.txtOpis.Location = new System.Drawing.Point(8, 74);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(37, 17);
            this.txtOpis.TabIndex = 3;
            this.txtOpis.Text = "Opis";
            this.txtOpis.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inputOpis
            // 
            this.inputOpis.Location = new System.Drawing.Point(194, 74);
            this.inputOpis.Multiline = true;
            this.inputOpis.Name = "inputOpis";
            this.inputOpis.Size = new System.Drawing.Size(230, 62);
            this.inputOpis.TabIndex = 2;
            // 
            // txtWebUrl
            // 
            this.txtWebUrl.AutoSize = true;
            this.txtWebUrl.Location = new System.Drawing.Point(8, 170);
            this.txtWebUrl.Name = "txtWebUrl";
            this.txtWebUrl.Size = new System.Drawing.Size(59, 17);
            this.txtWebUrl.TabIndex = 7;
            this.txtWebUrl.Text = "Web Url";
            this.txtWebUrl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inputWebUrl
            // 
            this.inputWebUrl.Location = new System.Drawing.Point(194, 170);
            this.inputWebUrl.Name = "inputWebUrl";
            this.inputWebUrl.Size = new System.Drawing.Size(230, 22);
            this.inputWebUrl.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(8, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(42, 17);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Text = "Email";
            this.txtEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(194, 142);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(230, 22);
            this.inputEmail.TabIndex = 4;
            this.inputEmail.Validating += new System.ComponentModel.CancelEventHandler(this.inputEmail_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Minimalna cijena narudžbe";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTelefon
            // 
            this.txtTelefon.AutoSize = true;
            this.txtTelefon.Location = new System.Drawing.Point(8, 198);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(56, 17);
            this.txtTelefon.TabIndex = 9;
            this.txtTelefon.Text = "Telefon";
            this.txtTelefon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(321, 267);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(103, 23);
            this.btnSacuvaj.TabIndex = 12;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnAddRestoran_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Novi restoran";
            // 
            // inputTelefon
            // 
            this.inputTelefon.Location = new System.Drawing.Point(194, 198);
            this.inputTelefon.Mask = "(000) 000 - 000";
            this.inputTelefon.Name = "inputTelefon";
            this.inputTelefon.Size = new System.Drawing.Size(104, 22);
            this.inputTelefon.TabIndex = 14;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // lblDivider
            // 
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(7, 32);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(421, 2);
            this.lblDivider.TabIndex = 35;
            // 
            // inputMinCijenaNarudzbe
            // 
            this.inputMinCijenaNarudzbe.Location = new System.Drawing.Point(194, 226);
            this.inputMinCijenaNarudzbe.Mask = "00.00  KM";
            this.inputMinCijenaNarudzbe.Name = "inputMinCijenaNarudzbe";
            this.inputMinCijenaNarudzbe.Size = new System.Drawing.Size(104, 22);
            this.inputMinCijenaNarudzbe.TabIndex = 36;
            // 
            // RestoraniEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(461, 302);
            this.Controls.Add(this.inputMinCijenaNarudzbe);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.inputTelefon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtWebUrl);
            this.Controls.Add(this.inputWebUrl);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.inputOpis);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.inputNaziv);
            this.Name = "RestoraniEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RestoraniAddNew";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputNaziv;
        private System.Windows.Forms.Label txtNaziv;
        private System.Windows.Forms.Label txtOpis;
        private System.Windows.Forms.TextBox inputOpis;
        private System.Windows.Forms.Label txtWebUrl;
        private System.Windows.Forms.TextBox inputWebUrl;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTelefon;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox inputTelefon;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.MaskedTextBox inputMinCijenaNarudzbe;
    }
}