using System;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.Forms
{
    public partial class FormMain : Form
    {
        private readonly DashboardBLL _dashboardBll = new DashboardBLL();
        private Form _activeForm;

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

        private void menuLaporanReservasi_Click(object sender, EventArgs e)
        {
            ShowForm(new FormLaporanReservasi());
        }

        private void menuImport_Click(object sender, EventArgs e)
        {
            ShowForm(new FormImport());
        }

        private void ShowForm(Form frm)
        {
            if (_activeForm != null)
            {
                if (_activeForm.GetType() == frm.GetType())
                {
                    _activeForm.Focus();
                    return;
                }
                CloseActiveForm();
            }

            _activeForm = frm;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.FormClosed += (s, args) =>
            {
                _activeForm = null;
                LoadDashboard();
            };

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void CloseActiveForm()
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm.Dispose();
                _activeForm = null;
                pnlContent.Controls.Clear();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Logged in as: " + Session.Username;
            menuAdmin.Visible = Session.IsSuperadmin;
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                DashboardStats stats = _dashboardBll.GetStats();
                lblTotalReservasi.Text = stats.TotalReservasi.ToString();
                lblReservasiHariIni.Text = stats.ReservasiHariIni.ToString();
                lblTotalPelanggan.Text = stats.TotalPelanggan.ToString();
                lblMejaTersedia.Text = stats.MejaTersedia.ToString();
                lblMejaTerpakai.Text = stats.MejaTerpakai.ToString();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Gagal load dashboard: " + ex.Message;
            }
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CloseActiveForm();
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }
        }
    }
}
