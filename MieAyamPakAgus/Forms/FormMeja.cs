using System;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

namespace MieAyamPakAgus.Forms
{
    public partial class FormMeja : Form
    {
        private readonly MejaBLL _bll = new MejaBLL();
        private BindingSource _bs = new BindingSource();

        public FormMeja()
        {
            InitializeComponent();
            dgvMeja.DataSource = _bs;
            bnMeja.BindingSource = _bs;
            cmbStatus.Items.AddRange(new object[] { "Tersedia", "Terisi", "Dipesan" });
        }

        private void FormMeja_Load(object sender, EventArgs e)
        {
            RefreshData();
            BindControls();
        }

        private void BindControls()
        {
            txtKode.DataBindings.Clear();
            numKapasitas.DataBindings.Clear();
            cmbStatus.DataBindings.Clear();
            txtKode.DataBindings.Add("Text", _bs, "kode");
            numKapasitas.DataBindings.Add("Value", _bs, "kapasitas");
            cmbStatus.DataBindings.Add("SelectedItem", _bs, "status_meja");
        }

        private void RefreshData()
        {
            try
            {
                _bs.DataSource = _bll.GetData();
                lblTotal.Text = "Total Meja: " + _bll.GetTotal();
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
            btnUpdateStatus.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bll.AddMeja(txtKode.Text, (int)numKapasitas.Value))
                {
                    MessageBox.Show("Meja berhasil ditambahkan!");
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bs.Current is System.Data.DataRowView row)
                {
                    int id = Convert.ToInt32(row["id_meja"]);
                    if (_bll.UpdateStatus(id, cmbStatus.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Status meja diperbarui!");
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

            if (MessageBox.Show("Hapus meja ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_meja"]);
                    if (_bll.DeleteMeja(id))
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

        private void dgvMeja_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Current != null)
            {
                btnTambah.Enabled = false;
                btnUpdateStatus.Enabled = true;
                btnHapus.Enabled = true;
            }
        }
    }
}
