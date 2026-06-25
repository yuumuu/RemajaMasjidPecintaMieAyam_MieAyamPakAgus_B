# TEST SCENARIO — Sistem Reservasi Mie Ayam Pak Agus

---

## 1. CRUD Pelanggan

### 1.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Tambah pelanggan** | Isi nama & no telepon valid → klik Tambah | Data masuk ke DataGridView & database |
| **Update pelanggan** | Pilih baris → ubah nama → klik Update | Data berubah di grid & database |
| **Hapus pelanggan** | Pilih baris → klik Hapus → konfirmasi Ya | Data hilang dari grid & database |
| **Cari pelanggan** | Ketik nama di textbox cari → klik Cari | Grid menampilkan hasil filter |

### 1.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Nama kosong** | Nama dikosongkan → klik Tambah | Error "Nama pelanggan harus diisi" |
| **Telepon kosong** | No telepon dikosongkan → klik Tambah | Error "No telepon harus diisi" |
| **Nama sudah ada** | Input nama yg sama persis → klik Tambah | Error "Data sudah ada" atau insert tetap jalan (cek apa ada pengecekan duplicate) |
| **Tanpa pilih baris → Update** | Langsung klik Update | Error / tombol disable |
| **Tanpa pilih baris → Hapus** | Langsung klik Hapus | Error / tombol disable |

### 1.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **Nama 100 karakter** | Input nama sepanjang MaxLength | Berhasil masuk atau di-cut |
| **Telepon 20 digit** | Input no HP panjang | Berhasil atau error tergantung validasi |
| **Spasi doang** | Nama = "   " → klik Tambah | Ditolak sebagai kosong |
| **Karakter spesial** | Nama = "@#$%" → klik Tambah | Harus ditolak atau lolos (tergantung rule) |
| **Hapus pelanggan yang punya reservasi** | Pilih pelanggan dengan data reservasi → Hapus | Error FK constraint atau cascade |

### 1.4 Data Sample

| Status | Nama | No Telepon |
|--------|------|------------|
| ✅ Valid | Budi Santoso | 081234567890 |
| ❌ Invalid | (kosong) | 081234567890 |
| ❌ Invalid | Budi Santoso | (kosong) |
| ⚠️ Edge | A | 0 |
| ⚠️ Edge | (100 karakter A) | 081234567890 |

### 1.5 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Tidak ada pengecekan duplikat nama → data ganda |
| Business Logic | Nomor telepon tidak divalidasi format → bisa input huruf |
| Database | Hapus pelanggan yg punya reservasi → error FK tanpa pesan jelas |
| UI/UX | Setelah tambah/update, data tidak auto-refresh |
| UI/UX | Error msg tidak user-friendly (muncul exception mentah) |

---

## 2. CRUD Meja

### 2.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Tambah meja** | Isi kode & kapasitas valid → Tambah | Data masuk |
| **Update meja** | Pilih baris → ubah kapasitas → Update | Berubah |
| **Hapus meja** | Pilih baris → Hapus | Hilang |
| **Cari meja** | Ketik kode → Cari | Terfilter |

### 2.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Kode kosong** | Kode dikosongkan → Tambah | Error |
| **Kapasitas 0** | Kapasitas = 0 → Tambah | Error (validasi jumlah orang minimal 1) |
| **Kode duplikat** | Input kode yg sudah ada → Tambah | Error |
| **Hapus meja yg punya reservasi** | Pilih meja dengan data reservasi → Hapus | Error FK |

### 2.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **Kapasitas 999** | Input kapasitas maksimal | Berhasil |
| **Kode 1 karakter** | Kode = "A" | Berhasil |
| **Kode 10 karakter** | Kode panjang | Berhasil atau di-cut |

### 2.4 Data Sample

| Status | Kode | Kapasitas |
|--------|------|-----------|
| ✅ Valid | M01 | 4 |
| ❌ Invalid | (kosong) | 4 |
| ❌ Invalid | M01 | 0 |
| ⚠️ Edge | M999 | 99 |
| ⚠️ Edge | A | 1 |

### 2.5 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Status meja tidak berubah manual (harus lewat trigger) → user mungkin kaget |
| Database | Hapus meja error FK → pesan tidak jelas |
| UI/UX | Tidak ada indikator status meja di list (tersedia/dipesan) |

---

## 3. CRUD Reservasi

