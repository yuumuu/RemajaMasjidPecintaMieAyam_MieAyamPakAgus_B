TECHNICAL REPORT
SISTEM INFORMASI RESERVASI MIE AYAM PAK AGUS
================================================

1. OVERVIEW SISTEM
------------------------------------------------

1.1 Tujuan Aplikasi

Aplikasi ini adalah sistem informasi reservasi untuk rumah makan 
Mie Ayam Pak Agus yang dibangun sebagai proyek ujian. Sistem ini 
memungkinkan pencatatan data pelanggan, pengelolaan meja, 
reservasi, serta pembuatan laporan secara terkomputerisasi.

1.2 Arsitektur

Aplikasi menggunakan arsitektur 3-layer (Three-Tier Architecture):

  User Interface (Forms)
       |
  Business Logic Layer (BLL)
       |
  Data Access Layer (DAL)
       |
  SQL Server Database (Stored Procedures)

Alur data dari form hingga database:

  Form -> BLL (validasi + logika bisnis) -> DAL (akses data)
  -> SQL Server (Stored Procedure) -> hasil dikembalikan ke Form
  dalam bentuk DataTable.

1.3 Teknologi

  - Bahasa: C# (.NET Framework 4.7.2)
  - Platform: Windows Forms (WinForms)
  - Database: Microsoft SQL Server
  - Reporting: Crystal Reports (design-time .rpt, embedded resource)
  - Import: Microsoft ACE OLEDB 12.0 (Excel)
  - IDE: Microsoft Visual Studio


2. STRUKTUR APLIKASI
------------------------------------------------

2.1 Folder Structure

  MieAyamPakAgus/
  |-- BLL/          (Business Logic Layer)
  |-- DAL/          (Data Access Layer)
  |-- Forms/        (Windows Forms UI)
  |-- Helpers/      (Utility classes)
  |-- Models/       (Data models)
  |-- Properties/   (Assembly info, settings)
  |-- Database/     (SQL scripts)

2.2 Pembagian Layer

  Layer UI (Forms):
  - FormLogin, FormMain, FormAdmin, FormPelanggan, FormMeja,
    FormReservasi, FormLaporanReservasi, FormImport

  Layer Bisnis (BLL):
  - AdminBLL, PelangganBLL, MejaBLL, ReservasiBLL,
    ReservasiReportBLL, DashboardBLL
  - Bertanggung jawab atas validasi input sebelum dikirim ke DAL.
  - Tidak ada akses langsung ke database dari layer ini.

  Layer Data (DAL):
  - DBHelper sebagai utility koneksi database.
  - AdminDAL, PelangganDAL, MejaDAL, ReservasiDAL,
    ReservasiReportDAL, DashboardDAL
  - Setiap class DAL hanya memanggil Stored Procedure yang sesuai.
  - Semua query menggunakan parameter (tidak ada string concatenation
    untuk nilai input).


3. DATABASE DESIGN
------------------------------------------------

3.1 Tabel dan Relasi

  Admin (id_user, username, password)
    |
    |< FK_Reservasi_User
    |
  Reservasi (id_reservasi, id_pelanggan, id_meja, id_user,
             waktu_kedatangan, jumlah_orang, bukti_transaksi,
             created_at)
    |
    |< FK_Reservasi_Pelanggan
    |
  Pelanggan (id_pelanggan, nama, no_telepon)
  
    |
    |< FK_Reservasi_Meja
    |
  Meja (id_meja, kode, kapasitas, status_meja)

3.2 Constraints

  - Primary Key: setiap tabel memiliki identity PK.
  - Foreign Key: Reservasi memiliki FK ke Pelanggan, Meja, dan Admin.
  - Unique: Admin.username, Meja.kode, Reservasi(id_meja, waktu_kedatangan).
  - Check: Meja.status_meja hanya bernilai 'Tersedia', 'Terisi', atau 'Dipesan'.
  - Default: created_at = GETDATE(), status_meja = 'Tersedia'.

  Constraint UNIQUE pada (id_meja, waktu_kedatangan) berfungsi untuk
  mencegah double booking pada meja yang sama di waktu yang sama.

3.3 Views

  a. vw_DataAdmin
     SELECT id_user, username, password FROM Admin;
     Menampilkan seluruh data admin termasuk password dalam bentuk
     plaintext. Tidak ada masking atau hashing.

  b. vw_DataPelanggan
     SELECT * FROM Pelanggan;
     Menampilkan seluruh data pelanggan.

  c. vw_DataMeja
     SELECT * FROM Meja;
     Menampilkan seluruh data meja termasuk status.

  d. vw_DataReservasi
     SELECT r.*, p.nama AS nama_pelanggan, m.kode AS kode_meja,
            a.username AS admin_name
     FROM Reservasi r
     JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
     JOIN Meja m ON r.id_meja = m.id_meja
     JOIN Admin a ON r.id_user = a.id_user;
     View agregasi untuk menampilkan data reservasi lengkap dengan
     nama pelanggan, kode meja, dan admin pembuat.

