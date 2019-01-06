namespace eRestoraniUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoraniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sviKorisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naručiociToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vlasniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lokacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blokoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narudžbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sveNarudžbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.korisniciToolStripMenuItem,
            this.lokacijeToolStripMenuItem,
            this.narudžbeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoraniToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // restoraniToolStripMenuItem
            // 
            this.restoraniToolStripMenuItem.Name = "restoraniToolStripMenuItem";
            this.restoraniToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.restoraniToolStripMenuItem.Text = "Restorani";
            this.restoraniToolStripMenuItem.Click += new System.EventHandler(this.restoraniToolStripMenuItem_Click);
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKorisnikaToolStripMenuItem,
            this.userManagementToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pregledKorisnikaToolStripMenuItem
            // 
            this.pregledKorisnikaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sviKorisniciToolStripMenuItem,
            this.naručiociToolStripMenuItem,
            this.zaposleniciToolStripMenuItem,
            this.vlasniciToolStripMenuItem});
            this.pregledKorisnikaToolStripMenuItem.Name = "pregledKorisnikaToolStripMenuItem";
            this.pregledKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.pregledKorisnikaToolStripMenuItem.Text = "Pregled korisnika";
            // 
            // sviKorisniciToolStripMenuItem
            // 
            this.sviKorisniciToolStripMenuItem.Name = "sviKorisniciToolStripMenuItem";
            this.sviKorisniciToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.sviKorisniciToolStripMenuItem.Text = "Svi korisnici";
            this.sviKorisniciToolStripMenuItem.Click += new System.EventHandler(this.sviKorisniciToolStripMenuItem_Click);
            // 
            // naručiociToolStripMenuItem
            // 
            this.naručiociToolStripMenuItem.Name = "naručiociToolStripMenuItem";
            this.naručiociToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.naručiociToolStripMenuItem.Text = "Naručioci";
            this.naručiociToolStripMenuItem.Click += new System.EventHandler(this.naruciociToolStripMenuItem_Click);
            // 
            // zaposleniciToolStripMenuItem
            // 
            this.zaposleniciToolStripMenuItem.Name = "zaposleniciToolStripMenuItem";
            this.zaposleniciToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.zaposleniciToolStripMenuItem.Tag = "zaposleniciList";
            this.zaposleniciToolStripMenuItem.Text = "Zaposlenici";
            this.zaposleniciToolStripMenuItem.Click += new System.EventHandler(this.zaposleniciToolStripMenuItem_Click);
            // 
            // vlasniciToolStripMenuItem
            // 
            this.vlasniciToolStripMenuItem.Name = "vlasniciToolStripMenuItem";
            this.vlasniciToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.vlasniciToolStripMenuItem.Tag = "vlasniciList";
            this.vlasniciToolStripMenuItem.Text = "Vlasnici";
            this.vlasniciToolStripMenuItem.Click += new System.EventHandler(this.vlasniciToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.userManagementToolStripMenuItem.Text = "User management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // lokacijeToolStripMenuItem
            // 
            this.lokacijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blokoviToolStripMenuItem,
            this.gradoviToolStripMenuItem});
            this.lokacijeToolStripMenuItem.Name = "lokacijeToolStripMenuItem";
            this.lokacijeToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.lokacijeToolStripMenuItem.Text = "Lokacije";
            // 
            // blokoviToolStripMenuItem
            // 
            this.blokoviToolStripMenuItem.Name = "blokoviToolStripMenuItem";
            this.blokoviToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.blokoviToolStripMenuItem.Text = "Blokovi";
            this.blokoviToolStripMenuItem.Click += new System.EventHandler(this.blokoviToolStripMenuItem_Click);
            // 
            // gradoviToolStripMenuItem
            // 
            this.gradoviToolStripMenuItem.Name = "gradoviToolStripMenuItem";
            this.gradoviToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.gradoviToolStripMenuItem.Text = "Gradovi";
            this.gradoviToolStripMenuItem.Click += new System.EventHandler(this.gradoviToolStripMenuItem_Click);
            // 
            // narudžbeToolStripMenuItem
            // 
            this.narudžbeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sveNarudžbeToolStripMenuItem});
            this.narudžbeToolStripMenuItem.Name = "narudžbeToolStripMenuItem";
            this.narudžbeToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.narudžbeToolStripMenuItem.Text = "Narudžbe";
            // 
            // sveNarudžbeToolStripMenuItem
            // 
            this.sveNarudžbeToolStripMenuItem.Name = "sveNarudžbeToolStripMenuItem";
            this.sveNarudžbeToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.sveNarudžbeToolStripMenuItem.Text = "Sve narudžbe";
            this.sveNarudžbeToolStripMenuItem.Click += new System.EventHandler(this.sveNarudžbeToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(967, 656);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "EasyFood - Dobrodošli {0}";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoraniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lokacijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blokoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sviKorisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vlasniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naručiociToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narudžbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sveNarudžbeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}