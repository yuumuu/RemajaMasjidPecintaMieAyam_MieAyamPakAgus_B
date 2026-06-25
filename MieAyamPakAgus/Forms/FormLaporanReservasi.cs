using System;
using System.Data;
using System.Windows.Forms;
using MieAyamPakAgus;
using MieAyamPakAgus.BLL;
using CrystalDecisions.Shared;

namespace MieAyamPakAgus.Forms
{
    public partial class FormLaporanReservasi : Form
    {
        private readonly ReservasiReportBLL _bll = new ReservasiReportBLL();
        private LaporanReservasi _report;

        public FormLaporanReservasi()
        {
            InitializeComponent();
        }

        private void FormLaporanReservasi_Load(object sender, EventArgs e)
        {
            LoadFilterComboBoxes();
            dtpDari.Value = DateTime.Today.AddDays(-30);
            dtpSampai.Value = DateTime.Today.AddDays(30);
        }

        private void LoadFilterComboBoxes()
        {
            try
            {
                DataTable dtPelanggan = _bll.GetPelangganLookup();
                DataRow rowAllPel = dtPelanggan.NewRow();
                rowAllPel["id_pelanggan"] = DBNull.Value;
                rowAllPel["nama"] = "-- Semua Pelanggan --";
                dtPelanggan.Rows.InsertAt(rowAllPel, 0);

                cmbPelanggan.DataSource = dtPelanggan;
                cmbPelanggan.DisplayMember = "nama";
                cmbPelanggan.ValueMember = "id_pelanggan";

                DataTable dtMeja = _bll.GetMejaLookup();
                DataRow rowAllMeja = dtMeja.NewRow();
                rowAllMeja["id_meja"] = DBNull.Value;
                rowAllMeja["kode"] = "-- Semua Meja --";
                dtMeja.Rows.InsertAt(rowAllMeja, 0);

                cmbMeja.DataSource = dtMeja;
                cmbMeja.DisplayMember = "kode";
                cmbMeja.ValueMember = "id_meja";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? tglAwal = dtpDari.Checked ? dtpDari.Value : (DateTime?)null;
                DateTime? tglAkhir = dtpSampai.Checked ? dtpSampai.Value : (DateTime?)null;
                int? idPel = cmbPelanggan.SelectedValue != null && cmbPelanggan.SelectedValue != DBNull.Value
                    ? Convert.ToInt32(cmbPelanggan.SelectedValue) : (int?)null;
                int? idMeja = cmbMeja.SelectedValue != null && cmbMeja.SelectedValue != DBNull.Value
                    ? Convert.ToInt32(cmbMeja.SelectedValue) : (int?)null;

                DataTable data = _bll.GetReportData(tglAwal, tglAkhir, idPel, idMeja);
                ShowReport(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowReport(DataTable data)
        {
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ditemukan", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_report != null)
            {
                _report.Close();
                _report.Dispose();
            }

            var report = new LaporanReservasi();
            report.SetDataSource(data);

            _report = report;
            crystalReportViewer1.ReportSource = _report;
            crystalReportViewer1.Refresh();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (_report == null)
            {
                MessageBox.Show("Tidak ada laporan untuk diexport. Generate laporan terlebih dahulu.",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = "Laporan_Reservasi_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _report.ExportToDisk(ExportFormatType.PortableDocFormat, sfd.FileName);
                    MessageBox.Show("Laporan berhasil diexport ke PDF.", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal export: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_report == null)
            {
                MessageBox.Show("Tidak ada laporan untuk dicetak. Generate laporan terlebih dahulu.",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _report.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_report != null)
            {
                _report.Close();
                _report.Dispose();
                _report = null;
            }
            base.OnFormClosed(e);
        }
    }
}
