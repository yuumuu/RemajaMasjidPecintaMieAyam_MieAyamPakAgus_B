namespace MieAyamPakAgus.Forms
{
    partial class FormLaporanReservasi
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbMeja = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSampai = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDari = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnExportPdf);
            this.pnlFilter.Controls.Add(this.btnGenerate);
            this.pnlFilter.Controls.Add(this.cmbMeja);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.cmbPelanggan);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.dtpSampai);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.dtpDari);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.pnlFilter.Size = new System.Drawing.Size(2400, 115);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Location = new System.Drawing.Point(1800, 29);
            this.btnExportPdf.Margin = new System.Windows.Forms.Padding(6);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(160, 54);
            this.btnExportPdf.TabIndex = 9;
            this.btnExportPdf.Text = "Export PDF";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Visible = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.Location = new System.Drawing.Point(1580, 29);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 54);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbMeja
            // 
            this.cmbMeja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeja.Location = new System.Drawing.Point(1300, 33);
            this.cmbMeja.Margin = new System.Windows.Forms.Padding(6);
            this.cmbMeja.Name = "cmbMeja";
            this.cmbMeja.Size = new System.Drawing.Size(236, 33);
            this.cmbMeja.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(1210, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Meja:";
            // 
            // cmbPelanggan
            // 
            this.cmbPelanggan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPelanggan.Location = new System.Drawing.Point(890, 33);
            this.cmbPelanggan.Margin = new System.Windows.Forms.Padding(6);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(296, 33);
            this.cmbPelanggan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(750, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pelanggan:";
            // 
            // dtpSampai
            // 
            this.dtpSampai.CustomFormat = "yyyy-MM-dd";
            this.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSampai.Location = new System.Drawing.Point(480, 35);
            this.dtpSampai.Margin = new System.Windows.Forms.Padding(6);
            this.dtpSampai.Name = "dtpSampai";
            this.dtpSampai.Size = new System.Drawing.Size(236, 31);
            this.dtpSampai.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(370, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sampai:";
            // 
            // dtpDari
            // 
            this.dtpDari.CustomFormat = "yyyy-MM-dd";
            this.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDari.Location = new System.Drawing.Point(110, 35);
            this.dtpDari.Margin = new System.Windows.Forms.Padding(6);
            this.dtpDari.Name = "dtpDari";
            this.dtpDari.Size = new System.Drawing.Size(236, 31);
            this.dtpDari.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dari:";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 115);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(6);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(2400, 1039);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormLaporanReservasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2400, 1154);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.pnlFilter);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormLaporanReservasi";
            this.Text = "Laporan Reservasi";
            this.Load += new System.EventHandler(this.FormLaporanReservasi_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DateTimePicker dtpDari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSampai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMeja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExportPdf;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}
