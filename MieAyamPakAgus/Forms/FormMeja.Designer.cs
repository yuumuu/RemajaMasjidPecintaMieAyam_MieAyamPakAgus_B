namespace MieAyamPakAgus.Forms
{
    partial class FormMeja
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
            this.dgvMeja = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numKapasitas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.bnMeja = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeja)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKapasitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnMeja)).BeginInit();
            this.bnMeja.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMeja
            // 
            this.dgvMeja.AllowUserToAddRows = false;
            this.dgvMeja.AllowUserToDeleteRows = false;
            this.dgvMeja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeja.Location = new System.Drawing.Point(24, 337);
            this.dgvMeja.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvMeja.Name = "dgvMeja";
            this.dgvMeja.ReadOnly = true;
            this.dgvMeja.RowHeadersWidth = 82;
            this.dgvMeja.Size = new System.Drawing.Size(1120, 423);
            this.dgvMeja.TabIndex = 0;
            this.dgvMeja.SelectionChanged += new System.EventHandler(this.dgvMeja_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numKapasitas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(700, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Meja";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(200, 173);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(456, 33);
            this.cmbStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status";
            // 
            // numKapasitas
            // 
            this.numKapasitas.Location = new System.Drawing.Point(200, 112);
            this.numKapasitas.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numKapasitas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKapasitas.Name = "numKapasitas";
            this.numKapasitas.Size = new System.Drawing.Size(240, 31);
            this.numKapasitas.TabIndex = 3;
            this.numKapasitas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kapasitas";
            // 
            // txtKode
            // 
            this.txtKode.Location = new System.Drawing.Point(200, 48);
            this.txtKode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtKode.MaxLength = 5;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(236, 31);
            this.txtKode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(760, 23);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(170, 58);
            this.btnTambah.TabIndex = 2;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(760, 92);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(170, 58);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "Update";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(760, 162);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(170, 58);
            this.btnHapus.TabIndex = 4;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(760, 231);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(170, 58);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(740, 300);
            this.txtCari.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(236, 31);
            this.txtCari.TabIndex = 6;
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(992, 296);
            this.btnCari.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(170, 58);
            this.btnCari.TabIndex = 7;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // bnMeja
            // 
            this.bnMeja.AddNewItem = null;
            this.bnMeja.CountItem = this.bindingNavigatorCountItem;
            this.bnMeja.DeleteItem = null;
            this.bnMeja.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnMeja.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.bnMeja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bnMeja.Location = new System.Drawing.Point(0, 809);
            this.bnMeja.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnMeja.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnMeja.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnMeja.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnMeja.Name = "bnMeja";
            this.bnMeja.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.bnMeja.PositionItem = this.bindingNavigatorPositionItem;
            this.bnMeja.Size = new System.Drawing.Size(1200, 39);
            this.bnMeja.TabIndex = 8;
            this.bnMeja.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(70, 33);
            this.bindingNavigatorCountItem.Text = "of {0}";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(46, 33);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(46, 33);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(196, 39);
            this.bindingNavigatorPositionItem.Text = "0";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(46, 33);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(46, 33);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(24, 769);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(165, 29);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total Meja: 0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(554, 273);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 58);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormMeja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 848);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.bnMeja);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMeja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FormMeja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manajemen Meja";
            this.Load += new System.EventHandler(this.FormMeja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeja)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKapasitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnMeja)).EndInit();
            this.bnMeja.ResumeLayout(false);
            this.bnMeja.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvMeja;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numKapasitas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.BindingNavigator bnMeja;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRefresh;
    }
}
