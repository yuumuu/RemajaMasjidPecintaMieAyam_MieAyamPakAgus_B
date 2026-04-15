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
            this.LblMeja = new System.Windows.Forms.Label();
            this.LblTitlePage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.LogoApp = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMeja
            // 
            this.LblMeja.AutoSize = true;
            this.LblMeja.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMeja.Location = new System.Drawing.Point(97, 166);
            this.LblMeja.Margin = new System.Windows.Forms.Padding(10);
            this.LblMeja.MaximumSize = new System.Drawing.Size(370, 65);
            this.LblMeja.MinimumSize = new System.Drawing.Size(370, 65);
            this.LblMeja.Name = "LblMeja";
            this.LblMeja.Padding = new System.Windows.Forms.Padding(10);
            this.LblMeja.Size = new System.Drawing.Size(370, 65);
            this.LblMeja.TabIndex = 0;
            this.LblMeja.Text = "Meja";
            // 
            // LblTitlePage
            // 
            this.LblTitlePage.AutoSize = true;
            this.LblTitlePage.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitlePage.Location = new System.Drawing.Point(490, 81);
            this.LblTitlePage.MaximumSize = new System.Drawing.Size(400, 65);
            this.LblTitlePage.MinimumSize = new System.Drawing.Size(400, 65);
            this.LblTitlePage.Name = "LblTitlePage";
            this.LblTitlePage.Size = new System.Drawing.Size(400, 65);
            this.LblTitlePage.TabIndex = 2;
            this.LblTitlePage.Text = "Title Page";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 251);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.MaximumSize = new System.Drawing.Size(370, 65);
            this.label1.MinimumSize = new System.Drawing.Size(370, 65);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(370, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reservasi";
            // 
            // BtnShow
            // 
            this.BtnShow.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(500, 166);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(234, 65);
            this.BtnShow.TabIndex = 4;
            this.BtnShow.Text = "Show Data";
            this.BtnShow.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Location = new System.Drawing.Point(752, 166);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(234, 65);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Add Data";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(1005, 166);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(234, 65);
            this.BtnEdit.TabIndex = 6;
            this.BtnEdit.Text = "Edit Data";
            this.BtnEdit.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(1257, 166);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(234, 65);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "Delete Data";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToOrderColumns = true;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Location = new System.Drawing.Point(500, 255);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersWidth = 82;
            this.DataTable.RowTemplate.Height = 33;
            this.DataTable.Size = new System.Drawing.Size(1194, 773);
            this.DataTable.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bricolage Grotesque 14pt", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImageKey = "RehanWangsaf.png";
            this.label2.ImageList = this.LogoApp;
            this.label2.Location = new System.Drawing.Point(97, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.MaximumSize = new System.Drawing.Size(370, 65);
            this.label2.MinimumSize = new System.Drawing.Size(370, 65);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10);
            this.label2.Size = new System.Drawing.Size(370, 65);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mie Ayam Pak Agus";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogoApp
            // 
            this.LogoApp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LogoApp.ImageStream")));
            this.LogoApp.TransparentColor = System.Drawing.Color.Transparent;
            this.LogoApp.Images.SetKeyName(0, "RehanWangsaf.png");
            // 
            // CRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 1129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitlePage);
            this.Controls.Add(this.LblMeja);
            this.Name = "CRUDForm";
            this.Text = "CRUD Form";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblMeja;
        private System.Windows.Forms.Label LblTitlePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList LogoApp;
    }
}