### 3.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Tambah reservasi** | Pilih pelanggan, meja, tanggal (>= hari ini), jumlah orang, upload bukti → Tambah | Data masuk, status meja jadi "Dipesan" |
| **Update reservasi** | Pilih baris → ubah tanggal → Update | Berubah |
| **Hapus reservasi** | Pilih baris → Hapus → Ya | Hilang, status meja balik "Tersedia" |
| **Cari reservasi** | Ketik keyword → Cari | Terfilter |

### 3.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Tanggal masa lalu** | Pilih tanggal kemarin → Tambah | Error "Waktu tidak boleh di masa lalu" |
| **Jumlah orang > kapasitas meja** | Meja kapasitas 2, input 5 orang → Tambah | Error atau warning |
| **Tidak pilih pelanggan** | Biarkan kosong → Tambah | Error |
| **Tidak pilih meja** | Biarkan kosong → Tambah | Error |
| **Jumlah orang 0** | Input 0 → Tambah | Error (validasi minimal 1) |

### 3.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **Reservasi untuk hari ini (jam sudah lewat)** | Pilih jam sekarang → Tambah | Harusnya ditolak (waktu sudah lewat) |
| **Reservasi 2x meja sama di jam sama** | Booking meja M01 jam 12.00, booking lagi meja M01 jam 12.00 | Harusnya ada cek duplikasi waktu |
| **Upload file 10MB** | Pilih gambar besar → Tambah | Berhasil atau error timeout |
| **Jumlah orang 999** | Input 999 → Tambah | Error (kapasitas meja terbatas) |

### 3.4 Data Sample

| Status | Pelanggan | Meja | Tanggal | Orang | Bukti |
|--------|-----------|------|---------|-------|-------|
| ✅ Valid | Budi | M01 (kap 4) | besok 12:00 | 3 | foto.jpg |
| ❌ Invalid | Budi | M01 | kemarin | 3 | foto.jpg |
| ❌ Invalid | (kosong) | M01 | besok | 3 | foto.jpg |
| ⚠️ Edge | Budi | M01 (kap 2) | besok | 10 | (file 10MB) |
| ⚠️ Edge | Budi | M01 | besok 12:00 | 1 | (format .exe) |

### 3.5 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Tidak ada cek duplikasi meja + waktu → double booking |
| Business Logic | Kapasitas dilewati → meja penuh tapi tetap bisa booking |
| Database | Trigger update status meja belum di-execute → status berubah manual |
| UI/UX | DatePicker tidak ada validasi jam, hanya tanggal |
| Upload | File dengan ekstensi palsu bisa masuk |
| Upload | File lama tidak terhapus saat update |

---

## 4. Dashboard

### 4.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Lihat dashboard** | Buka form main | 5 label menampilkan angka |

### 4.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Database kosong** | Hapus semua data | Dashboard nampilin 0 (bukan error) |
| **Koneksi DB mati** | Matikan SQL Server | Error message, bukan crash |

### 4.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **1000 reservasi** | Insert 1000 data | Angka tampil benar |
| **Tengah malam (00:00)** | Buka dashboard pas pergantian hari | `reservasi_hari_ini` reset ke 0 |

### 4.4 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | `reservasi_hari_ini` pake `created_at` bukan `waktu_kedatangan` → salah hitung |
| Database | SP `sp_DashboardStats` belum di-update di DB → angka masih dari SP lama |
| UI/UX | Tidak auto-refresh setelah CRUD di form lain |
| UI/UX | Label angka mentok/terpotong kalo 5 digit |

---

## 5. Crystal Report

### 5.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Generate report** | Buka Form Laporan → klik Generate | Report muncul di viewer |
| **Filter tanggal** | Set rentang 1-30 Juni → Generate | Hanya data Juni |
| **Filter pelanggan** | Pilih pelanggan tertentu → Generate | Hanya data pelanggan tsb |
| **Filter meja** | Pilih meja tertentu → Generate | Hanya data meja tsb |
| **Export PDF** | Generate → klik Export PDF | File .pdf tersimpan |
| **Print** | Generate → klik Print | Dialog print muncul |

### 5.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Tidak ada data** | Filter tanggal tanpa data → Generate | "Data tidak ditemukan" |
| **TglAwal > TglAkhir** | Set dari > sampai → Generate | Error dari BLL |
| **CR Runtime tidak terinstall** | Jalankan di laptop tanpa CR | Error "Crystal Reports tidak ditemukan" |
| **Report file corrupt** | Hapus/rusak .rpt embedded | Error embedded resource |

### 5.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **1000 row data** | Generate report dengan data banyak | Loading lama tapi tampil |
| **Ukuran form 2400px** | Report tampil di monitor kecil | Scroll horizontal |
| **Export pas report belum di-generate** | Langsung klik Export PDF | "Generate dulu" |

