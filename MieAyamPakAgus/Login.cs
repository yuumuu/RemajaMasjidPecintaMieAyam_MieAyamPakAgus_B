using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

namespace MieAyamPakAgus
{
    public partial class Login : Form
    {
        private const string SuperAdminPin = "123456";
        private readonly AdminBLL _adminBll = new AdminBLL();

        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = InputUsername.Text.Trim();
            string password = InputPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_adminBll.Login(username, password))
                {
                    this.Hide();
                    CRUDForm mainForm = new CRUDForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            InputPassword.UseSystemPasswordChar = !ChkShowPassword.Checked;
        }

        private void BtnModalSuperAdmin_Click(object sender, EventArgs e)
        {
            string pin = Microsoft.VisualBasic.Interaction.InputBox("Masukkan PIN Super Admin:", "Mode Super Admin", "");

            if (pin == SuperAdminPin)
            {
                Session.IsSuperadmin = true;
                Session.Username = "SUPERADMIN";
                Session.IdUser = 0;
                this.Hide();
                CRUDForm mainForm = new CRUDForm();
                mainForm.Show();
            }
            else if (!string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("PIN salah!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Connection test removed to rely on DBHelper
        }
    }
}
