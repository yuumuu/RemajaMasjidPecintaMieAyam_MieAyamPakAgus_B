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
            this.BtnShow = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.LblLogo = new System.Windows.Forms.Label();
            this.LogoApp = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabMeja = new System.Windows.Forms.TabPage();
            this.TabReservasi = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitlePage
            // 
            this.LblTitlePage.AutoSize = true;
            this.LblTitlePage.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitlePage.Location = new System.Drawing.Point(546, 76);
            this.LblTitlePage.MaximumSize = new System.Drawing.Size(400, 65);
            this.LblTitlePage.MinimumSize = new System.Drawing.Size(400, 65);
            this.LblTitlePage.Name = "LblTitlePage";
            this.LblTitlePage.Size = new System.Drawing.Size(400, 65);
            this.LblTitlePage.TabIndex = 2;
            this.LblTitlePage.Text = "Title Page";
            // 
            // BtnShow
            // 
            this.BtnShow.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(556, 161);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(191, 61);
            this.BtnShow.TabIndex = 4;
            this.BtnShow.Text = "Show Data";
            this.BtnShow.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Location = new System.Drawing.Point(808, 161);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(191, 61);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Add Data";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(1061, 161);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(191, 61);
            this.BtnEdit.TabIndex = 6;
            this.BtnEdit.Text = "Edit Data";
            this.BtnEdit.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(1313, 161);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(191, 61);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "Delete Data";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToOrderColumns = true;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Location = new System.Drawing.Point(556, 250);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersWidth = 82;
            this.DataTable.RowTemplate.Height = 33;
            this.DataTable.Size = new System.Drawing.Size(1194, 773);
            this.DataTable.TabIndex = 8;
            // 
            // LblLogo
            // 
            this.LblLogo.AutoSize = true;
            this.LblLogo.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 12F, System.Drawing.FontStyle.Bold);
            this.LblLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblLogo.ImageKey = "RehanWangsaf.png";
            this.LblLogo.ImageList = this.LogoApp;
            this.LblLogo.Location = new System.Drawing.Point(73, 81);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabMeja);
            this.tabControl1.Controls.Add(this.TabReservasi);
            this.tabControl1.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(72, 166);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 865);
            this.tabControl1.TabIndex = 9;
            // 
            // TabMeja
            // 
            this.TabMeja.Location = new System.Drawing.Point(8, 58);
            this.TabMeja.Name = "TabMeja";
            this.TabMeja.Padding = new System.Windows.Forms.Padding(3);
            this.TabMeja.Size = new System.Drawing.Size(443, 799);
            this.TabMeja.TabIndex = 0;
            this.TabMeja.Text = "Meja";
            this.TabMeja.UseVisualStyleBackColor = true;
            // 
            // TabReservasi
            // 
            this.TabReservasi.Location = new System.Drawing.Point(8, 58);
            this.TabReservasi.Name = "TabReservasi";
            this.TabReservasi.Padding = new System.Windows.Forms.Padding(3);
            this.TabReservasi.Size = new System.Drawing.Size(443, 799);
            this.TabReservasi.TabIndex = 1;
            this.TabReservasi.Text = "Reservasi";
            this.TabReservasi.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1568, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1814, 1129);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.LblLogo);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.LblTitlePage);
            this.Name = "CRUDForm";
            this.Text = "CRUD Form";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblTitlePage;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Label LblLogo;
        private System.Windows.Forms.ImageList LogoApp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabMeja;
        private System.Windows.Forms.TabPage TabReservasi;
        private System.Windows.Forms.Button button1;
    }
}