using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MieAyamPakAgus
{
    public partial class Login : Form
    {
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
                MessageBox.Show("Username and Password are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                CRUDForm mainForm = new CRUDForm(userId, false); // Regular admin mode
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            InputPassword.UseSystemPasswordChar = !ChkShowPassword.Checked;
        }

        private void BtnModalSuperAdmin_Click(object sender, EventArgs e)
        {
            string pin = Microsoft.VisualBasic.Interaction.InputBox("Enter Super Admin PIN:", "Super Admin Mode", "");

            if (pin == "123456")
            {
                MessageBox.Show("Super Admin Mode Activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                CRUDForm mainForm = new CRUDForm(0, true); // true for Super Admin Mode
                mainForm.ShowDialog();
                this.Close();
            }
            else if (!string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Incorrect PIN!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