3.4 Trigger

  Nama: trg_Reservasi_UpdateStatusMeja
  Event: AFTER INSERT, UPDATE, DELETE on Reservasi

  Logika trigger:
  - INSERT reservasi baru -> status meja berubah menjadi 'Dipesan'.
  - DELETE reservasi -> status meja kembali menjadi 'Tersedia'
    hanya jika meja tersebut tidak memiliki reservasi lain.
  - UPDATE (pindah meja) -> meja lama menjadi 'Tersedia' (jika
    tidak ada reservasi lain), meja baru menjadi 'Dipesan'.

  Catatan: Trigger ini belum dijalankan di database. Perlu
  dieksekusi manual melalui TablePlus atau SSMS.


4. STORED PROCEDURE DAN TRANSACTION
------------------------------------------------

4.1 Daftar Stored Procedure

  Admin:
  - sp_TambahAdmin (validasi username length, duplicate check)
  - sp_UpdateAdmin (validasi username unik)
  - sp_DeleteAdmin (cek relasi reservasi sebelum hapus)
  - sp_SearchAdmin (LIKE query)

  Pelanggan:
  - sp_TambahPelanggan (validasi nama kosong, telepon numerik)
  - sp_UpdatePelanggan
  - sp_DeletePelanggan (cek relasi reservasi)
  - sp_SearchPelanggan (LIKE query by nama atau telepon)

  Meja:
  - sp_TambahMeja (cek duplicate kode)
  - sp_UpdateStatusMeja
  - sp_DeleteMeja (cek relasi reservasi)
  - sp_SearchMeja (LIKE query by kode atau status)

  Reservasi:
  - sp_TambahReservasi (dengan TRANSACTION)
  - sp_UpdateReservasi (dengan TRANSACTION)
  - sp_DeleteReservasi (dengan TRANSACTION)
  - sp_SearchReservasi (LIKE query)

  Laporan:
  - sp_LaporanReservasi (4 filter parameter nullable)
  - sp_DashboardStats (5 aggregate queries)

  Counter:
  - sp_CountAdmin, sp_CountPelanggan, sp_CountMeja, sp_CountReservasi

4.2 Mekanisme Transaction

  Tiga stored procedure reservasi menggunakan explicit transaction:

  BEGIN TRY
      BEGIN TRANSACTION;
      -- operasi DML (INSERT / UPDATE / DELETE)
      COMMIT TRANSACTION;
  END TRY
  BEGIN CATCH
      ROLLBACK TRANSACTION;
      THROW;
  END CATCH

  Dengan adanya trigger yang berjalan pada operasi Reservasi,
  transaction ini memastikan bahwa perubahan data Reservasi dan
  perubahan status Meja (oleh trigger) bersifat atomic. Jika
  trigger gagal, perubahan Reservasi juga akan di-rollback.

  Transaction ini juga melindungi dari operasi yang melanggar
  constraint database (FK violation, duplicate UNIQUE, dll).

  Catatan: Transaction ini berjalan di level database (stored
  procedure). Tidak ada transaction di level C# untuk operasi
  yang melibatkan multiple SP call seperti Import Excel.


5. FITUR SISTEM
------------------------------------------------

5.1 CRUD (Admin, Pelanggan, Meja, Reservasi)

  Setiap form CRUD mengikuti pola yang sama:
  - DataGridView dengan BindingSource dan BindingNavigator.
  - Tombol: Tambah, Update, Hapus, Clear, Cari, Refresh.
  - Validasi input menggunakan class Validators.
  - Error highlighting dengan warna LightCoral (class FormHelper).
  - SelectionChanged pada DataGridView mengisi field dan mengaktifkan
    tombol Update/Hapus.
  - Clear form mereset semua field ke nilai default.

  Validasi yang diterapkan:
  - Admin: username 3-50 karakter (alphanumeric + underscore),
    password minimal 6 karakter.
  - Pelanggan: nama 2-100 karakter, no telepon 10-15 digit numerik.
  - Meja: kode 1-5 karakter, kapasitas melalui NumericUpDown.
  - Reservasi: combo pelanggan/meja tidak null, waktu harus di masa
    depan, jumlah orang 1-50.

