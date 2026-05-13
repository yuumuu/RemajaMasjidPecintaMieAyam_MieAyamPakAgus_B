using System;
using System.Windows.Forms;

namespace MieAyamPakAgus.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuAdmin_Click(object sender, EventArgs e)
        {
            ShowForm(new FormAdmin());
        }

        private void menuPelanggan_Click(object sender, EventArgs e)
        {
            ShowForm(new FormPelanggan());
        }

        private void menuMeja_Click(object sender, EventArgs e)
        {
            ShowForm(new FormMeja());
        }

        private void menuReservasi_Click(object sender, EventArgs e)
        {
            ShowForm(new FormReservasi());
        }

        private void ShowForm(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == frm.GetType())
                {
                    f.Activate();
                    return;
                }
            }
            frm.MdiParent = this;
            frm.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Logged in as: " + Session.Username;
            menuAdmin.Visible = Session.IsSuperadmin;
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }
        }
    }
}
