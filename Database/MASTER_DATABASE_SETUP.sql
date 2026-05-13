/* 
   MASTER DATABASE SETUP - Mie Ayam Pak Agus
   Consolidated Script (Schema, Stored Procedures, Views, and Fixes)
   Run this script in SQL Server Management Studio (SSMS)
*/

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MieAyamPakAgus')
BEGIN
    CREATE DATABASE MieAyamPakAgus;
END
GO

USE MieAyamPakAgus;
GO

-- 1. DROP EXISTING TABLES (Optional, for clean setup)
-- DROP TABLE IF EXISTS Reservasi;
-- DROP TABLE IF EXISTS Meja;
-- DROP TABLE IF EXISTS Pelanggan;
-- DROP TABLE IF EXISTS Admin;

-- 2. CREATE TABLES
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Admin')
BEGIN
    CREATE TABLE Admin (
        id_user INT PRIMARY KEY IDENTITY(1,1),
        username VARCHAR(100) NOT NULL UNIQUE,
        password VARCHAR(100) NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Pelanggan')
BEGIN
    CREATE TABLE Pelanggan (
        id_pelanggan INT PRIMARY KEY IDENTITY(1,1),
        nama VARCHAR(100) NOT NULL,
        no_telepon VARCHAR(100) NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Meja')
BEGIN
    CREATE TABLE Meja (
        id_meja     INT PRIMARY KEY IDENTITY(1,1),
        kode        VARCHAR(5)  UNIQUE,
        kapasitas   INT,
        status_meja VARCHAR(20) NOT NULL DEFAULT 'Tersedia'
            CONSTRAINT CHK_StatusMeja CHECK (status_meja IN ('Tersedia', 'Terisi', 'Dipesan'))
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reservasi')
BEGIN
    CREATE TABLE Reservasi (
        id_reservasi      INT           PRIMARY KEY    IDENTITY(1,1),
        id_pelanggan      INT           NOT NULL,
        id_meja           INT           NOT NULL,
        id_user           INT           NOT NULL,
        waktu_kedatangan  DATETIME      NOT NULL,
        jumlah_orang      INT           NOT NULL,
        bukti_transaksi   VARCHAR(255)  NULL,
        created_at        DATETIME      NOT NULL       DEFAULT GETDATE(),
        CONSTRAINT FK_Reservasi_Pelanggan   FOREIGN KEY (id_pelanggan)  REFERENCES Pelanggan(id_pelanggan),
        CONSTRAINT FK_Reservasi_Meja        FOREIGN KEY (id_meja)       REFERENCES Meja(id_meja),
        CONSTRAINT FK_Reservasi_User        FOREIGN KEY (id_user)       REFERENCES Admin(id_user),
        CONSTRAINT UQ_Reservasi_Meja_Waktu  UNIQUE (id_meja, waktu_kedatangan)
    );
END
GO

-- 3. INITIAL DATA
IF NOT EXISTS (SELECT 1 FROM Admin WHERE username = 'Agus')
BEGIN
    INSERT INTO Admin(username, password) VALUES ('Agus', 'Admin123');
END
GO

-- 4. STORED PROCEDURES (ADMIN)
CREATE OR ALTER PROCEDURE sp_TambahAdmin
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    IF LEN(@username) < 3 THROW 50001, 'Username minimal 3 karakter.', 1;
    IF LEN(@password) < 6 THROW 50001, 'Password minimal 6 karakter.', 1;
    IF EXISTS (SELECT 1 FROM Admin WHERE username = @username)
        THROW 50002, 'Username sudah digunakan.', 1;

    INSERT INTO Admin(username, password) VALUES(@username, @password);
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateAdmin
    @id_user INT,
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Admin WHERE id_user = @id_user)
        THROW 50004, 'Admin tidak ditemukan.', 1;
    IF EXISTS (SELECT 1 FROM Admin WHERE username = @username AND id_user <> @id_user)
        THROW 50002, 'Username sudah digunakan oleh admin lain.', 1;

    UPDATE Admin SET username = @username, password = @password WHERE id_user = @id_user;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteAdmin @id_user INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservasi WHERE id_user = @id_user)
        THROW 50003, 'Admin tidak dapat dihapus karena masih memiliki data reservasi.', 1;
    DELETE FROM Admin WHERE id_user = @id_user;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchAdmin @keyword VARCHAR(100)
AS
BEGIN
    SELECT * FROM Admin WHERE username LIKE '%' + @keyword + '%';
END;
GO

-- 5. STORED PROCEDURES (PELANGGAN)
CREATE OR ALTER PROCEDURE sp_TambahPelanggan
    @nama VARCHAR(100),
    @no_telepon VARCHAR(15)
AS
BEGIN
    IF @nama = '' THROW 50001, 'Nama tidak boleh kosong.', 1;
    IF @no_telepon LIKE '%[^0-9]%' THROW 50001, 'Nomor telepon hanya boleh angka.', 1;

    INSERT INTO Pelanggan(nama, no_telepon) VALUES(@nama, @no_telepon);
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdatePelanggan
    @id_pelanggan INT,
    @nama VARCHAR(100),
    @no_telepon VARCHAR(15)
AS
BEGIN
    UPDATE Pelanggan SET nama = @nama, no_telepon = @no_telepon WHERE id_pelanggan = @id_pelanggan;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeletePelanggan @id_pelanggan INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservasi WHERE id_pelanggan = @id_pelanggan)
        THROW 50003, 'Data tidak bisa dihapus karena terkait reservasi.', 1;
    DELETE FROM Pelanggan WHERE id_pelanggan = @id_pelanggan;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchPelanggan @keyword VARCHAR(100)
