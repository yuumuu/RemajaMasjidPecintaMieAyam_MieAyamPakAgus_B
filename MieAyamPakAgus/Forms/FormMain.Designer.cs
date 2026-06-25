namespace MieAyamPakAgus.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPelanggan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMeja = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReservasi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLaporanReservasi = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.lblMejaTerpakai = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMejaTersedia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalPelanggan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReservasiHariIni = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalReservasi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterDataToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.laporanToolStripMenuItem,
            this.userToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterDataToolStripMenuItem
            // 
            this.masterDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdmin,
            this.menuPelanggan,
            this.menuMeja});
            this.masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            this.masterDataToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.masterDataToolStripMenuItem.Text = "Master Data";
            // 
            // menuAdmin
            // 
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(130, 22);
            this.menuAdmin.Text = "Admin";
            this.menuAdmin.Click += new System.EventHandler(this.menuAdmin_Click);
            // 
            // menuPelanggan
            // 
            this.menuPelanggan.Name = "menuPelanggan";
            this.menuPelanggan.Size = new System.Drawing.Size(130, 22);
            this.menuPelanggan.Text = "Pelanggan";
            this.menuPelanggan.Click += new System.EventHandler(this.menuPelanggan_Click);
            // 
            // menuMeja
            // 
            this.menuMeja.Name = "menuMeja";
            this.menuMeja.Size = new System.Drawing.Size(130, 22);
            this.menuMeja.Text = "Meja";
            this.menuMeja.Click += new System.EventHandler(this.menuMeja_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReservasi,
            this.menuImport});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // menuReservasi
            // 
            this.menuReservasi.Name = "menuReservasi";
            this.menuReservasi.Size = new System.Drawing.Size(123, 22);
            this.menuReservasi.Text = "Reservasi";
            this.menuReservasi.Click += new System.EventHandler(this.menuReservasi_Click);
            // 
            // menuImport
            // 
            this.menuImport.Name = "menuImport";
            this.menuImport.Size = new System.Drawing.Size(123, 22);
            this.menuImport.Text = "Import Excel";
            this.menuImport.Click += new System.EventHandler(this.menuImport_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLaporanReservasi});
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.laporanToolStripMenuItem.Text = "Laporan";
            // 
            // menuLaporanReservasi
            // 
            this.menuLaporanReservasi.Name = "menuLaporanReservasi";
            this.menuLaporanReservasi.Size = new System.Drawing.Size(170, 22);
            this.menuLaporanReservasi.Text = "Laporan Reservasi";
            this.menuLaporanReservasi.Click += new System.EventHandler(this.menuLaporanReservasi_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(112, 22);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlDashboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDashboard.Controls.Add(this.lblMejaTerpakai);
            this.pnlDashboard.Controls.Add(this.label9);
            this.pnlDashboard.Controls.Add(this.lblMejaTersedia);
            this.pnlDashboard.Controls.Add(this.label7);
            this.pnlDashboard.Controls.Add(this.lblTotalPelanggan);
            this.pnlDashboard.Controls.Add(this.label5);
            this.pnlDashboard.Controls.Add(this.lblReservasiHariIni);
            this.pnlDashboard.Controls.Add(this.label3);
            this.pnlDashboard.Controls.Add(this.lblTotalReservasi);
            this.pnlDashboard.Controls.Add(this.label1);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 24);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDashboard.Size = new System.Drawing.Size(900, 80);
            this.pnlDashboard.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Reservasi:";
            // 
            // lblTotalReservasi
            // 
            this.lblTotalReservasi.AutoSize = true;
            this.lblTotalReservasi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalReservasi.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalReservasi.Location = new System.Drawing.Point(20, 35);
            this.lblTotalReservasi.Name = "lblTotalReservasi";
            this.lblTotalReservasi.Size = new System.Drawing.Size(21, 25);
            this.lblTotalReservasi.TabIndex = 1;
            this.lblTotalReservasi.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(200, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reservasi Hari Ini:";
            // 
            // lblReservasiHariIni
            // 
            this.lblReservasiHariIni.AutoSize = true;
            this.lblReservasiHariIni.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblReservasiHariIni.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblReservasiHariIni.Location = new System.Drawing.Point(200, 35);
            this.lblReservasiHariIni.Name = "lblReservasiHariIni";
            this.lblReservasiHariIni.Size = new System.Drawing.Size(21, 25);
            this.lblReservasiHariIni.TabIndex = 3;
            this.lblReservasiHariIni.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(380, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Pelanggan:";
            // 
            // lblTotalPelanggan
            // 
            this.lblTotalPelanggan.AutoSize = true;
            this.lblTotalPelanggan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPelanggan.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalPelanggan.Location = new System.Drawing.Point(380, 35);
            this.lblTotalPelanggan.Name = "lblTotalPelanggan";
            this.lblTotalPelanggan.Size = new System.Drawing.Size(21, 25);
            this.lblTotalPelanggan.TabIndex = 5;
            this.lblTotalPelanggan.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(560, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Meja Tersedia:";
            // 
            // lblMejaTersedia
            // 
            this.lblMejaTersedia.AutoSize = true;
            this.lblMejaTersedia.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMejaTersedia.ForeColor = System.Drawing.Color.Green;
            this.lblMejaTersedia.Location = new System.Drawing.Point(560, 35);
            this.lblMejaTersedia.Name = "lblMejaTersedia";
            this.lblMejaTersedia.Size = new System.Drawing.Size(21, 25);
            this.lblMejaTersedia.TabIndex = 7;
            this.lblMejaTersedia.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(720, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Meja Terpakai:";
            // 
            // lblMejaTerpakai
            // 
            this.lblMejaTerpakai.AutoSize = true;
            this.lblMejaTerpakai.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMejaTerpakai.ForeColor = System.Drawing.Color.Red;
            this.lblMejaTerpakai.Location = new System.Drawing.Point(720, 35);
            this.lblMejaTerpakai.Name = "lblMejaTerpakai";
            this.lblMejaTerpakai.Size = new System.Drawing.Size(21, 25);
            this.lblMejaTerpakai.TabIndex = 9;
            this.lblMejaTerpakai.Text = "0";
            // 
            // pnlContent
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 104);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(900, 474);
            this.pnlContent.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Mie Ayam Pak Agus - Restaurant Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuPelanggan;
        private System.Windows.Forms.ToolStripMenuItem menuMeja;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuReservasi;
        private System.Windows.Forms.ToolStripMenuItem menuImport;
        private System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLaporanReservasi;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblTotalReservasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReservasiHariIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalPelanggan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMejaTersedia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMejaTerpakai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlContent;
    }
}
