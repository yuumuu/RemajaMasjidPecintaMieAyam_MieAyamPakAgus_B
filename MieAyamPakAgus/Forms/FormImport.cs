using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

namespace MieAyamPakAgus.Forms
{
    public partial class FormImport : Form
    {
        private readonly PelangganBLL _pelBll = new PelangganBLL();
        private readonly ReservasiBLL _resBll = new ReservasiBLL();
        private DataTable _previewTable;

        public FormImport()
        {
            InitializeComponent();
        }

        private void chkModePelanggan_CheckedChanged(object sender, EventArgs e)
        {
            chkModeReservasi.Checked = !chkModePelanggan.Checked;
            _previewTable = null;
            dgvPreview.DataSource = null;
        }

        private void chkModeReservasi_CheckedChanged(object sender, EventArgs e)
        {
            chkModePelanggan.Checked = !chkModeReservasi.Checked;
            _previewTable = null;
            dgvPreview.DataSource = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdExcel.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofdExcel.FileName;
                PreviewExcel(ofdExcel.FileName);
            }
        }

        private DataTable ReadExcel(string filePath)
        {
            string connStr;
            if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES';";
            else
                connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES';";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                DataTable sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = sheets.Rows[0]["TABLE_NAME"].ToString();
                string query = $"SELECT * FROM [{sheetName}]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        private void PreviewExcel(string filePath)
        {
            try
            {
                _previewTable = ReadExcel(filePath);
                dgvPreview.DataSource = _previewTable;
                lblStatusPreview.Text = $"Loaded: {_previewTable.Rows.Count} rows";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca file Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (_previewTable == null || _previewTable.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diimport.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Import {_previewTable.Rows.Count} baris data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int success, failed;

                if (chkModePelanggan.Checked)
                {
                    var result = _pelBll.ImportExcel(_previewTable);
                    success = result.success;
                    failed = result.failed;
                }
                else
                {
                    var result = _resBll.ImportExcel(_previewTable);
                    success = result.success;
                    failed = result.failed;
                }

                MessageBox.Show($"Import selesai!\nBerhasil: {success}\nGagal: {failed}", "Hasil Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _previewTable = null;
                dgvPreview.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