### 5.4 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Field name mismatch antara .rpt dan DataTable → report kosong |
| UI/UX | Form ukuran 2400px → kepotong di monitor kecil |
| UI/UX | Viewer zoom tidak diatur → kedinginan default |
| Database | SP `sp_LaporanReservasi` belum di-update → query beda |

---

## 6. Upload Image

### 6.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Upload JPG** | Browse → pilih .jpg → preview muncul | Path tersimpan di txtBukti |
| **Upload PNG** | Browse → pilih .png → preview | Berhasil |
| **Ganti gambar** | Browse ulang → gambar preview berubah | File baru tercopy |
| **Lihat preview** | Pilih reservasi yg sudah ada gambar | PictureBox nampilin gambar |

### 6.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **File bukan gambar** | Pilih file .txt/.exe → preview | Error / preview gagal |
| **File 0 byte** | Pilih file kosong | Error (gagal load gambar) |
| **File sangat besar (100MB)** | Pilih gambar 100MB | Hang / timeout / error |
| **Path terlalu panjang** | File di folder deep path | Error copy file |
| **Cancel browse** | Buka dialog → klik Cancel | txtBukti tetap kosong |

### 6.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **File GIF animasi** | Upload .gif | Preview frame pertama |
| **Nama file unicode** | Upload "foto☺.jpg" | Berhasil atau error path |
| **Uploads folder dihapus** | Hapus folder uploads → upload ulang | Folder dibuat ulang |

### 6.4 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | File lama tidak dihapus saat update → sampah |
| Business Logic | Tidak ada validasi ukuran file → upload 1GB bisa crash |
| UI/UX | Preview gambar besar → form freeze (sync load) |
| UI/UX | Tidak ada loading indicator → user dikira freeze |
| Upload | Ekstensi palsu (.jpg.exe) bisa lolos filter |

---

## 7. Import Excel

### 7.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Import Pelanggan** | Pilih radio Pelanggan → Browse file Excel benar → Import | Data masuk ke DB |
| **Import Reservasi** | Pilih radio Reservasi → Browse file Excel benar → Import | Data masuk |
| **Preview data** | Browse Excel → data tampil di grid preview | Sesuai isi Excel |

### 7.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **File bukan Excel** | Pilih file .pdf | Error format |
| **Kolom tidak sesuai** | Excel tanpa kolom `nama`, `no_telepon` | Error / data kosong |
| **ID pelanggan tidak ada** | Import reservasi dengan `id_pelanggan` 9999 | Error FK / partial import |
| **ID meja tidak ada** | Import reservasi dengan `id_meja` 9999 | Error FK |
| **Format tanggal salah** | Kolom tanggal bukan datetime | Error |
| **File kosong** | Excel 0 baris | "Tidak ada data" |

### 7.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **Excel 5000 baris** | Import data besar | Lambat, loading lama |
| **Baris pertama header** | Excel tanpa HDR=YES | Baris pertama ikut keimport |
| **Data duplikat** | Import 2x file sama | Data ganda (atau error) |
| **Partial gagal (baris 100 error)** | Baris 1-99 valid, baris 100 error | Baris 1-99 masuk, 100 gagal (NO ROLLBACK) |
| **Spasi di value** | Nama = " Budi " | Trim atau tidak? |

### 7.4 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Tidak ada transaction → partial import (sebagian masuk, sebagian gagal) |
| Business Logic | Import reservasi pake ID langsung → user harus tau ID dari DB |
| Business Logic | Tidak ada cek duplikat → data ganda |
| Performance | Loop per-row → lambat untuk 1000+ baris |
| Dependencies | Butuh ACE OLEDB driver → error kalo gak terinstall |

---

## 8. Database Transaction

### 8.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Insert normal** | Tambah reservasi valid | COMMIT → data masuk + trigger jalan |
| **Delete normal** | Hapus reservasi | COMMIT → data hapus + trigger jalan |

### 8.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Insert gagal (FK violation)** | Pilih id_meja 9999 → Tambah | ROLLBACK → tidak ada data masuk |
| **Insert gagal di trigger** | Trigger error (misal update meja gagal) | ROLLBACK → reservasi batal masuk |
| **Update gagal** | Update dengan data invalid | ROLLBACK → data tetap seperti semula |
| **Koneksi putus di tengah** | Cabut kabel pas proses | ROLLBACK otomatis |

### 8.3 Confirmation

