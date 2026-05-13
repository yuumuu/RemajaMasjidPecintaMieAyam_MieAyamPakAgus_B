using System;
using System.Data;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

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
            dgvReservasi.DataSource = _bs;
            bnReservasi.BindingSource = _bs;
        }

        private void FormReservasi_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            RefreshData();
            BindControls();
        }

        private void LoadComboBoxes()
        {
            cmbPelanggan.DataSource = _pBll.GetData();
            cmbPelanggan.DisplayMember = "nama";
            cmbPelanggan.ValueMember = "id_pelanggan";

            cmbMeja.DataSource = _mBll.GetData();
            cmbMeja.DisplayMember = "kode";
            cmbMeja.ValueMember = "id_meja";
        }

        private void BindControls()
        {
            dtpWaktu.DataBindings.Clear();
            numOrang.DataBindings.Clear();
            txtBukti.DataBindings.Clear();
            
            // Note: DataBindings for ComboBox ValueMember requires careful handling
            // Usually we bind to SelectedValue
            cmbPelanggan.DataBindings.Clear();
            cmbMeja.DataBindings.Clear();
            
            dtpWaktu.DataBindings.Add("Value", _bs, "waktu_kedatangan");
            numOrang.DataBindings.Add("Value", _bs, "jumlah_orang");
            txtBukti.DataBindings.Add("Text", _bs, "bukti_transaksi");
            
            // Manual selection in SelectionChanged is often more reliable for FK ComboBoxes in simple WinForms
        }

        private void RefreshData()
        {
            try
            {
                _bs.DataSource = _bll.GetData();
                lblTotal.Text = "Total Reservasi: " + _bll.GetTotal();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            btnTambah.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                int idPel = Convert.ToInt32(cmbPelanggan.SelectedValue);
                int idMeja = Convert.ToInt32(cmbMeja.SelectedValue);
                if (_bll.AddReservasi(idPel, idMeja, dtpWaktu.Value, (int)numOrang.Value, txtBukti.Text))
                {
                    MessageBox.Show("Reservasi berhasil ditambahkan!");
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bs.Current is System.Data.DataRowView row)
                {
                    int id = Convert.ToInt32(row["id_reservasi"]);
                    int idPel = Convert.ToInt32(cmbPelanggan.SelectedValue);
                    int idMeja = Convert.ToInt32(cmbMeja.SelectedValue);
                    if (_bll.UpdateReservasi(id, idPel, idMeja, dtpWaktu.Value, (int)numOrang.Value, txtBukti.Text))
                    {
                        MessageBox.Show("Reservasi berhasil diperbarui!");
                        RefreshData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (_bs.Current == null) return;

            if (MessageBox.Show("Batalkan reservasi ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_reservasi"]);
                    if (_bll.DeleteReservasi(id))
                    {
                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            _bs.DataSource = _bll.Search(txtCari.Text);
        }

        private void dgvReservasi_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Current is System.Data.DataRowView row)
            {
                // Manual ComboBox update since automatic binding to ValueMember can be flaky
                cmbPelanggan.SelectedValue = row["id_pelanggan"];
                cmbMeja.SelectedValue = row["id_meja"];

                btnTambah.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
            }
        }
    }
}
