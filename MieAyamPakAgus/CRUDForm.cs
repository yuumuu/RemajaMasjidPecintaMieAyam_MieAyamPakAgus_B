using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace MieAyamPakAgus
{
    public partial class CRUDForm : Form
    {
        private int currentUserId;
        private bool isSuperAdmin;
        private string selectedId = ""; // To store ID for update/delete

        public CRUDForm(int userId, bool superAdmin)
        {
            InitializeComponent();
            this.currentUserId = userId;
            this.isSuperAdmin = superAdmin;
            
            SetupSuperAdmin();
            this.Load += CRUDForm_Load;
            this.TabMenu.SelectedIndexChanged += TabMenu_SelectedIndexChanged;
            
            // Wire up event handlers (Meja)
            this.BtnSaveMeja.Click += BtnSaveMeja_Click;
            this.BtnDelMeja.Click += BtnDelMeja_Click;
            this.BtnClearMeja.Click += BtnClearMeja_Click;
            this.DataTable.CellClick += DataTable_CellClick;
            this.BtnSearch.Click += BtnSearch_Click;

            // Wire up Pelanggan
            this.BtnSavePelanggan.Click += BtnSavePelanggan_Click;
            this.button2.Click += BtnDelPelanggan_Click; // Del
            this.button1.Click += BtnClearPelanggan_Click; // Clear

            // Wire up Admin
            this.BtnSaveAdmin.Click += BtnSaveAdmin_Click;
            this.BtnDelAdmin.Click += BtnDelAdmin_Click;
            this.BtnClearAdmin.Click += BtnClearAdmin_Click;

            // Wire up Reservasi
            this.BtnSaveReservasi.Click += BtnSaveReservasi_Click;
            this.BtnDelReservasi.Click += BtnDelReservasi_Click;
            this.BtnClearReservasi.Click += BtnClearReservasi_Click;
            this.BtnOpenFileDialog.Click += BtnOpenFileDialog_Click;
            this.InputPelanggan.SelectedIndexChanged += InputPelanggan_SelectedIndexChanged;
            this.InputPelanggan.TextChanged += InputPelanggan_TextChanged; 
            this.InputMeja.SelectedIndexChanged += InputMeja_SelectedIndexChanged;
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {
            UpdateTabContext();
        }

        private void SetupSuperAdmin()
        {
            if (!isSuperAdmin)
            {
                if (TabMenu.TabPages.Contains(TabAdmin))
                {
                    TabMenu.TabPages.Remove(TabAdmin);
                }
            }
        }

        private void TabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabContext();
        }

        private void UpdateTabContext()
        {
            selectedId = "";
            ClearForm();
            
            switch (TabMenu.SelectedTab.Name)
            {
                case "TabMeja":
                    LblTitlePage.Text = "Data Meja";
                    LoadMeja();
                    break;
                case "TabReservasi":
                    LblTitlePage.Text = "Data Reservasi";
                    LoadMejaList();
                    LoadPelangganList();
                    LoadReservasi();
                    break;
                case "TabPelanggan":
                    LblTitlePage.Text = "Data Pelanggan";
                    LoadPelanggan();
                    break;
                case "TabAdmin":
                    LblTitlePage.Text = "Data Admin";
                    LoadAdmin();
                    break;
            }
        }

        #region Meja CRUD
        private void LoadMeja()
        {
            DataTable dt = DBConfig.ExecuteQuery("SELECT id_meja, kode, kapasitas, status_meja FROM Meja");
            DataTable.DataSource = dt;
        }

        private void BtnSaveMeja_Click(object sender, EventArgs e)
        {
            string kode = InputKodeMeja.Text.Trim();
            string kapasitas = InputKapasitasMeja.Text.Trim();
            string status = InputStatusReservasi.Text;

            if (string.IsNullOrEmpty(kode) || string.IsNullOrEmpty(kapasitas)) {
                MessageBox.Show("Semua field Meja harus diisi!");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@kode", kode),
                new SqlParameter("@kapasitas", kapasitas),
                new SqlParameter("@status", status)
            };

            if (string.IsNullOrEmpty(selectedId))
            {
                DBConfig.ExecuteNonQuery("INSERT INTO Meja (kode, kapasitas, status_meja) VALUES (@kode, @kapasitas, @status)", parameters);
            }
            else
            {
                SqlParameter[] updateParams = new SqlParameter[parameters.Length + 1];
                parameters.CopyTo(updateParams, 0);
                updateParams[parameters.Length] = new SqlParameter("@id", selectedId);
                DBConfig.ExecuteNonQuery("UPDATE Meja SET kode=@kode, kapasitas=@kapasitas, status_meja=@status WHERE id_meja=@id", updateParams);
            }
            UpdateTabContext();
        }

        private void BtnDelMeja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedId)) return;
            if (MessageBox.Show("Hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlParameter[] parameters = { new SqlParameter("@id", selectedId) };
                DBConfig.ExecuteNonQuery("DELETE FROM Meja WHERE id_meja=@id", parameters);
                UpdateTabContext();
            }
        }

        private void BtnClearMeja_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedId = "";
        }
        #endregion

        #region Pelanggan CRUD
        private void LoadPelanggan()
        {
            DataTable dt = DBConfig.ExecuteQuery("SELECT * FROM Pelanggan");
            DataTable.DataSource = dt;
        }

        private void BtnSavePelanggan_Click(object sender, EventArgs e)
        {
            string nama = InputNamaPelanggan.Text.Trim();
            string telp = InputTeleponPelanggan.Text.Trim();

            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(telp))
            {
                MessageBox.Show("Nama dan Telepon harus diisi!");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@nama", nama),
                new SqlParameter("@telp", telp)
            };

            if (string.IsNullOrEmpty(selectedId))
            {
                DBConfig.ExecuteNonQuery("INSERT INTO Pelanggan (nama, no_telepon) VALUES (@nama, @telp)", parameters);
            }
            else
            {
                SqlParameter[] updateParams = new SqlParameter[parameters.Length + 1];
                parameters.CopyTo(updateParams, 0);
                updateParams[parameters.Length] = new SqlParameter("@id", selectedId);
                DBConfig.ExecuteNonQuery("UPDATE Pelanggan SET nama=@nama, no_telepon=@telp WHERE id_pelanggan=@id", updateParams);
            }
            UpdateTabContext();
        }

        private void BtnDelPelanggan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedId)) return;
            if (MessageBox.Show("Hapus pelanggan ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlParameter[] parameters = { new SqlParameter("@id", selectedId) };
                DBConfig.ExecuteNonQuery("DELETE FROM Pelanggan WHERE id_pelanggan=@id", parameters);
                UpdateTabContext();
            }
        }

        private void BtnClearPelanggan_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedId = "";
        }
        #endregion

        #region Admin CRUD
        private void LoadAdmin()
        {
            DataTable dt = DBConfig.ExecuteQuery("SELECT * FROM Admin");
            DataTable.DataSource = dt;
        }

        private void BtnSaveAdmin_Click(object sender, EventArgs e)
        {
            string user = InputAdminUsername.Text.Trim();
            string pass = InputAdminPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Username dan Password harus diisi!");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@user", user),
                new SqlParameter("@pass", pass)
            };

            if (string.IsNullOrEmpty(selectedId))
            {
                DBConfig.ExecuteNonQuery("INSERT INTO Admin (username, password) VALUES (@user, @pass)", parameters);
            }
            else
            {
                SqlParameter[] updateParams = new SqlParameter[parameters.Length + 1];
                parameters.CopyTo(updateParams, 0);
                updateParams[parameters.Length] = new SqlParameter("@id", selectedId);
                DBConfig.ExecuteNonQuery("UPDATE Admin SET username=@user, password=@pass WHERE id_user=@id", updateParams);
            }
            UpdateTabContext();
        }

        private void BtnDelAdmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedId)) return;
            if (MessageBox.Show("Hapus admin ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlParameter[] parameters = { new SqlParameter("@id", selectedId) };
                DBConfig.ExecuteNonQuery("DELETE FROM Admin WHERE id_user=@id", parameters);
                UpdateTabContext();
            }
        }

        private void BtnClearAdmin_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedId = "";
        }
        #endregion

        #region Reservasi CRUD
        private void LoadReservasi()
        {
            DataTable dt = DBConfig.ExecuteQuery(@"
                SELECT r.id_reservasi, m.id_meja, p.id_pelanggan, 
                       m.kode as [Kode Meja], p.nama as [Nama Pelanggan], r.waktu_kedatangan, r.jumlah_orang, r.bukti_transaksi
                FROM Reservasi r
                JOIN Meja m ON r.id_meja = m.id_meja
                JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan");
            DataTable.DataSource = dt;
        }

        private void LoadMejaList()
        {
            DataTable dt = DBConfig.ExecuteQuery("SELECT id_meja, kode, status_meja, kode + ' (' + status_meja + ')' as display, id_meja as value FROM Meja");
            InputMeja.DisplayMember = "display";
            InputMeja.ValueMember = "value";
            InputMeja.DataSource = dt;
        }

        private void LoadPelangganList()
        {
            DataTable dt = DBConfig.ExecuteQuery("SELECT id_pelanggan, nama, no_telepon FROM Pelanggan");
            InputPelanggan.DisplayMember = "nama";
            InputPelanggan.ValueMember = "id_pelanggan";
            InputPelanggan.DataSource = dt;
            InputPelanggan.SelectedIndex = -1;
        }

        private void InputPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputPelanggan.SelectedValue != null && InputPelanggan.SelectedValue is int)
            {
                DataRowView row = (DataRowView)InputPelanggan.SelectedItem;
                InputCepatTeleponPelanggan.Text = row["no_telepon"].ToString();
            }
        }

        private void InputPelanggan_TextChanged(object sender, EventArgs e)
        {
            // If text doesn't match any item, clear the phone if it was auto-filled
            // But usually we just let the user type.
        }

        private void InputMeja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputMeja.SelectedValue != null && InputMeja.SelectedValue is int)
            {
                DataRowView row = (DataRowView)InputMeja.SelectedItem;
                string status = row["status_meja"].ToString();
                if (status != "Tersedia")
                {
                    MessageBox.Show($"Perhatian: Meja {row["kode"]} saat ini berstatus {status}.", "Status Meja");
                }
            }
        }

        private void BtnOpenFileDialog_Click(object sender, EventArgs e)
        {
            if (BuktiTransferDialog.ShowDialog() == DialogResult.OK)
            {
                InputBuktiReservasi.Text = BuktiTransferDialog.FileName;
            }
        }

        private void BtnSaveReservasi_Click(object sender, EventArgs e)
        {
            if (InputMeja.SelectedValue == null) { MessageBox.Show("Pilih Meja!"); return; }
            
            int idPelanggan = -1;
            string namaPelanggan = InputPelanggan.Text.Trim();
            string telpPelanggan = InputCepatTeleponPelanggan.Text.Trim();

            if (string.IsNullOrEmpty(namaPelanggan) || string.IsNullOrEmpty(telpPelanggan))
            {
                MessageBox.Show("Nama Pelanggan dan Telepon harus diisi!");
                return;
            }

            // Smart Pelanggan logic: Get or Create
            DataTable dtP = DBConfig.ExecuteQuery("SELECT id_pelanggan FROM Pelanggan WHERE no_telepon = @telp", new SqlParameter[] { new SqlParameter("@telp", telpPelanggan) });
            if (dtP != null && dtP.Rows.Count > 0)
            {
                idPelanggan = Convert.ToInt32(dtP.Rows[0]["id_pelanggan"]);
            }
            else
            {
                // Create new
                DBConfig.ExecuteNonQuery("INSERT INTO Pelanggan (nama, no_telepon) VALUES (@nama, @telp)", new SqlParameter[] { 
                    new SqlParameter("@nama", namaPelanggan),
                    new SqlParameter("@telp", telpPelanggan)
                });
                idPelanggan = Convert.ToInt32(DBConfig.ExecuteScalar("SELECT TOP 1 id_pelanggan FROM Pelanggan ORDER BY id_pelanggan DESC"));
            }

            SqlParameter[] parameters = {
                new SqlParameter("@id_p", idPelanggan),
                new SqlParameter("@id_m", InputMeja.SelectedValue),
                new SqlParameter("@id_u", currentUserId == 0 ? 1 : currentUserId), // Use default user if super admin
                new SqlParameter("@waktu", InputWaktuReservasi.Text),
                new SqlParameter("@jml", InputJumlahOrangReservasi.Text),
                new SqlParameter("@bukti", InputBuktiReservasi.Text)
            };

            if (string.IsNullOrEmpty(selectedId))
            {
                DBConfig.ExecuteNonQuery(@"INSERT INTO Reservasi (id_pelanggan, id_meja, id_user, waktu_kedatangan, jumlah_orang, bukti_transaksi) 
                                           VALUES (@id_p, @id_m, @id_u, @waktu, @jml, @bukti)", parameters);
            }
            else
            {
                SqlParameter[] updateParams = new SqlParameter[parameters.Length + 1];
                parameters.CopyTo(updateParams, 0);
                updateParams[parameters.Length] = new SqlParameter("@id", selectedId);
                DBConfig.ExecuteNonQuery(@"UPDATE Reservasi SET id_pelanggan=@id_p, id_meja=@id_m, waktu_kedatangan=@waktu, 
                                           jumlah_orang=@jml, bukti_transaksi=@bukti WHERE id_reservasi=@id", updateParams);
            }
            UpdateTabContext();
        }

        private void BtnDelReservasi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedId)) return;
            if (MessageBox.Show("Hapus reservasi ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlParameter[] parameters = { new SqlParameter("@id", selectedId) };
                DBConfig.ExecuteNonQuery("DELETE FROM Reservasi WHERE id_reservasi=@id", parameters);
                UpdateTabContext();
            }
        }

        private void BtnClearReservasi_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedId = "";
        }
        #endregion

        #region Common Methods
        private void DataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = DataTable.Rows[e.RowIndex];
            
            switch (TabMenu.SelectedTab.Name)
            {
                case "TabMeja":
                    selectedId = row.Cells["id_meja"].Value.ToString();
                    InputKodeMeja.Text = row.Cells["kode"].Value.ToString();
                    InputKapasitasMeja.Text = row.Cells["kapasitas"].Value.ToString();
                    InputStatusReservasi.Text = row.Cells["status_meja"].Value.ToString();
                    break;
                case "TabPelanggan":
                    selectedId = row.Cells["id_pelanggan"].Value.ToString();
                    InputNamaPelanggan.Text = row.Cells["nama"].Value.ToString();
                    InputTeleponPelanggan.Text = row.Cells["no_telepon"].Value.ToString();
                    break;
                case "TabAdmin":
                    selectedId = row.Cells["id_user"].Value.ToString();
                    InputAdminUsername.Text = row.Cells["username"].Value.ToString();
                    InputAdminPassword.Text = row.Cells["password"].Value.ToString();
                    break;
                case "TabReservasi":
                    selectedId = row.Cells["id_reservasi"].Value.ToString();
                    InputMeja.SelectedValue = row.Cells["id_meja"].Value;
                    InputPelanggan.SelectedValue = row.Cells["id_pelanggan"].Value;
                    
                    if (DateTime.TryParse(row.Cells["waktu_kedatangan"].Value.ToString(), out DateTime dt))
                    {
                        InputWaktuReservasi.Value = dt;
                    }
                    
                    InputJumlahOrangReservasi.Text = row.Cells["jumlah_orang"].Value.ToString();
                    InputBuktiReservasi.Text = row.Cells["bukti_transaksi"].Value.ToString();
                    break;
            }
        }

        private void ClearForm()
        {
            // Meja
            InputKodeMeja.Clear();
            InputKapasitasMeja.Clear();
            InputStatusReservasi.SelectedIndex = -1;
            
            // Pelanggan
            InputNamaPelanggan.Clear();
            InputTeleponPelanggan.Clear();
            
            // Reservasi
            InputMeja.SelectedIndex = -1;
            InputPelanggan.SelectedIndex = -1;
            InputWaktuReservasi.Value = DateTime.Now;
            InputJumlahOrangReservasi.Clear();
            InputBuktiReservasi.Clear();
            InputCepatTeleponPelanggan.Clear();
            
            // Admin
            InputAdminUsername.Clear();
            InputAdminPassword.Clear();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = "%" + InputSearch.Text.Trim() + "%";
            string query = "";
            SqlParameter[] parameters = { new SqlParameter("@key", keyword) };

            switch (TabMenu.SelectedTab.Name)
            {
                case "TabMeja":
                    query = "SELECT * FROM Meja WHERE kode LIKE @key OR status_meja LIKE @key";
                    break;
                case "TabPelanggan":
                    query = "SELECT * FROM Pelanggan WHERE nama LIKE @key OR no_telepon LIKE @key";
                    break;
                case "TabReservasi":
                    query = "SELECT r.*, p.nama, m.kode FROM Reservasi r JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan JOIN Meja m ON r.id_meja = m.id_meja WHERE p.nama LIKE @key OR m.kode LIKE @key";
                    break;
                case "TabAdmin":
                    query = "SELECT * FROM Admin WHERE username LIKE @key";
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                DataTable dt = DBConfig.ExecuteQuery(query, parameters);
                DataTable.DataSource = dt;
            }
        }
        #endregion

    }
}