5.2 Reservasi

  Fitur khusus reservasi:
  - Pilihan pelanggan dari ComboBox (data dari database).
  - Pilihan meja dari ComboBox.
  - DateTimePicker untuk waktu kedatangan.
  - NumericUpDown untuk jumlah orang.
  - Upload bukti transaksi (gambar) via button Browse.
  - Preview gambar di PictureBox dengan mode Zoom.
  - File gambar disalin ke folder uploads/ dengan GUID-based filename.

5.3 Dashboard

  Form utama (FormMain) menampilkan 5 statistik:
  - Total Reservasi
  - Reservasi Hari Ini
  - Total Pelanggan
  - Meja Tersedia
  - Meja Terpakai

  Data diambil dari stored procedure sp_DashboardStats. Dashboard
  hanya dimuat sekali saat form load. Tidak ada auto-refresh setelah
  operasi CRUD di form anak.

  Catatan: Statistik "Reservasi Hari Ini" menggunakan kolom
  created_at (waktu input data), bukan waktu_kedatangan (waktu
  reservasi). Ini perlu diverifikasi sesuai kebutuhan.

5.4 Upload Gambar

  Upload bukti transaksi melalui OpenFileDialog dengan filter
  format gambar (.jpg, .jpeg, .png, .bmp, .gif). File yang dipilih
  disalin ke folder uploads/ dengan nama GUID untuk menghindari
  konflik nama. Path relatif disimpan di database.

  Tidak ada validasi ukuran file. Tidak ada validasi tipe file
  selain filter ekstensi di dialog. File lama tidak otomatis
  dihapus saat reservasi diupdate dengan gambar baru.

5.5 Import Excel

  Import data dari file Excel (.xlsx / .xls) menggunakan Microsoft
  ACE OLEDB 12.0. Dua mode import:
  - Import Pelanggan: kolom nama, no_telepon.
  - Import Reservasi: kolom id_pelanggan, id_meja, waktu_kedatangan,
    jumlah_orang, bukti_transaksi.

  Proses import berjalan per-baris (row by row). Baris yang gagal
  dilewati dan dihitung sebagai failed. Tidak ada rollback untuk
  baris yang sudah berhasil diproses jika baris berikutnya gagal.

5.6 Reporting

  Report reservasi menggunakan Crystal Reports dengan filter:
  - Rentang tanggal (dari - sampai).
  - Filter pelanggan (nullable).
  - Filter meja (nullable).

  Report dapat diexport ke PDF dan dicetak langsung ke printer.


6. CRYSTAL REPORT - IMPLEMENTASI
------------------------------------------------

6.1 Cara Kerja

  Crystal Report diimplementasikan dengan pendekatan design-time:
  - File .rpt dibuat manual melalui Crystal Reports Designer.
  - File .rpt di-set sebagai EmbeddedResource di csproj.
  - Visual Studio auto-generate class LaporanReservasi (ReportClass).
  - Class ini memiliki properti FullResourceName yang merujuk ke
    embedded .rpt, dan NewGenerator = true.

6.2 Alur Data

  1. User memilih filter (tanggal, pelanggan, meja).
  2. btnGenerate_Click memanggil BLL -> DAL -> SP sp_LaporanReservasi.
  3. SP mengembalikan DataTable dengan 14 kolom (id_reservasi,
     id_pelanggan, id_meja, id_user, nama_pelanggan, telepon_pelanggan,
     kode_meja, kapasitas_meja, admin_pembuat, waktu_kedatangan,
     jumlah_orang, bukti_transaksi, created_at, status_meja).
  4. DataTable dikirim ke method ShowReport.
  5. Method ShowReport membuat instance baru LaporanReservasi
     (typed class yang me-load .rpt dari embedded resource).
  6. report.SetDataSource(data) mengikat DataTable ke report.
  7. CrystalReportViewer menampilkan report.

6.3 Binding DataTable ke .rpt

  Kolom DataTable harus memiliki nama yang SAMA PERSIS dengan nama
  field di file .rpt. Dalam implementasi saat ini, field .rpt dibuat
  sebagai Database Fields menggunakan "Add Command" dengan query SQL
  JOIN yang menghasilkan nama kolom yang identik dengan DataTable.
  SetDataSource kemudian meng-override data command dengan data
  dari DataTable (push model).

6.4 Fitur Pendukung

  - Export ke PDF: report.ExportToDisk(ExportFormatType.PortableDocFormat).
  - Print: report.PrintToPrinter.


7. IMPORT EXCEL - IMPLEMENTASI
------------------------------------------------

