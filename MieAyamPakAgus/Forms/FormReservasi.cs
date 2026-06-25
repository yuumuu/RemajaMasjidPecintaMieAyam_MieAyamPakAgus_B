using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;
using MieAyamPakAgus.Helpers;

namespace MieAyamPakAgus.Forms
{
    public partial class FormReservasi : Form
    {
        private readonly ReservasiBLL _bll = new ReservasiBLL();
        private readonly PelangganBLL _pBll = new PelangganBLL();
        private readonly MejaBLL _mBll = new MejaBLL();
        private BindingSource _bs = new BindingSource();

        public FormReservasi()
        {
            InitializeComponent();
            dgvReservasi.AutoGenerateColumns = true;
            dgvReservasi.DataError += dgvReservasi_DataError;
            dgvReservasi.DataSource = _bs;
            bnReservasi.BindingSource = _bs;
            dgvReservasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservasi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormReservasi_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
            BindControls();
            EnsureUploadsFolder();
        }

        private void EnsureUploadsFolder()
        {
            string path = Path.Combine(Application.StartupPath, "uploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private string GetUploadsFolder()
        {
            string path = Path.Combine(Application.StartupPath, "uploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        private void LoadComboBoxes()
        {
            cmbPelanggan.DataSource = _pBll.GetData();
            cmbPelanggan.DisplayMember = "nama";
            cmbPelanggan.ValueMember = "id_pelanggan";

            DataTable dtMeja = _mBll.GetData();
            cmbMeja.DataSource = dtMeja;
            cmbMeja.DisplayMember = "kode";
            cmbMeja.ValueMember = "id_meja";
        }

        private void BindControls()
        {
            dtpWaktu.DataBindings.Clear();
            numOrang.DataBindings.Clear();
            txtBukti.DataBindings.Clear();
            dtpWaktu.DataBindings.Add("Value", _bs, "waktu_kedatangan");
            numOrang.DataBindings.Add("Value", _bs, "jumlah_orang");
            txtBukti.DataBindings.Add("Text", _bs, "bukti_transaksi");
        }

        private void LoadData()
        {
            try
            {
                dgvReservasi.SuspendLayout();

                DataTable dt = _bll.GetData();

                if (dt == null)
                {
                    _bs.DataSource = null;
                    lblTotal.Text = "Total Reservasi: 0";
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                dgvReservasi.ClearSelection();
                dgvReservasi.CurrentCell = null;

                lblTotal.Text = "Total Reservasi: " + _bll.GetTotal();
                ClearForm();
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvReservasi.ResumeLayout();
            }
        }

        private void ClearForm()
        {
            FormHelper.ClearFormControls(groupBox1);
            if (cmbPelanggan.Items.Count > 0) cmbPelanggan.SelectedIndex = 0;
            if (cmbMeja.Items.Count > 0) cmbMeja.SelectedIndex = 0;
            dtpWaktu.Value = DateTime.Now.AddHours(1);
            numOrang.Value = 1;
            btnTambah.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private string CopyToUploads(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
                return sourcePath;

            string ext = Path.GetExtension(sourcePath);
            string fileName = Guid.NewGuid().ToString("N") + ext;
            string dest = Path.Combine(GetUploadsFolder(), fileName);
            File.Copy(sourcePath, dest, true);
            return "uploads/" + fileName;
        }

        private void ShowPreview(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                picPreview.Image = null;
                return;
            }

            string fullPath = path;
            if (!Path.IsPathRooted(path))
                fullPath = Path.Combine(Application.StartupPath, path);

            if (File.Exists(fullPath))
            {
                try
                {
                    picPreview.Image = System.Drawing.Image.FromFile(fullPath);
                }
                catch
                {
                    picPreview.Image = null;
                }
            }
            else
            {
                picPreview.Image = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdBukti.ShowDialog() == DialogResult.OK)
            {
                txtBukti.Text = ofdBukti.FileName;
                ShowPreview(ofdBukti.FileName);
            }
        }

        private string ValidateInput()
        {
            FormHelper.ClearErrors(groupBox1);

            if (cmbPelanggan.SelectedValue == null || cmbPelanggan.SelectedValue == DBNull.Value)
            {
                FormHelper.HighlightError(cmbPelanggan, true);
                return "Pilih pelanggan.";
            }

            if (cmbMeja.SelectedValue == null || cmbMeja.SelectedValue == DBNull.Value)
            {
                FormHelper.HighlightError(cmbMeja, true);
                return "Pilih meja.";
            }

            if (dtpWaktu.Value <= DateTime.Now)
            {
                FormHelper.HighlightError(dtpWaktu, true);
                return "Waktu kedatangan harus lebih dari waktu sekarang.";
            }

            string err = Validators.ValidateJumlahOrang((int)numOrang.Value);
            if (err != null) return err;

            return null;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string err = ValidateInput();
            if (err != null)
            {
                FormHelper.ShowError(err);
                return;
            }

            try
            {
                if (Session.IdUser <= 0)
                {
                    MessageBox.Show("Sesi login tidak valid. Silakan login ulang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idPel = Convert.ToInt32(cmbPelanggan.SelectedValue);
                int idMeja = Convert.ToInt32(cmbMeja.SelectedValue);
                string bukti = CopyToUploads(txtBukti.Text);

                if (_bll.AddReservasi(idPel, idMeja, dtpWaktu.Value, (int)numOrang.Value, bukti))
                {
                    MessageBox.Show("Reservasi berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg.Contains("FK_Reservasi_User") || msg.Contains("foreign key"))
                    msg = "Data reservasi gagal disimpan: sesi user tidak valid. Silakan login ulang.";
                else if (msg.Contains("UQ_Reservasi_Meja_Waktu") || msg.Contains("Cannot insert duplicate key"))
                    msg = "Meja sudah direservasi untuk waktu tersebut.";
                else if (msg.Contains("FK_Reservasi_Meja") || msg.Contains("FK_Reservasi_Pelanggan"))
                    msg = "Pelanggan atau meja yang dipilih tidak valid.";
                MessageBox.Show(msg, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string err = ValidateInput();
            if (err != null)
            {
                FormHelper.ShowError(err);
                return;
            }

            try
            {
                if (_bs.Current is System.Data.DataRowView row)
                {
                    int id = Convert.ToInt32(row["id_reservasi"]);
                    int idPel = Convert.ToInt32(cmbPelanggan.SelectedValue);
                    int idMeja = Convert.ToInt32(cmbMeja.SelectedValue);
                    string bukti = CopyToUploads(txtBukti.Text);

                    if (_bll.UpdateReservasi(id, idPel, idMeja, dtpWaktu.Value, (int)numOrang.Value, bukti))
                    {
                        MessageBox.Show("Reservasi berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg.Contains("UQ_Reservasi_Meja_Waktu") || msg.Contains("Cannot insert duplicate key"))
                    msg = "Meja sudah direservasi untuk waktu tersebut.";
                else if (msg.Contains("foreign key"))
                    msg = "Data tidak valid. Periksa kembali pelanggan dan meja yang dipilih.";
                MessageBox.Show(msg, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (_bs.Current == null) return;

            if (MessageBox.Show("Batalkan reservasi ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_reservasi"]);
                    if (_bll.DeleteReservasi(id))
                    {
                        MessageBox.Show("Reservasi berhasil dibatalkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (msg.Contains("foreign key"))
                        msg = "Tidak dapat menghapus reservasi karena terkait data lain.";
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReservasi.SuspendLayout();

                DataTable dt = _bll.Search(txtCari.Text.Trim());

                if (dt == null)
                {
                    _bs.DataSource = null;
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                dgvReservasi.ClearSelection();
                dgvReservasi.CurrentCell = null;
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvReservasi.ResumeLayout();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void dgvReservasi_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Count > 0 && _bs.Position >= 0 && _bs.Current is System.Data.DataRowView row)
            {
                cmbPelanggan.SelectedValue = row["id_pelanggan"];
                cmbMeja.SelectedValue = row["id_meja"];
                ShowPreview(row["bukti_transaksi"]?.ToString());

                btnTambah.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
                FormHelper.ClearErrors(groupBox1);
            }
            else
            {
                btnTambah.Enabled = true;
                btnUpdate.Enabled = false;
                btnHapus.Enabled = false;
            }
        }

        private void dgvReservasi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data error: " + e.Exception.Message,
                "DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }
    }
}
