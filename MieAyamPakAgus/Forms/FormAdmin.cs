using System;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

namespace MieAyamPakAgus.Forms
{
    public partial class FormAdmin : Form
    {
        private readonly AdminBLL _bll = new AdminBLL();
        private BindingSource _bs = new BindingSource();

        public FormAdmin()
        {
            InitializeComponent();
            dgvAdmin.DataSource = _bs;
            bnAdmin.BindingSource = _bs;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            RefreshData();
            BindControls();
        }

        private void BindControls()
        {
            txtUsername.DataBindings.Clear();
            // Password not bound for security, usually handled manually on insert/update
            txtUsername.DataBindings.Add("Text", _bs, "username");
        }

        private void RefreshData()
        {
            try
            {
                _bs.DataSource = _bll.GetData();
                lblTotal.Text = "Total Admin: " + _bll.GetTotal();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            // Note: with binding, clearing might need to be handled by adding a new record to BS
            // but for simplicity in this 3-layer setup, we can just clear UI if needed.
            // However, BindControls means UI reflects BS.Current.
            
            btnTambah.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bll.AddAdmin(txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show("Data admin berhasil ditambahkan!");
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
                    int id = Convert.ToInt32(row["id_user"]);
                    if (_bll.UpdateAdmin(id, txtUsername.Text, txtPassword.Text))
                    {
                        MessageBox.Show("Data admin berhasil diperbarui!");
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

            if (MessageBox.Show("Yakin ingin menghapus admin ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Data.DataRowView row = (System.Data.DataRowView)_bs.Current;
                    int id = Convert.ToInt32(row["id_user"]);
                    if (_bll.DeleteAdmin(id))
                    {
                        MessageBox.Show("Data admin berhasil dihapus!");
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
            _bs.DataSource = _bll.SearchAdmin(txtCari.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
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