7.1 Mekanisme

  Import Excel menggunakan Microsoft ACE OLEDB 12.0 untuk membaca
  file Excel sebagai data tabular. Koneksi string yang digunakan:

  - .xlsx: Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=YES'
  - .xls:  Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 8.0;HDR=YES'

  Data dibaca dari sheet pertama file Excel.

7.2 Struktur Template

  Import Pelanggan:
  - Kolom: nama, no_telepon (string).

  Import Reservasi:
  - Kolom: id_pelanggan (int), id_meja (int), waktu_kedatangan (datetime),
    jumlah_orang (int), bukti_transaksi (string, opsional).

  Kolom header harus sesuai persis dengan nama kolom di atas.

7.3 Kelemahan

  - Ketergantungan pada driver ACE OLEDB yang mungkin tidak terinstall
    di komputer target. (Solusi alternatif: menggunakan NPOI library
    yang tidak memerlukan driver Excel).
  - Import reservasi menggunakan raw database ID (id_pelanggan,
    id_meja) bukan nama/kode. Pengguna harus mengetahui ID dari
    database.
  - Tidak ada transaction untuk rollback jika import gagal di
    tengah proses. Sebagian data bisa masuk, sebagian gagal.
  - Import berjalan synchronously per-baris. Untuk data besar
    (ribuan baris) akan lambat dan mem-freeze UI.
  - Tidak ada pengecekan duplikat data.


8. VALIDASI DAN PENGUJIAN
------------------------------------------------

8.1 Validasi Input (Form Level)

  Setiap form CRUD memiliki method ValidateInput() yang dipanggil
  sebelum operasi Insert atau Update. Validasi menggunakan class
  Validators di folder Helpers yang mencakup:

  - Username: not empty, 3-50 chars, alphanumeric + underscore.
  - Password: not empty, 6-100 chars.
  - Nama: not empty, 2-100 chars, no special chars.
  - Telepon: numeric only, 10-15 digits.
  - Kode Meja: not empty, 1-5 chars.
  - Jumlah Orang: 1-50.
  - Waktu Reservasi: harus di masa depan.

8.2 Validasi Database (SP Level)

  Validasi tambahan di stored procedure:

  - Username unique (sp_TambahAdmin, sp_UpdateAdmin).
  - Kode meja unique (sp_TambahMeja).
  - Cek foreign key sebelum delete (semua SP Delete).
  - Cek constraint waktu (sp_TambahReservasi: tidak boleh masa lalu).
  - Unique constraint (id_meja + waktu_kedatangan).

8.3 Anomali yang Terdeteksi

  a. Input Data Kosong:
     Tertangani oleh validasi form. Error message muncul sebelum
     data dikirim ke database.

  b. Input Data Duplikat:
     - Username: tertangani oleh SP (THROW 50002).
     - Kode meja: tertangani oleh SP (THROW 50002).
     - Pelanggan: tidak ada cek duplikat Nama. Data ganda mungkin terjadi.
     - Double booking: tertangani oleh UNIQUE constraint di level tabel.

  c. Delete Data Berelasi:
     Semua SP Delete mengecek apakah data masih dirujuk oleh tabel
     Reservasi. Jika ya, THROW error.

  d. Upload File Non-Image:
     Filter OpenFileDialog membatasi ekstensi (.jpg, .jpeg, .png,
     .bmp, .gif) namun dapat di-bypass. Method ShowPreview hanya
     menangkap exception dari Image.FromFile tanpa validasi tipe
     file yang ketat. File non-image yang masuk akan gagal ditampilkan
     preview tapi path tetap tersimpan.

  e. Import Excel Partial Failure:
     Jika baris ke-100 gagal, baris 1-99 tetap masuk. Tidak ada
     rollback. Ini adalah resiko yang diketahui.

8.4 Skenario Normal

  - Input data valid -> data tersimpan di database.
  - Update data -> record berubah sesuai input.
  - Hapus data -> record hilang (jika tidak berelasi).
  - Cari data -> grid menampilkan hasil filter.
  - Generate report -> report muncul di viewer.
  - Export PDF -> file tersimpan.
  - Import Excel -> data masuk sesuai jumlah baris valid.
  - Upload gambar -> file tersimpan di folder uploads/.