| Test | Step | Expected |
|------|------|----------|
| **Cek konsistensi** | Insert gagal → cek tabel Meja | Status meja TIDAK berubah (trigger ikut rollback) |
| **Cek rollback visual** | Insert gagal → refresh grid | Data tidak muncul |

### 8.4 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Validasi `waktu_kedatangan` setelah BEGIN TRAN → transaksi sia-sia kalo gagal |
| Database | SP transaksi belum dijalankan di DB → transaksi TIDAK BERJALAN |
| Database | C# tidak ada `TransactionScope` → kalo insert+trigger dipisah, rollback gak jalan |

---

## 9. Trigger SQL

### 9.1 Positive Case

| Test | Step | Expected |
|------|------|----------|
| **Insert reservasi** | Booking meja M01 | Status M01 berubah jadi "Dipesan" |
| **Delete reservasi** | Hapus booking M01 | Status M01 balik "Tersedia" |
| **Update pindah meja** | Ubah reservasi dari M01 ke M02 | M01 jadi "Tersedia", M02 jadi "Dipesan" |

### 9.2 Negative Case

| Test | Step | Expected |
|------|------|----------|
| **Insert multiple reservasi meja sama** | Booking M01 2x | (tergantung ada cek duplikat atau tidak) |
| **Delete reservasi, meja masih dipake** | M01 punya 2 reservasi, hapus 1 | M01 tetap "Dipesan" (masih ada reservasi lain) |

### 9.3 Edge Case

| Test | Step | Expected |
|------|------|----------|
| **Update waktu, meja tetap** | Ubah waktu reservasi, meja sama | Status meja tidak berubah |
| **Reservasi untuk hari ini** | Booking meja → trigger set "Dipesan" | Status belum berubah jadi "Terisi" |
| **Meja dengan 3 reservasi, hapus 1** | M01 punya 3 booking, hapus 1 | M01 tetap Dipesan (sisa 2) |

### 9.4 Bug Potential

| Area | Bug |
|------|-----|
| Business Logic | Trigger tidak handle status "Terisi" → meja gak pernah jadi "Terisi" |
| Business Logic | DELETE trigger cek `NOT IN (SELECT id_meja FROM Reservasi)` → subquery gak handle status reservasi yg batal |
| Database | Trigger belum di-execute di DB → gak jalan |
| Database | Trigger update meja yang sudah dihapus → error |

---

## RINGKASAN FITUR PALING RAWAN BUG

| Peringkat | Fitur | Alasan |
|-----------|-------|--------|
| 🥇 | **Import Excel** | Partial import tanpa rollback, pake ID langsung, butuh ACE driver, duplikat data |
| 🥇 | **Reservasi CRUD** | Relasi kompleks (pelanggan, meja, user), validasi tanggal & kapasitas, double booking |
| 🥈 | **Trigger + Transaction** | Belum di-execute ke DB, kalo belum jalan semua konsistensi data ilang |
| 🥉 | **Crystal Report** | Field mismatch, form oversize, butuh CR Runtime terinstall |
| 4 | **Dashboard** | SP lama vs baru, `created_at` vs `waktu_kedatangan`, no auto-refresh |
| 5 | **Upload Image** | No size limit, orphan files, no type validation |
| 6 | **CRUD Pelanggan** | Relatif stabil, risiko duplikat nama |
| 7 | **CRUD Meja** | Paling sederhana, risiko kecil |

---

## CHECKLIST PRIORITAS SEBELUM UJIAN

### 🔴 HIGH (WAJIB)
- [ ] Execute semua SP + Trigger di database (TablePlus → select → execute)
- [ ] Test reservasi: tanggal valid, kapasitas cukup
- [ ] Test trigger: insert → cek status meja berubah
- [ ] Test transaction: buat insert error → cek data tetap konsisten
- [ ] Test Crystal Report: generate, export PDF

### 🟡 MEDIUM
- [ ] Test upload gambar: .jpg, .png, file besar, ganti gambar
- [ ] Test import Excel: file valid, file error kolom
- [ ] Test dashboard: angka cocok dengan data asli
- [ ] Test CRUD Pelanggan + Meja
- [ ] Test search di masing-masing form

### 🟢 LOW
- [ ] Test error message: pastikan user-friendly, bukan exception mentah
- [ ] Test form size: pastikan ga kepotong di monitor 1366x768
- [ ] Test cleanup: hapus file upload yang tidak terpakai
- [ ] Backup database (export .sql atau .bak)
- [ ] Backup bin/Debug folder + CR Runtime installer ke flashdisk
