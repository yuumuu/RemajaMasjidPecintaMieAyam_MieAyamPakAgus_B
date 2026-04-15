using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MieAyamPakAgus
{
    public partial class Login : Form
    {
        private const string SuperAdminPin = "123456";

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

            string query = "SELECT id_user FROM Admin WHERE username = @user AND password = @pass";
            SqlParameter[] parameters = {
                new SqlParameter("@user", username),
                new SqlParameter("@pass", password)
            };

            DataTable dt = DBConfig.ExecuteQuery(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["id_user"]);
                this.Hide();
                CRUDForm mainForm = new CRUDForm(userId, false);
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle visibilitas password
            InputPassword.UseSystemPasswordChar = !ChkShowPassword.Checked;
        }

        private void BtnModalSuperAdmin_Click(object sender, EventArgs e)
        {
            string pin = Microsoft.VisualBasic.Interaction.InputBox("Masukkan PIN Super Admin:", "Mode Super Admin", "");

            if (pin == SuperAdminPin)
            {
                MessageBox.Show("Mode Super Admin Aktif!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                CRUDForm mainForm = new CRUDForm(0, true);
                mainForm.ShowDialog();
                this.Close();
            }
            else if (!string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("PIN salah!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!DBConfig.TestConnection())
            {
                MessageBox.Show("Gagal terhubung ke database. Periksa konfigurasi koneksi.", "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

