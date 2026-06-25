namespace MieAyamPakAgus.Forms
{
    partial class FormImport
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
            this.chkModePelanggan = new System.Windows.Forms.RadioButton();
            this.chkModeReservasi = new System.Windows.Forms.RadioButton();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.lblStatusPreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // chkModePelanggan
            // 
            this.chkModePelanggan.AutoSize = true;
            this.chkModePelanggan.Checked = true;
            this.chkModePelanggan.Location = new System.Drawing.Point(12, 12);
            this.chkModePelanggan.Name = "chkModePelanggan";
            this.chkModePelanggan.Size = new System.Drawing.Size(108, 17);
            this.chkModePelanggan.TabIndex = 0;
            this.chkModePelanggan.TabStop = true;
            this.chkModePelanggan.Text = "Import Pelanggan";
            this.chkModePelanggan.UseVisualStyleBackColor = true;
            this.chkModePelanggan.CheckedChanged += new System.EventHandler(this.chkModePelanggan_CheckedChanged);
            // 
            // chkModeReservasi
            // 
            this.chkModeReservasi.AutoSize = true;
            this.chkModeReservasi.Location = new System.Drawing.Point(130, 12);
            this.chkModeReservasi.Name = "chkModeReservasi";
            this.chkModeReservasi.Size = new System.Drawing.Size(109, 17);
            this.chkModeReservasi.TabIndex = 1;
            this.chkModeReservasi.Text = "Import Reservasi";
            this.chkModeReservasi.UseVisualStyleBackColor = true;
            this.chkModeReservasi.CheckedChanged += new System.EventHandler(this.chkModeReservasi_CheckedChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 40);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(380, 20);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(398, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(12, 70);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.Size = new System.Drawing.Size(560, 260);
            this.dgvPreview.TabIndex = 4;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(500, 340);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 30);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel Files|*.xls;*.xlsx";
            this.ofdExcel.Title = "Pilih file Excel";
            // 
            // lblStatusPreview
            // 
            this.lblStatusPreview.AutoSize = true;
            this.lblStatusPreview.Location = new System.Drawing.Point(12, 345);
            this.lblStatusPreview.Name = "lblStatusPreview";
            this.lblStatusPreview.Size = new System.Drawing.Size(82, 13);
            this.lblStatusPreview.TabIndex = 6;
            this.lblStatusPreview.Text = "No data loaded";
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 385);
            this.Controls.Add(this.lblStatusPreview);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.chkModeReservasi);
            this.Controls.Add(this.chkModePelanggan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Data dari Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RadioButton chkModePelanggan;
        private System.Windows.Forms.RadioButton chkModeReservasi;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Label lblStatusPreview;
    }
}