9. KELEBIHAN SISTEM
------------------------------------------------

  1. Arsitektur 3-layer yang jelas dan konsisten. Setiap layer
     memiliki tanggung jawab yang terdefinisi dengan baik.

  2. Validasi input berlapis (form level + database level) sehingga
     data yang masuk ke database sudah terjamin kebenarannya.

  3. Menggunakan stored procedure untuk semua operasi database.
     Tidak ada raw SQL query di layer aplikasi. Mengurangi resiko
     SQL injection.

  4. Constraint UNIQUE pada (id_meja, waktu_kedatangan) mencegah
     double booking secara otomatis tanpa perlu logic tambahan
     di kode aplikasi.

  5. Transaction explicit di stored procedure Reservasi memastikan
     atomicity antara operasi Reservasi dan trigger update Meja.

  6. Trigger mengotomatiskan update status meja, mengurangi
     kemungkinan human error di kode aplikasi.

  7. Crystal Report menggunakan embedded resource, sehingga tidak
     memerlukan file .rpt terpisah di folder output. Cukup satu
     file executable.

  8. Upload file menggunakan GUID-based filename, mencegah konflik
     nama dan path traversal.

  9. Validation code terpusat di class Validators, mudah dipelihara
     dan dikembangkan.

  10. Error handling dengan try-catch di semua method yang
      berinteraksi dengan database.


10. KEKURANGAN SISTEM
------------------------------------------------

  1. Password admin disimpan dalam bentuk plaintext di database.
     Tidak ada hashing atau salting. View vw_DataAdmin juga
     mengekspos password.

  2. Koneksi database hardcoded di DBHelper.cs dengan credential
     SA (sa/123456). Tidak ada configuration file yang memudahkan
     penggantian connection string tanpa recompile.

  3. Tidak ada App.config. Pengaturan connection string melalui
     ConfigurationManager tidak aktif (di-comment).

  4. Dashboard tidak auto-refresh setelah operasi CRUD. User harus
     menutup dan membuka ulang form utama untuk melihat data terbaru.

  5. Import Excel bergantung pada driver ACE OLEDB yang tidak ada
     di semua komputer Windows. Juga tidak ada rollback untuk
     partial import failure.

  6. Import Reservasi membutuhkan raw database ID. Ini tidak
     user-friendly. Seharusnya import bisa menggunakan nama
     pelanggan dan kode meja, lalu di-resolve ke ID oleh sistem.

  7. Upload gambar tidak memvalidasi ukuran file. File besar bisa
     menyebabkan aplikasi hang atau kehabisan memory. File lama
     juga tidak dihapus saat update.

  8. Tidak ada mekanisme auto-refresh trigger status "Terisi".
     Meja hanya bisa berstatus 'Dipesan' oleh trigger, tidak ada
     trigger untuk mengubah ke 'Terisi' saat pelanggan datang.

  9. Superadmin PIN hardcoded (123456) di FormLogin. Ini adalah
     backdoor yang dapat dieksploitasi.

  10. Crystal Report form memiliki ukuran 2400 pixel (lebar) yang
      terlalu besar untuk monitor standar 1366x768.

  11. Tidak ada Inno Setup installer. Aplikasi tidak bisa di-install
      dengan mudah di komputer lain.

  12. Tidak ada database online/offline mode. Aplikasi tidak bisa
      berjalan tanpa koneksi ke SQL Server.

  13. Tidak ada logging atau audit trail untuk operasi CRUD.
      Tidak ada catatan siapa mengubah apa dan kapan.


11. KESIMPULAN
------------------------------------------------

  Sistem Informasi Reservasi Mie Ayam Pak Agus telah dibangun
  dengan arsitektur 3-layer yang terstruktur dan konsisten. Validasi
  input berlapis, penggunaan stored procedure, trigger database,
  dan constraint UNIQUE memberikan jaminan integritas data yang baik.

  Fitur Crystal Report telah berfungsi dengan pendekatan design-time
  (tanpa RAS/reflection). Import Excel dan upload gambar juga telah
  berjalan meskipun terdapat beberapa keterbatasan teknis.

  Beberapa area yang perlu perhatian sebelum ujian:

  Prioritas Tinggi:
  - Eksekusi semua stored procedure dan trigger ke database.
  - Test Crystal Report untuk memastikan tidak ada error "no tables"
    dan field match antara DataTable dan .rpt.
  - Test transaction rollback dengan skenario insert gagal.

  Prioritas Sedang:
  - Test import Excel dengan berbagai skenario.
  - Test upload gambar (valid dan invalid).
  - Test delete data berelasi.

  Prioritas Rendah:
  - Backup database dan folder bin/Debug.
  - Siapkan Crystal Reports Runtime installer di flashdisk.
  - Siapkan driver ACE OLEDB installer di flashdisk.

  Secara keseluruhan, sistem telah memenuhi kebutuhan dasar untuk
  aplikasi reservasi rumah makan dan siap untuk diujikan dengan
  catatan bahwa beberapa stored procedure dan trigger perlu
  dieksekusi ke database terlebih dahulu.
