using System;
using System.Data;
using System.Windows.Forms;
using MieAyamPakAgus.BLL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus
{
    public partial class CRUDForm : Form
    {
        // 3-Layer BLL instances
        private readonly AdminBLL _adminBll = new AdminBLL();
        private readonly PelangganBLL _pelangganBll = new PelangganBLL();
        private readonly MejaBLL _mejaBll = new MejaBLL();
        private readonly ReservasiBLL _reservasiBll = new ReservasiBLL();

        // BindingSources for each tab
        private BindingSource _bsAdmin = new BindingSource();
        private BindingSource _bsPelanggan = new BindingSource();
        private BindingSource _bsMeja = new BindingSource();
        private BindingSource _bsReservasi = new BindingSource();


        public CRUDForm()
        {
            InitializeComponent();
            
            // Wire up Logout
            this.FormClosing += (s, e) => {
                if (MessageBox.Show("Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            };

            // Setup UI based on session
            if (!Session.IsSuperadmin)
            {
                TabMenu.TabPages.Remove(TabAdmin);
            }

            this.Load += CRUDForm_Load;
            this.TabMenu.SelectedIndexChanged += TabMenu_SelectedIndexChanged;
            
            // Events
            this.BtnSaveMeja.Click += (s, e) => SaveMeja();
            this.BtnDelMeja.Click += (s, e) => DeleteMeja();
            this.BtnClearMeja.Click += (s, e) => ClearForm();

            this.BtnSavePelanggan.Click += (s, e) => SavePelanggan();
            this.button2.Click += (s, e) => DeletePelanggan(); // button2 is Delete in Designer
            this.button1.Click += (s, e) => ClearForm();   // button1 is Clear in Designer

            this.BtnSaveAdmin.Click += (s, e) => SaveAdmin();
            this.BtnDelAdmin.Click += (s, e) => DeleteAdmin();
            this.BtnClearAdmin.Click += (s, e) => ClearForm();

            this.BtnSaveReservasi.Click += (s, e) => SaveReservasi();
            this.BtnDelReservasi.Click += (s, e) => DeleteReservasi();
            this.BtnClearReservasi.Click += (s, e) => ClearForm();

            this.BtnSearch.Click += (s, e) => SearchData();
            this.BtnLogout.Click += (s, e) => {
                if (MessageBox.Show("Yakin ingin Logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Hide();
                    new Login().Show();
                }
            };
            this.DataTable.CellClick += DataTable_CellClick;
            
            this.BtnOpenFileDialog.Click += (s, e) => {
                if (BuktiTransferDialog.ShowDialog() == DialogResult.OK)
                    InputBuktiReservasi.Text = BuktiTransferDialog.FileName;
            };
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {
            // Initialize all DataSources to establish schema for Binding
            _bsAdmin.DataSource = _adminBll.GetData();
            _bsPelanggan.DataSource = _pelangganBll.GetData();
            _bsMeja.DataSource = _mejaBll.GetData();
            _bsReservasi.DataSource = _reservasiBll.GetData();

            BindAll();
            UpdateTabContext();
        }

        private void BindAll()
        {
            // Bind Controls (PABD Style)
            // Meja
            InputKodeMeja.DataBindings.Add("Text", _bsMeja, "kode", true, DataSourceUpdateMode.OnPropertyChanged);
            InputKapasitasMeja.DataBindings.Add("Text", _bsMeja, "kapasitas", true, DataSourceUpdateMode.OnPropertyChanged);
            InputStatusReservasi.DataBindings.Add("Text", _bsMeja, "status_meja", true, DataSourceUpdateMode.OnPropertyChanged);

            // Pelanggan
            InputNamaPelanggan.DataBindings.Add("Text", _bsPelanggan, "nama", true, DataSourceUpdateMode.OnPropertyChanged);
            InputTeleponPelanggan.DataBindings.Add("Text", _bsPelanggan, "no_telepon", true, DataSourceUpdateMode.OnPropertyChanged);

            // Admin
            InputAdminUsername.DataBindings.Add("Text", _bsAdmin, "username", true, DataSourceUpdateMode.OnPropertyChanged);
            InputAdminPassword.DataBindings.Add("Text", _bsAdmin, "password", true, DataSourceUpdateMode.OnPropertyChanged);

            // Reservasi (Limited binding due to FK ComboBoxes)
            InputJumlahOrangReservasi.DataBindings.Add("Text", _bsReservasi, "jumlah_orang", true, DataSourceUpdateMode.OnPropertyChanged);
            InputBuktiReservasi.DataBindings.Add("Text", _bsReservasi, "bukti_transaksi", true, DataSourceUpdateMode.OnPropertyChanged);
            InputWaktuReservasi.DataBindings.Add("Value", _bsReservasi, "waktu_kedatangan", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void TabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabContext();
        }

        private void UpdateTabContext()
        {
            ClearForm();
            switch (TabMenu.SelectedTab.Name)
            {
                case "TabMeja":
                    LblTitlePage.Text = "Data Meja";
                    _bsMeja.DataSource = _mejaBll.GetData();
                    DataTable.DataSource = _bsMeja;
                    break;
                case "TabReservasi":
                    LblTitlePage.Text = "Data Reservasi";
                    LoadComboBoxes();
                    _bsReservasi.DataSource = _reservasiBll.GetData();
                    DataTable.DataSource = _bsReservasi;
                    break;
                case "TabPelanggan":
                    LblTitlePage.Text = "Data Pelanggan";
                    _bsPelanggan.DataSource = _pelangganBll.GetData();
                    DataTable.DataSource = _bsPelanggan;
                    break;
                case "TabAdmin":
                    LblTitlePage.Text = "Data Admin";
                    _bsAdmin.DataSource = _adminBll.GetData();
                    DataTable.DataSource = _bsAdmin;
                    break;
            }
        }

        private void LoadComboBoxes()
        {
            InputMeja.DataSource = _mejaBll.GetData();
            InputMeja.DisplayMember = "kode";
            InputMeja.ValueMember = "id_meja";

            InputPelanggan.DataSource = _pelangganBll.GetData();
            InputPelanggan.DisplayMember = "nama";
            InputPelanggan.ValueMember = "id_pelanggan";
        }

        private void DataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            // Sync Reservasi ComboBoxes manually as DataBindings for ValueMember is tricky
            if (TabMenu.SelectedTab.Name == "TabReservasi")
            {
                var row = DataTable.Rows[e.RowIndex];
                if (row.Cells["id_meja"].Value != DBNull.Value)
                    InputMeja.SelectedValue = row.Cells["id_meja"].Value;
                if (row.Cells["id_pelanggan"].Value != DBNull.Value)
                    InputPelanggan.SelectedValue = row.Cells["id_pelanggan"].Value;
            }
        }

        private void ClearForm()
        {
            InputKodeMeja.Clear();
            InputKapasitasMeja.Clear();
            InputNamaPelanggan.Clear();
            InputTeleponPelanggan.Clear();
            InputAdminUsername.Clear();
            InputAdminPassword.Clear();
            InputJumlahOrangReservasi.Clear();
            InputBuktiReservasi.Clear();
            InputSearch.Clear();
        }

        // --- Action Methods ---

        private void SaveMeja()
        {
            try {
                if (_bsMeja.Current == null || string.IsNullOrEmpty(InputKodeMeja.Text)) {
                    _mejaBll.AddMeja(InputKodeMeja.Text, int.Parse(InputKapasitasMeja.Text));
                } else {
                    DataRowView row = (DataRowView)_bsMeja.Current;
                    _mejaBll.UpdateStatus((int)row["id_meja"], InputStatusReservasi.Text);
                }
                UpdateTabContext();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteMeja()
        {
            if (_bsMeja.Current == null) return;
            DataRowView row = (DataRowView)_bsMeja.Current;
            if (_mejaBll.DeleteMeja((int)row["id_meja"])) UpdateTabContext();
        }

        private void SavePelanggan()
        {
            try {
                if (_bsPelanggan.Current == null || string.IsNullOrEmpty(InputNamaPelanggan.Text)) {
                    _pelangganBll.AddPelanggan(InputNamaPelanggan.Text, InputTeleponPelanggan.Text);
                } else {
                    DataRowView row = (DataRowView)_bsPelanggan.Current;
                    _pelangganBll.UpdatePelanggan((int)row["id_pelanggan"], InputNamaPelanggan.Text, InputTeleponPelanggan.Text);
                }
                UpdateTabContext();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeletePelanggan()
        {
            if (_bsPelanggan.Current == null) return;
            DataRowView row = (DataRowView)_bsPelanggan.Current;
            if (_pelangganBll.DeletePelanggan((int)row["id_pelanggan"])) UpdateTabContext();
        }

        private void SaveAdmin()
        {
            try {
                if (_bsAdmin.Current == null) {
                    _adminBll.AddAdmin(InputAdminUsername.Text, InputAdminPassword.Text);
                } else {
                    DataRowView row = (DataRowView)_bsAdmin.Current;
                    _adminBll.UpdateAdmin((int)row["id_user"], InputAdminUsername.Text, InputAdminPassword.Text);
                }
                UpdateTabContext();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteAdmin()
        {
            if (_bsAdmin.Current == null) return;
            DataRowView row = (DataRowView)_bsAdmin.Current;
            if (_adminBll.DeleteAdmin((int)row["id_user"])) UpdateTabContext();
        }

        private void SaveReservasi()
        {
            try {
                int idPel = (int)InputPelanggan.SelectedValue;
                int idMeja = (int)InputMeja.SelectedValue;
                if (_bsReservasi.Current == null) {
                    _reservasiBll.AddReservasi(idPel, idMeja, InputWaktuReservasi.Value, int.Parse(InputJumlahOrangReservasi.Text), InputBuktiReservasi.Text);
                } else {
                    DataRowView row = (DataRowView)_bsReservasi.Current;
                    _reservasiBll.UpdateReservasi((int)row["id_reservasi"], idPel, idMeja, InputWaktuReservasi.Value, int.Parse(InputJumlahOrangReservasi.Text), InputBuktiReservasi.Text);
                }
                UpdateTabContext();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteReservasi()
        {
            if (_bsReservasi.Current == null) return;
            DataRowView row = (DataRowView)_bsReservasi.Current;
            if (_reservasiBll.DeleteReservasi((int)row["id_reservasi"])) UpdateTabContext();
        }

        private void SearchData()
        {
            string key = InputSearch.Text;
            switch (TabMenu.SelectedTab.Name)
            {
                case "TabMeja": _bsMeja.DataSource = _mejaBll.Search(key); break;
                case "TabPelanggan": _bsPelanggan.DataSource = _pelangganBll.Search(key); break;
                case "TabReservasi": _bsReservasi.DataSource = _reservasiBll.Search(key); break;
                case "TabAdmin": _bsAdmin.DataSource = _adminBll.SearchAdmin(key); break;
            }
        }
    }
}
