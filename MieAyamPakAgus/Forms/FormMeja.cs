using System;
using System.Data;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;
using MieAyamPakAgus.Helpers;

namespace MieAyamPakAgus.Forms
{
    public partial class FormMeja : Form
    {
        private readonly MejaBLL _bll = new MejaBLL();
        private BindingSource _bs = new BindingSource();

        public FormMeja()
        {
            InitializeComponent();
            dgvMeja.AutoGenerateColumns = true;
            dgvMeja.DataError += dgvMeja_DataError;
            dgvMeja.DataSource = _bs;
            bnMeja.BindingSource = _bs;
            dgvMeja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMeja.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormMeja_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void UnbindControls()
        {
            txtKode.DataBindings.Clear();
            numKapasitas.DataBindings.Clear();
            cmbStatus.DataBindings.Clear();
        }

        private void LoadData()
        {
            try
            {
                dgvMeja.SuspendLayout();

                UnbindControls();
                bnMeja.BindingSource = null;

                DataTable dt = _bll.GetData();

                if (dt == null)
                {
                    _bs.DataSource = null;
                    lblTotal.Text = "Total Meja: 0";
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                bnMeja.BindingSource = _bs;
                BindControls();

                HideIdColumns();

                dgvMeja.ClearSelection();
                dgvMeja.CurrentCell = null;

                lblTotal.Text = "Total Meja: " + _bll.GetTotal();
                ClearForm();
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvMeja.ResumeLayout();
            }
        }

        private void HideIdColumns()
        {
            if (dgvMeja.Columns.Contains("id_meja"))
                dgvMeja.Columns["id_meja"].Visible = false;
        }

        private void ClearForm()
        {
            FormHelper.ClearFormControls(groupBox1);
            // Ensure cmbStatus has items before selecting the first item
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
            else
                cmbStatus.SelectedIndex = -1;
            btnTambah.Enabled = true;
            btnUpdateStatus.Enabled = false;
            btnHapus.Enabled = false;
        }

        private string ValidateInput()
        {
            FormHelper.ClearErrors(groupBox1);

            string err = Validators.ValidateKodeMeja(txtKode.Text.Trim());
            if (err != null) { FormHelper.HighlightError(txtKode, true); return err; }

            if ((int)numKapasitas.Value < 1)
            {
                FormHelper.HighlightError(numKapasitas, true);
                return "Kapasitas meja minimal 1.";
            }

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
                if (_bll.AddMeja(txtKode.Text.Trim(), (int)numKapasitas.Value))
                {
                    MessageBox.Show("Meja berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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
                    string newStatus = cmbStatus.SelectedItem.ToString();
                    if (_bll.UpdateStatus(id, newStatus))
                    {
                        MessageBox.Show("Status meja diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (MessageBox.Show("Hapus meja ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_meja"]);
                    if (_bll.DeleteMeja(id))
                    {
                        MessageBox.Show("Meja berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvMeja.SuspendLayout();

                UnbindControls();
                bnMeja.BindingSource = null;

                DataTable dt = _bll.Search(txtCari.Text.Trim());

                if (dt == null)
                {
                    _bs.DataSource = null;
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                bnMeja.BindingSource = _bs;
                BindControls();
                HideIdColumns();

                dgvMeja.ClearSelection();
                dgvMeja.CurrentCell = null;
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvMeja.ResumeLayout();
            }
        }

        private void dgvMeja_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Count > 0 && _bs.Position >= 0 && _bs.Current != null)
            {
                FormHelper.ClearErrors(groupBox1);
                btnTambah.Enabled = false;
                btnUpdateStatus.Enabled = true;
                btnHapus.Enabled = true;
            }
            else
            {
                btnTambah.Enabled = true;
                btnUpdateStatus.Enabled = false;
                btnHapus.Enabled = false;
            }
        }

        private void dgvMeja_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data error: " + e.Exception.Message,
                "DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
