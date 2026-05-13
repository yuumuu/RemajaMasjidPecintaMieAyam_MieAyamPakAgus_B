using System;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

namespace MieAyamPakAgus.Forms
{
    public partial class FormPelanggan : Form
    {
        private readonly PelangganBLL _bll = new PelangganBLL();
        private BindingSource _bs = new BindingSource();

        public FormPelanggan()
        {
            InitializeComponent();
            dgvPelanggan.DataSource = _bs;
            bnPelanggan.BindingSource = _bs;
        }

        private void FormPelanggan_Load(object sender, EventArgs e)
        {
            RefreshData();
            BindControls();
        }

        private void BindControls()
        {
            txtNama.DataBindings.Clear();
            txtNoTelp.DataBindings.Clear();
            txtNama.DataBindings.Add("Text", _bs, "nama");
            txtNoTelp.DataBindings.Add("Text", _bs, "no_telepon");
        }

        private void RefreshData()
        {
            try
            {
                _bs.DataSource = _bll.GetData();
                lblTotal.Text = "Total Pelanggan: " + _bll.GetTotal();
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
                if (_bll.AddPelanggan(txtNama.Text, txtNoTelp.Text))
                {
                    MessageBox.Show("Pelanggan berhasil ditambahkan!");
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
                    int id = Convert.ToInt32(row["id_pelanggan"]);
                    if (_bll.UpdatePelanggan(id, txtNama.Text, txtNoTelp.Text))
                    {
                        MessageBox.Show("Data pelanggan diperbarui!");
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

            if (MessageBox.Show("Hapus pelanggan ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_pelanggan"]);
                    if (_bll.DeletePelanggan(id))
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dgvPelanggan_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Current != null)
            {
                btnTambah.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
            }
        }
    }
}
