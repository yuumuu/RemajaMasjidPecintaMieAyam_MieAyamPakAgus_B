using System;
using System.Data;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;
using MieAyamPakAgus.Helpers;

namespace MieAyamPakAgus.Forms
{
    public partial class FormAdmin : Form
    {
        private readonly AdminBLL _bll = new AdminBLL();
        private BindingSource _bs = new BindingSource();

        public FormAdmin()
        {
            InitializeComponent();
            dgvAdmin.AutoGenerateColumns = true;
            dgvAdmin.DataError += dgvAdmin_DataError;
            dgvAdmin.DataSource = _bs;
            bnAdmin.BindingSource = _bs;
            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
            BindControls();
        }

        private void BindControls()
        {
            txtUsername.DataBindings.Clear();
            txtUsername.DataBindings.Add("Text", _bs, "username");
        }

        private void UnbindControls()
        {
            txtUsername.DataBindings.Clear();
        }

        private void LoadData()
        {
            try
            {
                dgvAdmin.SuspendLayout();

                UnbindControls();
                bnAdmin.BindingSource = null;

                DataTable dt = _bll.GetData();

                if (dt == null)
                {
                    _bs.DataSource = null;
                    lblTotal.Text = "Total Admin: 0";
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                bnAdmin.BindingSource = _bs;
                BindControls();

                dgvAdmin.ClearSelection();
                dgvAdmin.CurrentCell = null;

                lblTotal.Text = "Total Admin: " + _bll.GetTotal();
                ClearForm();
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvAdmin.ResumeLayout();
            }
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

            string err = Validators.ValidateUsername(txtUsername.Text);
            if (err != null) { FormHelper.HighlightError(txtUsername, true); return err; }

            err = Validators.ValidatePassword(txtPassword.Text);
            if (err != null) { FormHelper.HighlightError(txtPassword, true); return err; }

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
                if (_bll.AddAdmin(txtUsername.Text.Trim(), txtPassword.Text))
                {
                    MessageBox.Show("Data admin berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    int id = Convert.ToInt32(row["id_user"]);
                    if (_bll.UpdateAdmin(id, txtUsername.Text.Trim(), txtPassword.Text))
                    {
                        MessageBox.Show("Data admin berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (MessageBox.Show("Yakin ingin menghapus admin ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_user"]);
                    if (_bll.DeleteAdmin(id))
                    {
                        MessageBox.Show("Data admin berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvAdmin.SuspendLayout();

                UnbindControls();
                bnAdmin.BindingSource = null;

                DataTable dt = _bll.SearchAdmin(txtCari.Text.Trim());

                if (dt == null)
                {
                    _bs.DataSource = null;
                    return;
                }

                _bs.DataSource = null;
                _bs.DataSource = dt;

                bnAdmin.BindingSource = _bs;
                BindControls();

                dgvAdmin.ClearSelection();
                dgvAdmin.CurrentCell = null;
            }
            catch (Exception ex)
            {
                _bs.DataSource = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvAdmin.ResumeLayout();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
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

        private void dgvAdmin_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data error: " + e.Exception.Message,
                "DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }
    }
}
