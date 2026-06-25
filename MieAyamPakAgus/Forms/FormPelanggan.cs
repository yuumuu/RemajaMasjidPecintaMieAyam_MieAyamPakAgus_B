using System;
using System.Data;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;
using MieAyamPakAgus.Helpers;

namespace MieAyamPakAgus.Forms
{
    public partial class FormPelanggan : Form
    {
        private readonly PelangganBLL _bll = new PelangganBLL();
        private BindingSource _bs = new BindingSource();

        public FormPelanggan()
        {
            InitializeComponent();
            dgvPelanggan.AutoGenerateColumns = true;
            dgvPelanggan.DataError += dgvPelanggan_DataError;
            dgvPelanggan.DataSource = _bs;
            bnPelanggan.BindingSource = _bs;
            dgvPelanggan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPelanggan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormPelanggan_Load(object sender, EventArgs e)
        {
            LoadData();
            BindControls();
        }

        private void BindControls()
        {
            txtNama.DataBindings.Clear();
            txtNoTelp.DataBindings.Clear();
            txtNama.DataBindings.Add("Text", _bs, "nama");
            txtNoTelp.DataBindings.Add("Text", _bs, "no_telepon");
        }

        private void UnbindControls()
        {
            txtNama.DataBindings.Clear();
            txtNoTelp.DataBindings.Clear();
        }

        private void LoadData()
        {
            try
            {
                dgvPelanggan.SuspendLayout();

                UnbindControls();
                bnPelanggan.BindingSource = null;

                DataTable dt = _bll.GetData();

                if (dt == null)
                {
                    _bs.DataSource = null;
                    lblTotal.Text = "Total Pelanggan: 0";
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                bnPelanggan.BindingSource = _bs;
                BindControls();

                HideIdColumns();

                dgvPelanggan.ClearSelection();
                dgvPelanggan.CurrentCell = null;

                lblTotal.Text = "Total Pelanggan: " + _bll.GetTotal();
                ClearForm();
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvPelanggan.ResumeLayout();
            }
        }

        private void HideIdColumns()
        {
            if (dgvPelanggan.Columns.Contains("id_pelanggan"))
                dgvPelanggan.Columns["id_pelanggan"].Visible = false;
        }

        private void ClearForm()
        {
            FormHelper.ClearFormControls(groupBox1);
            btnTambah.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private string ValidateInput()
        {
            FormHelper.ClearErrors(groupBox1);

            string err = Validators.ValidateName(txtNama.Text.Trim());
            if (err != null) { FormHelper.HighlightError(txtNama, true); return err; }

            err = Validators.ValidatePhone(txtNoTelp.Text.Trim());
            if (err != null) { FormHelper.HighlightError(txtNoTelp, true); return err; }

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
                if (_bll.AddPelanggan(txtNama.Text.Trim(), txtNoTelp.Text.Trim()))
                {
                    MessageBox.Show("Pelanggan berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    int id = Convert.ToInt32(row["id_pelanggan"]);
                    if (_bll.UpdatePelanggan(id, txtNama.Text.Trim(), txtNoTelp.Text.Trim()))
                    {
                        MessageBox.Show("Data pelanggan diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
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

            if (MessageBox.Show("Hapus pelanggan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_pelanggan"]);
                    if (_bll.DeletePelanggan(id))
                    {
                        MessageBox.Show("Data pelanggan berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvPelanggan.SuspendLayout();

                UnbindControls();
                bnPelanggan.BindingSource = null;

                DataTable dt = _bll.Search(txtCari.Text.Trim());

                if (dt == null)
                {
                    _bs.DataSource = null;
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                bnPelanggan.BindingSource = _bs;
                BindControls();
                HideIdColumns();

                dgvPelanggan.ClearSelection();
                dgvPelanggan.CurrentCell = null;
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvPelanggan.ResumeLayout();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPelanggan_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Count > 0 && _bs.Position >= 0 && _bs.Current != null)
            {
                FormHelper.ClearErrors(groupBox1);
                btnTambah.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
            }
            else
            {
                btnTambah.Enabled = true;
                btnUpdate.Enabled = false;
                btnHapus.Enabled = false;
            }
        }

        private void dgvPelanggan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data error: " + e.Exception.Message,
                "DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }
    }
}
