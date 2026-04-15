namespace MieAyamPakAgus
{
    partial class CRUDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRUDForm));
            this.LblTitlePage = new System.Windows.Forms.Label();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.LblLogo = new System.Windows.Forms.Label();
            this.LogoApp = new System.Windows.Forms.ImageList(this.components);
            this.TabMenu = new System.Windows.Forms.TabControl();
            this.TabMeja = new System.Windows.Forms.TabPage();
            this.TabAdmin = new System.Windows.Forms.TabPage();
            this.BtnClearAdmin = new System.Windows.Forms.Button();
            this.BtnDelAdmin = new System.Windows.Forms.Button();
            this.BtnSaveAdmin = new System.Windows.Forms.Button();
            this.InputAdminPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.InputAdminUsername = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnClearMeja = new System.Windows.Forms.Button();
            this.BtnDelMeja = new System.Windows.Forms.Button();
            this.BtnSaveMeja = new System.Windows.Forms.Button();
            this.InputKapasitasMeja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InputStatusReservasi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputKodeMeja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabReservasi = new System.Windows.Forms.TabPage();
            this.InputCepatTeleponPelanggan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnClearReservasi = new System.Windows.Forms.Button();
            this.BtnDelReservasi = new System.Windows.Forms.Button();
            this.BtnSaveReservasi = new System.Windows.Forms.Button();
            this.BtnOpenFileDialog = new System.Windows.Forms.Button();
            this.InputBuktiReservasi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.InputJumlahOrangReservasi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InputPelanggan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.InputMeja = new System.Windows.Forms.ComboBox();
            this.InputWaktuReservasi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TabPelanggan = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnSavePelanggan = new System.Windows.Forms.Button();
            this.InputTeleponPelanggan = new System.Windows.Forms.TextBox();
            this.LblNoTelepon = new System.Windows.Forms.Label();
            this.InputNamaPelanggan = new System.Windows.Forms.TextBox();
            this.LblNamaPelanggan = new System.Windows.Forms.Label();
            this.BuktiTransferDialog = new System.Windows.Forms.OpenFileDialog();
            this.InputSearch = new System.Windows.Forms.TextBox();
            this.LblSearch = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.TabMenu.SuspendLayout();
            this.TabMeja.SuspendLayout();
            this.TabReservasi.SuspendLayout();
            this.TabPelanggan.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitlePage
            // 
            this.LblTitlePage.AutoSize = true;
            this.LblTitlePage.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitlePage.Location = new System.Drawing.Point(547, 56);
            this.LblTitlePage.MaximumSize = new System.Drawing.Size(400, 65);
            this.LblTitlePage.MinimumSize = new System.Drawing.Size(400, 65);
            this.LblTitlePage.Name = "LblTitlePage";
            this.LblTitlePage.Size = new System.Drawing.Size(400, 65);
            this.LblTitlePage.TabIndex = 2;
            this.LblTitlePage.Text = "Title Page";
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToOrderColumns = true;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Location = new System.Drawing.Point(557, 198);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersWidth = 82;
            this.DataTable.RowTemplate.Height = 33;
            this.DataTable.Size = new System.Drawing.Size(1194, 875);
            this.DataTable.TabIndex = 8;
            // 
            // LblLogo
            // 
            this.LblLogo.AutoSize = true;
            this.LblLogo.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 12F, System.Drawing.FontStyle.Bold);
            this.LblLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblLogo.ImageKey = "RehanWangsaf.png";
            this.LblLogo.ImageList = this.LogoApp;
            this.LblLogo.Location = new System.Drawing.Point(74, 55);
            this.LblLogo.Margin = new System.Windows.Forms.Padding(10);
            this.LblLogo.MaximumSize = new System.Drawing.Size(440, 65);
            this.LblLogo.MinimumSize = new System.Drawing.Size(440, 65);
            this.LblLogo.Name = "LblLogo";
            this.LblLogo.Padding = new System.Windows.Forms.Padding(10);
            this.LblLogo.Size = new System.Drawing.Size(440, 65);
            this.LblLogo.TabIndex = 0;
            this.LblLogo.Text = "Mie Ayam Pak Agus";
            this.LblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogoApp
            // 
            this.LogoApp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LogoApp.ImageStream")));
            this.LogoApp.TransparentColor = System.Drawing.Color.Transparent;
            this.LogoApp.Images.SetKeyName(0, "RehanWangsaf.png");
            // 
            // TabMenu
            // 
            this.TabMenu.Controls.Add(this.TabMeja);
            this.TabMenu.Controls.Add(this.TabReservasi);
            this.TabMenu.Controls.Add(this.TabPelanggan);
            this.TabMenu.Controls.Add(this.TabAdmin);
            this.TabMenu.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabMenu.Location = new System.Drawing.Point(73, 140);
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.Padding = new System.Drawing.Point(10, 5);
            this.TabMenu.SelectedIndex = 0;
            this.TabMenu.Size = new System.Drawing.Size(459, 933);
            this.TabMenu.TabIndex = 9;
            // 
            // TabMeja
            // 
            this.TabMeja.AllowDrop = true;
            this.TabMeja.Controls.Add(this.BtnClearMeja);
            this.TabMeja.Controls.Add(this.BtnDelMeja);
            this.TabMeja.Controls.Add(this.BtnSaveMeja);
            this.TabMeja.Controls.Add(this.InputKapasitasMeja);
            this.TabMeja.Controls.Add(this.label3);
            this.TabMeja.Controls.Add(this.InputStatusReservasi);
            this.TabMeja.Controls.Add(this.label2);
            this.TabMeja.Controls.Add(this.InputKodeMeja);
            this.TabMeja.Controls.Add(this.label1);
            this.TabMeja.Location = new System.Drawing.Point(8, 58);
            this.TabMeja.Name = "TabMeja";
            this.TabMeja.Padding = new System.Windows.Forms.Padding(3);
            this.TabMeja.Size = new System.Drawing.Size(443, 867);
            this.TabMeja.TabIndex = 0;
            this.TabMeja.Text = "Meja";
            this.TabMeja.UseVisualStyleBackColor = true;
            // 
            // BtnClearMeja
            // 
            this.BtnClearMeja.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9.125F);
            this.BtnClearMeja.Location = new System.Drawing.Point(228, 781);
            this.BtnClearMeja.Name = "BtnClearMeja";
            this.BtnClearMeja.Size = new System.Drawing.Size(185, 61);
            this.BtnClearMeja.TabIndex = 15;
            this.BtnClearMeja.Text = "Clear";
            this.BtnClearMeja.UseVisualStyleBackColor = true;
            // 
            // BtnDelMeja
            // 
            this.BtnDelMeja.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9.125F);
            this.BtnDelMeja.Location = new System.Drawing.Point(31, 781);
            this.BtnDelMeja.Name = "BtnDelMeja";
            this.BtnDelMeja.Size = new System.Drawing.Size(185, 61);
            this.BtnDelMeja.TabIndex = 14;
            this.BtnDelMeja.Text = "Delete";
            this.BtnDelMeja.UseVisualStyleBackColor = true;
            // 
            // BtnSaveMeja
            // 
            this.BtnSaveMeja.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9.125F);
            this.BtnSaveMeja.Location = new System.Drawing.Point(222, 330);
            this.BtnSaveMeja.Name = "BtnSaveMeja";
            this.BtnSaveMeja.Size = new System.Drawing.Size(191, 61);
            this.BtnSaveMeja.TabIndex = 11;
            this.BtnSaveMeja.Text = "Save";
            this.BtnSaveMeja.UseVisualStyleBackColor = true;
            // 
            // InputKapasitasMeja
            // 
            this.InputKapasitasMeja.Location = new System.Drawing.Point(31, 160);
            this.InputKapasitasMeja.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputKapasitasMeja.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputKapasitasMeja.Name = "InputKapasitasMeja";
            this.InputKapasitasMeja.Size = new System.Drawing.Size(382, 39);
            this.InputKapasitasMeja.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label3.Location = new System.Drawing.Point(24, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kapasitas";
            // 
            // InputStatusReservasi
            // 
            this.InputStatusReservasi.FormattingEnabled = true;
            this.InputStatusReservasi.Items.AddRange(new object[] {
            "Tersedia",
            "Terisi",
            "Dipesan"});
            this.InputStatusReservasi.Location = new System.Drawing.Point(31, 256);
            this.InputStatusReservasi.Name = "InputStatusReservasi";
            this.InputStatusReservasi.Size = new System.Drawing.Size(382, 50);
            this.InputStatusReservasi.TabIndex = 3;
            this.InputStatusReservasi.Text = "- Pilih Status -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label2.Location = new System.Drawing.Point(24, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status Reservasi";
            // 
            // InputKodeMeja
            // 
            this.InputKodeMeja.Location = new System.Drawing.Point(31, 64);
            this.InputKodeMeja.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputKodeMeja.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputKodeMeja.Name = "InputKodeMeja";
            this.InputKodeMeja.Size = new System.Drawing.Size(382, 39);
            this.InputKodeMeja.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode";
            // 
            // TabReservasi
            // 
            this.TabReservasi.Controls.Add(this.InputCepatTeleponPelanggan);
            this.TabReservasi.Controls.Add(this.label9);
            this.TabReservasi.Controls.Add(this.BtnClearReservasi);
            this.TabReservasi.Controls.Add(this.BtnDelReservasi);
            this.TabReservasi.Controls.Add(this.BtnSaveReservasi);
            this.TabReservasi.Controls.Add(this.BtnOpenFileDialog);
            this.TabReservasi.Controls.Add(this.InputBuktiReservasi);
            this.TabReservasi.Controls.Add(this.label8);
            this.TabReservasi.Controls.Add(this.InputJumlahOrangReservasi);
            this.TabReservasi.Controls.Add(this.label7);
            this.TabReservasi.Controls.Add(this.label6);
            this.TabReservasi.Controls.Add(this.InputPelanggan);
            this.TabReservasi.Controls.Add(this.label5);
            this.TabReservasi.Controls.Add(this.InputMeja);
            this.TabReservasi.Controls.Add(this.InputWaktuReservasi);
            this.TabReservasi.Controls.Add(this.label4);
            this.TabReservasi.Location = new System.Drawing.Point(8, 58);
            this.TabReservasi.Name = "TabReservasi";
            this.TabReservasi.Padding = new System.Windows.Forms.Padding(3);
            this.TabReservasi.Size = new System.Drawing.Size(443, 867);
            this.TabReservasi.TabIndex = 1;
            this.TabReservasi.Text = "Reservasi";
            this.TabReservasi.UseVisualStyleBackColor = true;
            // 
            // InputCepatTeleponPelanggan
            // 
            this.InputCepatTeleponPelanggan.Location = new System.Drawing.Point(29, 263);
            this.InputCepatTeleponPelanggan.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputCepatTeleponPelanggan.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputCepatTeleponPelanggan.Name = "InputCepatTeleponPelanggan";
            this.InputCepatTeleponPelanggan.Size = new System.Drawing.Size(382, 39);
            this.InputCepatTeleponPelanggan.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label9.Location = new System.Drawing.Point(22, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 38);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nomor Telepon";
            // 
            // BtnClearReservasi
            // 
            this.BtnClearReservasi.BackColor = System.Drawing.Color.White;
            this.BtnClearReservasi.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnClearReservasi.Location = new System.Drawing.Point(226, 778);
            this.BtnClearReservasi.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClearReservasi.Name = "BtnClearReservasi";
            this.BtnClearReservasi.Size = new System.Drawing.Size(185, 61);
            this.BtnClearReservasi.TabIndex = 15;
            this.BtnClearReservasi.Text = "Clear";
            this.BtnClearReservasi.UseVisualStyleBackColor = false;
            // 
            // BtnDelReservasi
            // 
            this.BtnDelReservasi.BackColor = System.Drawing.Color.White;
            this.BtnDelReservasi.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnDelReservasi.Location = new System.Drawing.Point(29, 778);
            this.BtnDelReservasi.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDelReservasi.Name = "BtnDelReservasi";
            this.BtnDelReservasi.Size = new System.Drawing.Size(185, 61);
            this.BtnDelReservasi.TabIndex = 14;
            this.BtnDelReservasi.Text = "Delete";
            this.BtnDelReservasi.UseVisualStyleBackColor = false;
            // 
            // BtnSaveReservasi
            // 
            this.BtnSaveReservasi.BackColor = System.Drawing.Color.White;
            this.BtnSaveReservasi.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnSaveReservasi.Location = new System.Drawing.Point(220, 616);
            this.BtnSaveReservasi.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSaveReservasi.Name = "BtnSaveReservasi";
            this.BtnSaveReservasi.Size = new System.Drawing.Size(191, 61);
            this.BtnSaveReservasi.TabIndex = 11;
            this.BtnSaveReservasi.Text = "Save";
            this.BtnSaveReservasi.UseVisualStyleBackColor = false;
            // 
            // BtnOpenFileDialog
            // 
            this.BtnOpenFileDialog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnOpenFileDialog.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 8F);
            this.BtnOpenFileDialog.Location = new System.Drawing.Point(29, 550);
            this.BtnOpenFileDialog.Margin = new System.Windows.Forms.Padding(0);
            this.BtnOpenFileDialog.Name = "BtnOpenFileDialog";
            this.BtnOpenFileDialog.Size = new System.Drawing.Size(126, 41);
            this.BtnOpenFileDialog.TabIndex = 10;
            this.BtnOpenFileDialog.Text = "Browse";
            this.BtnOpenFileDialog.UseVisualStyleBackColor = false;
            // 
            // InputBuktiReservasi
            // 
            this.InputBuktiReservasi.Location = new System.Drawing.Point(161, 550);
            this.InputBuktiReservasi.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputBuktiReservasi.MinimumSize = new System.Drawing.Size(250, 42);
            this.InputBuktiReservasi.Name = "InputBuktiReservasi";
            this.InputBuktiReservasi.Size = new System.Drawing.Size(250, 39);
            this.InputBuktiReservasi.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label8.Location = new System.Drawing.Point(22, 509);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 38);
            this.label8.TabIndex = 8;
            this.label8.Text = "Bukti Transfer";
            // 
            // InputJumlahOrangReservasi
            // 
            this.InputJumlahOrangReservasi.Location = new System.Drawing.Point(29, 454);
            this.InputJumlahOrangReservasi.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputJumlahOrangReservasi.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputJumlahOrangReservasi.Name = "InputJumlahOrangReservasi";
            this.InputJumlahOrangReservasi.Size = new System.Drawing.Size(382, 39);
            this.InputJumlahOrangReservasi.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label7.Location = new System.Drawing.Point(22, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 38);
            this.label7.TabIndex = 6;
            this.label7.Text = "Jumlah Orang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label6.Location = new System.Drawing.Point(22, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 38);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pelanggan";
            // 
            // InputPelanggan
            // 
            this.InputPelanggan.FormattingEnabled = true;
            this.InputPelanggan.Location = new System.Drawing.Point(29, 160);
            this.InputPelanggan.Name = "InputPelanggan";
            this.InputPelanggan.Size = new System.Drawing.Size(382, 50);
            this.InputPelanggan.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label5.Location = new System.Drawing.Point(22, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 38);
            this.label5.TabIndex = 3;
            this.label5.Text = "Meja";
            // 
            // InputMeja
            // 
            this.InputMeja.FormattingEnabled = true;
            this.InputMeja.Location = new System.Drawing.Point(29, 58);
            this.InputMeja.Name = "InputMeja";
            this.InputMeja.Size = new System.Drawing.Size(382, 50);
            this.InputMeja.TabIndex = 2;
            // 
            // InputWaktuReservasi
            // 
            this.InputWaktuReservasi.Location = new System.Drawing.Point(29, 359);
            this.InputWaktuReservasi.Name = "InputWaktuReservasi";
            this.InputWaktuReservasi.Size = new System.Drawing.Size(382, 39);
            this.InputWaktuReservasi.TabIndex = 1;
            this.InputWaktuReservasi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.InputWaktuReservasi.CustomFormat = "yyyy-MM-dd HH:mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label4.Location = new System.Drawing.Point(22, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "Waktu Kedatangan";
            // 
            // TabPelanggan
            // 
            this.TabPelanggan.Controls.Add(this.button1);
            this.TabPelanggan.Controls.Add(this.button2);
            this.TabPelanggan.Controls.Add(this.BtnSavePelanggan);
            this.TabPelanggan.Controls.Add(this.InputTeleponPelanggan);
            this.TabPelanggan.Controls.Add(this.LblNoTelepon);
            this.TabPelanggan.Controls.Add(this.InputNamaPelanggan);
            this.TabPelanggan.Controls.Add(this.LblNamaPelanggan);
            this.TabPelanggan.Location = new System.Drawing.Point(8, 58);
            this.TabPelanggan.Name = "TabPelanggan";
            this.TabPelanggan.Padding = new System.Windows.Forms.Padding(3);
            this.TabPelanggan.Size = new System.Drawing.Size(443, 867);
            this.TabPelanggan.TabIndex = 2;
            this.TabPelanggan.Text = "Pelanggan";
            this.TabPelanggan.UseVisualStyleBackColor = true;
            // 
            // TabAdmin
            // 
            this.TabAdmin.Controls.Add(this.BtnClearAdmin);
            this.TabAdmin.Controls.Add(this.BtnDelAdmin);
            this.TabAdmin.Controls.Add(this.BtnSaveAdmin);
            this.TabAdmin.Controls.Add(this.InputAdminPassword);
            this.TabAdmin.Controls.Add(this.label11);
            this.TabAdmin.Controls.Add(this.InputAdminUsername);
            this.TabAdmin.Controls.Add(this.label10);
            this.TabAdmin.Location = new System.Drawing.Point(8, 58);
            this.TabAdmin.Name = "TabAdmin";
            this.TabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.TabAdmin.Size = new System.Drawing.Size(443, 867);
            this.TabAdmin.TabIndex = 3;
            this.TabAdmin.Text = "Admin";
            this.TabAdmin.UseVisualStyleBackColor = true;
            // 
            // BtnClearAdmin
            // 
            this.BtnClearAdmin.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnClearAdmin.Location = new System.Drawing.Point(231, 781);
            this.BtnClearAdmin.Name = "BtnClearAdmin";
            this.BtnClearAdmin.Size = new System.Drawing.Size(185, 61);
            this.BtnClearAdmin.TabIndex = 15;
            this.BtnClearAdmin.Text = "Clear";
            this.BtnClearAdmin.UseVisualStyleBackColor = true;
            // 
            // BtnDelAdmin
            // 
            this.BtnDelAdmin.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnDelAdmin.Location = new System.Drawing.Point(34, 781);
            this.BtnDelAdmin.Name = "BtnDelAdmin";
            this.BtnDelAdmin.Size = new System.Drawing.Size(185, 61);
            this.BtnDelAdmin.TabIndex = 14;
            this.BtnDelAdmin.Text = "Delete";
            this.BtnDelAdmin.UseVisualStyleBackColor = true;
            // 
            // BtnSaveAdmin
            // 
            this.BtnSaveAdmin.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnSaveAdmin.Location = new System.Drawing.Point(225, 237);
            this.BtnSaveAdmin.Name = "BtnSaveAdmin";
            this.BtnSaveAdmin.Size = new System.Drawing.Size(191, 61);
            this.BtnSaveAdmin.TabIndex = 11;
            this.BtnSaveAdmin.Text = "Save";
            this.BtnSaveAdmin.UseVisualStyleBackColor = true;
            // 
            // InputAdminPassword
            // 
            this.InputAdminPassword.Location = new System.Drawing.Point(34, 166);
            this.InputAdminPassword.Name = "InputAdminPassword";
            this.InputAdminPassword.Size = new System.Drawing.Size(382, 39);
            this.InputAdminPassword.TabIndex = 4;
            this.InputAdminPassword.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label11.Location = new System.Drawing.Point(27, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 38);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password";
            // 
            // InputAdminUsername
            // 
            this.InputAdminUsername.Location = new System.Drawing.Point(34, 68);
            this.InputAdminUsername.Name = "InputAdminUsername";
            this.InputAdminUsername.Size = new System.Drawing.Size(382, 39);
            this.InputAdminUsername.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.label10.Location = new System.Drawing.Point(27, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 38);
            this.label10.TabIndex = 0;
            this.label10.Text = "Username";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.button1.Location = new System.Drawing.Point(231, 777);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 61);
            this.button1.TabIndex = 25;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.button2.Location = new System.Drawing.Point(34, 777);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 61);
            this.button2.TabIndex = 24;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // BtnSavePelanggan
            // 
            this.BtnSavePelanggan.BackColor = System.Drawing.Color.White;
            this.BtnSavePelanggan.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnSavePelanggan.Location = new System.Drawing.Point(225, 237);
            this.BtnSavePelanggan.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSavePelanggan.Name = "BtnSavePelanggan";
            this.BtnSavePelanggan.Size = new System.Drawing.Size(191, 61);
            this.BtnSavePelanggan.TabIndex = 23;
            this.BtnSavePelanggan.Text = "Save";
            this.BtnSavePelanggan.UseVisualStyleBackColor = false;
            // 
            // InputTeleponPelanggan
            // 
            this.InputTeleponPelanggan.Location = new System.Drawing.Point(34, 166);
            this.InputTeleponPelanggan.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputTeleponPelanggan.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputTeleponPelanggan.Name = "InputTeleponPelanggan";
            this.InputTeleponPelanggan.Size = new System.Drawing.Size(382, 39);
            this.InputTeleponPelanggan.TabIndex = 22;
            // 
            // LblNoTelepon
            // 
            this.LblNoTelepon.AutoSize = true;
            this.LblNoTelepon.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.LblNoTelepon.Location = new System.Drawing.Point(27, 125);
            this.LblNoTelepon.Name = "LblNoTelepon";
            this.LblNoTelepon.Size = new System.Drawing.Size(188, 38);
            this.LblNoTelepon.TabIndex = 21;
            this.LblNoTelepon.Text = "Nomor Telepon";
            // 
            // InputNamaPelanggan
            // 
            this.InputNamaPelanggan.Location = new System.Drawing.Point(34, 68);
            this.InputNamaPelanggan.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputNamaPelanggan.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputNamaPelanggan.Name = "InputNamaPelanggan";
            this.InputNamaPelanggan.Size = new System.Drawing.Size(382, 39);
            this.InputNamaPelanggan.TabIndex = 20;
            // 
            // LblNamaPelanggan
            // 
            this.LblNamaPelanggan.AutoSize = true;
            this.LblNamaPelanggan.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.LblNamaPelanggan.Location = new System.Drawing.Point(27, 27);
            this.LblNamaPelanggan.Name = "LblNamaPelanggan";
            this.LblNamaPelanggan.Size = new System.Drawing.Size(205, 38);
            this.LblNamaPelanggan.TabIndex = 19;
            this.LblNamaPelanggan.Text = "Nama Pelanggan";
            // 
            // BuktiTransferDialog
            // 
            this.BuktiTransferDialog.FileName = "BuktiTransferDialog";
            // 
            // InputSearch
            // 
            this.InputSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.InputSearch.Location = new System.Drawing.Point(622, 140);
            this.InputSearch.MaximumSize = new System.Drawing.Size(382, 42);
            this.InputSearch.MinimumSize = new System.Drawing.Size(382, 42);
            this.InputSearch.Name = "InputSearch";
            this.InputSearch.Size = new System.Drawing.Size(382, 42);
            this.InputSearch.TabIndex = 24;
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.LblSearch.Location = new System.Drawing.Point(556, 141);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(62, 38);
            this.LblSearch.TabIndex = 23;
            this.LblSearch.Text = "Cari";
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.White;
            this.BtnSearch.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 9F);
            this.BtnSearch.Location = new System.Drawing.Point(1014, 136);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(191, 46);
            this.BtnSearch.TabIndex = 26;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // CRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1814, 1129);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.InputSearch);
            this.Controls.Add(this.LblSearch);
            this.Controls.Add(this.TabMenu);
            this.Controls.Add(this.LblLogo);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.LblTitlePage);
            this.Name = "CRUDForm";
            this.Text = "CRUD Form";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.TabMenu.ResumeLayout(false);
            this.TabMeja.ResumeLayout(false);
            this.TabMeja.PerformLayout();
            this.TabReservasi.ResumeLayout(false);
            this.TabReservasi.PerformLayout();
            this.TabPelanggan.ResumeLayout(false);
            this.TabPelanggan.PerformLayout();
            this.TabAdmin.ResumeLayout(false);
            this.TabAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblTitlePage;
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Label LblLogo;
        private System.Windows.Forms.ImageList LogoApp;
        private System.Windows.Forms.TabControl TabMenu;
        private System.Windows.Forms.TabPage TabMeja;
        private System.Windows.Forms.TabPage TabReservasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputKodeMeja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputKapasitasMeja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox InputStatusReservasi;
        private System.Windows.Forms.Button BtnSaveMeja;
        private System.Windows.Forms.Button BtnClearMeja;
        private System.Windows.Forms.Button BtnDelMeja;
        private System.Windows.Forms.DateTimePicker InputWaktuReservasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox InputMeja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox InputPelanggan;
        private System.Windows.Forms.TextBox InputJumlahOrangReservasi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox InputBuktiReservasi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog BuktiTransferDialog;
        private System.Windows.Forms.Button BtnSaveReservasi;
        private System.Windows.Forms.Button BtnClearReservasi;
        private System.Windows.Forms.Button BtnDelReservasi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox InputCepatTeleponPelanggan;
        private System.Windows.Forms.TabPage TabPelanggan;
        private System.Windows.Forms.TextBox InputNamaPelanggan;
        private System.Windows.Forms.Label LblNamaPelanggan;
        private System.Windows.Forms.TextBox InputTeleponPelanggan;
        private System.Windows.Forms.Label LblNoTelepon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnSavePelanggan;
        private System.Windows.Forms.TextBox InputSearch;
        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TabPage TabAdmin;
        private System.Windows.Forms.TextBox InputAdminUsername;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox InputAdminPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnSaveAdmin;
        private System.Windows.Forms.Button BtnDelAdmin;
        private System.Windows.Forms.Button BtnClearAdmin;
    }
}