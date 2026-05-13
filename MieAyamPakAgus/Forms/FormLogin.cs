using System;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;

namespace MieAyamPakAgus.Forms
{
    public partial class FormLogin : Form
    {
        private readonly AdminBLL _bll = new AdminBLL();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bll.Login(txtUsername.Text, txtPassword.Text))
                {
                    Session.IsSuperadmin = false;
                    OpenMainForm();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuperadmin_Click(object sender, EventArgs e)
        {
            string pin = Microsoft.VisualBasic.Interaction.InputBox("Masukkan PIN Superadmin:", "Superadmin Mode", "");
            if (pin == "123456")
            {
                Session.IsSuperadmin = true;
                Session.Username = "SUPERADMIN";
                Session.IdUser = 0; // Or a reserved ID
                OpenMainForm();
            }
            else if (!string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("PIN Salah!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void OpenMainForm()
        {
            this.Hide();
            FormMain main = new FormMain();
            main.Show();
        }
    }
}
