namespace MieAyamPakAgus.Forms
{
    partial class FormReservasi
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
            this.components = new System.ComponentModel.Container();
            this.dgvReservasi = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.txtBukti = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numOrang = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpWaktu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMeja = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.bnReservasi = new System.Windows.Forms.BindingNavigator(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ofdBukti = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservasi)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnReservasi)).BeginInit();
            this.bnReservasi.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvReservasi
            //
            this.dgvReservasi.AllowUserToAddRows = false;
            this.dgvReservasi.AllowUserToDeleteRows = false;
            this.dgvReservasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservasi.Location = new System.Drawing.Point(12, 210);
            this.dgvReservasi.Name = "dgvReservasi";
            this.dgvReservasi.ReadOnly = true;
            this.dgvReservasi.Size = new System.Drawing.Size(560, 200);
            this.dgvReservasi.TabIndex = 0;
            this.dgvReservasi.SelectionChanged += new System.EventHandler(this.dgvReservasi_SelectionChanged);
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.picPreview);
            this.groupBox1.Controls.Add(this.txtBukti);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numOrang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpWaktu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbMeja);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbPelanggan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form Reservasi";
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(245, 155);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 22);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // picPreview
            //
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(235, 85);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(95, 60);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 12;
            this.picPreview.TabStop = false;
            //
            // txtBukti
            //
            this.txtBukti.Location = new System.Drawing.Point(100, 155);
            this.txtBukti.Name = "txtBukti";
            this.txtBukti.Size = new System.Drawing.Size(140, 20);
            this.txtBukti.TabIndex = 11;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bukti Transfer";
            //
            // numOrang
            //
            this.numOrang.Location = new System.Drawing.Point(100, 85);
            this.numOrang.Maximum = new decimal(new int[] {50, 0, 0, 0});
            this.numOrang.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numOrang.Name = "numOrang";
            this.numOrang.Size = new System.Drawing.Size(100, 20);
            this.numOrang.TabIndex = 9;
            this.numOrang.Value = new decimal(new int[] {1, 0, 0, 0});
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Jumlah Orang";
            //
            // dtpWaktu
            //
            this.dtpWaktu.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpWaktu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWaktu.Location = new System.Drawing.Point(100, 55);
            this.dtpWaktu.Name = "dtpWaktu";
            this.dtpWaktu.Size = new System.Drawing.Size(230, 20);
            this.dtpWaktu.TabIndex = 7;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Waktu Datang";
            //
            // cmbMeja
            //
            this.cmbMeja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeja.FormattingEnabled = true;
            this.cmbMeja.Location = new System.Drawing.Point(100, 25);
            this.cmbMeja.Name = "cmbMeja";
            this.cmbMeja.Size = new System.Drawing.Size(100, 21);
            this.cmbMeja.TabIndex = 3;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Meja";
            //
            // cmbPelanggan
            //
            this.cmbPelanggan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPelanggan.FormattingEnabled = true;
            this.cmbPelanggan.Location = new System.Drawing.Point(250, 25);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(85, 21);
            this.cmbPelanggan.TabIndex = 1;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pelgn";
            //
            // btnTambah
            //
            this.btnTambah.Location = new System.Drawing.Point(380, 12);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(85, 30);
            this.btnTambah.TabIndex = 2;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(380, 48);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 30);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnHapus
            //
            this.btnHapus.Location = new System.Drawing.Point(380, 84);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(85, 30);
            this.btnHapus.TabIndex = 4;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(380, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // txtCari
            //
            this.txtCari.Location = new System.Drawing.Point(370, 156);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(120, 20);
            this.txtCari.TabIndex = 6;
            //
            // btnCari
            //
            this.btnCari.Location = new System.Drawing.Point(496, 154);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(85, 30);
            this.btnCari.TabIndex = 7;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            //
            // bnReservasi
            //
            this.bnReservasi.AddNewItem = null;
            this.bnReservasi.CountItem = this.bindingNavigatorCountItem;
            this.bnReservasi.DeleteItem = null;
            this.bnReservasi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnReservasi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bnReservasi.Location = new System.Drawing.Point(0, 436);
            this.bnReservasi.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnReservasi.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnReservasi.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnReservasi.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnReservasi.Name = "bnReservasi";
            this.bnReservasi.PositionItem = this.bindingNavigatorPositionItem;
            this.bnReservasi.Size = new System.Drawing.Size(600, 25);
            this.bnReservasi.TabIndex = 8;
            this.bnReservasi.Text = "bindingNavigator1";
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 415);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 15);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total Reservasi: 0";
            //
            // ofdBukti
            //
            this.ofdBukti.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            this.ofdBukti.Title = "Pilih Bukti Transfer";
            //
            // FormReservasi
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 461);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.bnReservasi);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReservasi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormReservasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manajemen Reservasi";
            this.Load += new System.EventHandler(this.FormReservasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservasi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnReservasi)).EndInit();
            this.bnReservasi.ResumeLayout(false);
            this.bnReservasi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvReservasi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBukti;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numOrang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpWaktu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMeja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.BindingNavigator bnReservasi;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdBukti;
        private System.Windows.Forms.Label lblTotal;
    }
}