AS
BEGIN
    SELECT * FROM Pelanggan WHERE nama LIKE '%' + @keyword + '%' OR no_telepon LIKE '%' + @keyword + '%';
END;
GO

-- 6. STORED PROCEDURES (MEJA)
CREATE OR ALTER PROCEDURE sp_TambahMeja @kode VARCHAR(5), @kapasitas INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Meja WHERE kode = @kode) THROW 50002, 'Kode meja sudah ada.', 1;
    INSERT INTO Meja(kode, kapasitas) VALUES(@kode, @kapasitas);
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateStatusMeja @id_meja INT, @status_meja VARCHAR(20)
AS
BEGIN
    UPDATE Meja SET status_meja = @status_meja WHERE id_meja = @id_meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteMeja @id_meja INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservasi WHERE id_meja = @id_meja)
        THROW 50003, 'Meja sedang digunakan dalam reservasi.', 1;
    DELETE FROM Meja WHERE id_meja = @id_meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchMeja @keyword VARCHAR(20)
AS
BEGIN
    SELECT * FROM Meja WHERE kode LIKE '%' + @keyword + '%' OR status_meja LIKE '%' + @keyword + '%';
END;
GO

-- 7. STORED PROCEDURES (RESERVASI)
CREATE OR ALTER PROCEDURE sp_TambahReservasi
    @id_pelanggan INT, @id_meja INT, @id_user INT, @waktu_kedatangan DATETIME, @jumlah_orang INT, @bukti_transaksi VARCHAR(255)
AS
BEGIN
    IF @waktu_kedatangan < GETDATE() THROW 50001, 'Waktu tidak boleh di masa lalu.', 1;
    
    INSERT INTO Reservasi(id_pelanggan, id_meja, id_user, waktu_kedatangan, jumlah_orang, bukti_transaksi)
    VALUES(@id_pelanggan, @id_meja, @id_user, @waktu_kedatangan, @jumlah_orang, @bukti_transaksi);

    UPDATE Meja SET status_meja = 'Dipesan' WHERE id_meja = @id_meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateReservasi
    @id_reservasi INT, @id_pelanggan INT, @id_meja INT, @id_user INT, @waktu_kedatangan DATETIME, @jumlah_orang INT, @bukti_transaksi VARCHAR(255)
AS
BEGIN
    UPDATE Reservasi SET 
        id_pelanggan = @id_pelanggan, id_meja = @id_meja, id_user = @id_user,
        waktu_kedatangan = @waktu_kedatangan, jumlah_orang = @jumlah_orang, bukti_transaksi = @bukti_transaksi
    WHERE id_reservasi = @id_reservasi;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteReservasi @id_reservasi INT
AS
BEGIN
    DECLARE @id_meja INT = (SELECT id_meja FROM Reservasi WHERE id_reservasi = @id_reservasi);
    DELETE FROM Reservasi WHERE id_reservasi = @id_reservasi;
    UPDATE Meja SET status_meja = 'Tersedia' WHERE id_meja = @id_meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchReservasi @keyword VARCHAR(100)
AS
BEGIN
    SELECT r.*, p.nama as nama_pelanggan, m.kode as kode_meja
    FROM Reservasi r
    JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
    JOIN Meja m ON r.id_meja = m.id_meja
    WHERE p.nama LIKE '%' + @keyword + '%' OR m.kode LIKE '%' + @keyword + '%';
END;
GO

-- 8. VIEWS
CREATE OR ALTER VIEW vw_DataAdmin AS SELECT id_user, username, password FROM Admin;
GO
CREATE OR ALTER VIEW vw_DataPelanggan AS SELECT * FROM Pelanggan;
GO
CREATE OR ALTER VIEW vw_DataMeja AS SELECT * FROM Meja;
GO
CREATE OR ALTER VIEW vw_DataReservasi AS
SELECT r.*, p.nama AS nama_pelanggan, m.kode AS kode_meja, a.username AS admin_name
FROM Reservasi r
JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
JOIN Meja m ON r.id_meja = m.id_meja
JOIN Admin a ON r.id_user = a.id_user;
GO

-- 9. COUNT PROCEDURES (OUTPUT PARAMETERS)
CREATE OR ALTER PROCEDURE sp_CountAdmin @Total INT OUTPUT AS BEGIN SELECT @Total = COUNT(*) FROM Admin END;
GO
CREATE OR ALTER PROCEDURE sp_CountPelanggan @Total INT OUTPUT AS BEGIN SELECT @Total = COUNT(*) FROM Pelanggan END;
GO
CREATE OR ALTER PROCEDURE sp_CountMeja @Total INT OUTPUT AS BEGIN SELECT @Total = COUNT(*) FROM Meja END;
GO
CREATE OR ALTER PROCEDURE sp_CountReservasi @Total INT OUTPUT AS BEGIN SELECT @Total = COUNT(*) FROM Reservasi END;
GO
