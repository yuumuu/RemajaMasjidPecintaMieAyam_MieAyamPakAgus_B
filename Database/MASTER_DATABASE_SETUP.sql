/*
   MASTER DATABASE SETUP - Mie Ayam Pak Agus
   Run this script in SQL Server Management Studio (SSMS)
*/

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MieAyamPakAgus')
BEGIN
    CREATE DATABASE MieAyamPakAgus;
END
GO

USE MieAyamPakAgus;
GO

-- 1. CREATE TABLES
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Admin')
BEGIN
    CREATE TABLE Admin (
        id_user    INT PRIMARY KEY IDENTITY(1,1),
        username   VARCHAR(100) NOT NULL UNIQUE,
        password   VARCHAR(100) NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Pelanggan')
BEGIN
    CREATE TABLE Pelanggan (
        id_pelanggan INT PRIMARY KEY IDENTITY(1,1),
        nama         VARCHAR(100) NOT NULL,
        no_telepon   VARCHAR(100) NOT NULL
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
        CONSTRAINT FK_Reservasi_Pelanggan   FOREIGN KEY (id_pelanggan) REFERENCES Pelanggan(id_pelanggan),
        CONSTRAINT FK_Reservasi_Meja        FOREIGN KEY (id_meja)      REFERENCES Meja(id_meja),
        CONSTRAINT FK_Reservasi_User        FOREIGN KEY (id_user)      REFERENCES Admin(id_user),
        CONSTRAINT UQ_Reservasi_Meja_Waktu  UNIQUE (id_meja, waktu_kedatangan)
    );
END
GO

-- 2. INITIAL DATA
IF NOT EXISTS (SELECT 1 FROM Admin WHERE username = 'Agus')
BEGIN
    INSERT INTO Admin (username, password) VALUES ('Agus', 'Admin123');
END
GO

-- 3. STORED PROCEDURES — ADMIN
GO
CREATE OR ALTER PROCEDURE sp_TambahAdmin
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    IF LEN(@username) < 3 THROW 50001, 'Username minimal 3 karakter.', 1;
    IF LEN(@password) < 6 THROW 50001, 'Password minimal 6 karakter.', 1;
    IF EXISTS (SELECT 1 FROM Admin WHERE username = @username)
        THROW 50002, 'Username sudah digunakan.', 1;
    INSERT INTO Admin (username, password) VALUES (@username, @password);
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateAdmin
    @id_user  INT,
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

CREATE OR ALTER PROCEDURE sp_DeleteAdmin
    @id_user INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservasi WHERE id_user = @id_user)
        THROW 50003, 'Admin tidak dapat dihapus karena masih memiliki data reservasi.', 1;
    DELETE FROM Admin WHERE id_user = @id_user;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchAdmin
    @keyword VARCHAR(100)
AS
BEGIN
    SELECT * FROM Admin WHERE username LIKE '%' + @keyword + '%';
END;
GO

-- 4. STORED PROCEDURES — PELANGGAN
GO
CREATE OR ALTER PROCEDURE sp_TambahPelanggan
    @nama       VARCHAR(100),
    @no_telepon VARCHAR(15)
AS
BEGIN
    IF @nama = '' THROW 50001, 'Nama tidak boleh kosong.', 1;
    IF @no_telepon LIKE '%[^0-9]%' THROW 50001, 'Nomor telepon hanya boleh angka.', 1;
    INSERT INTO Pelanggan (nama, no_telepon) VALUES (@nama, @no_telepon);
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdatePelanggan
    @id_pelanggan INT,
    @nama         VARCHAR(100),
    @no_telepon   VARCHAR(15)
AS
BEGIN
    UPDATE Pelanggan SET nama = @nama, no_telepon = @no_telepon WHERE id_pelanggan = @id_pelanggan;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeletePelanggan
    @id_pelanggan INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservasi WHERE id_pelanggan = @id_pelanggan)
        THROW 50003, 'Data tidak bisa dihapus karena terkait reservasi.', 1;
    DELETE FROM Pelanggan WHERE id_pelanggan = @id_pelanggan;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchPelanggan
    @keyword VARCHAR(100)
AS
BEGIN
    SELECT * FROM Pelanggan
    WHERE nama LIKE '%' + @keyword + '%' OR no_telepon LIKE '%' + @keyword + '%';
END;
GO

-- 5. STORED PROCEDURES — MEJA
GO
CREATE OR ALTER PROCEDURE sp_TambahMeja
    @kode      VARCHAR(5),
    @kapasitas INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Meja WHERE kode = @kode)
        THROW 50002, 'Kode meja sudah ada.', 1;
    INSERT INTO Meja (kode, kapasitas) VALUES (@kode, @kapasitas);
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateStatusMeja
    @id_meja     INT,
    @status_meja VARCHAR(20)
AS
BEGIN
    UPDATE Meja SET status_meja = @status_meja WHERE id_meja = @id_meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteMeja
    @id_meja INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservasi WHERE id_meja = @id_meja)
        THROW 50003, 'Meja sedang digunakan dalam reservasi.', 1;
    DELETE FROM Meja WHERE id_meja = @id_meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchMeja
    @keyword VARCHAR(20)
AS
BEGIN
    SELECT * FROM Meja
    WHERE kode LIKE '%' + @keyword + '%' OR status_meja LIKE '%' + @keyword + '%';
END;
GO

-- 6. STORED PROCEDURES — RESERVASI
GO
CREATE OR ALTER PROCEDURE sp_TambahReservasi
    @id_pelanggan     INT,
    @id_meja          INT,
    @id_user          INT,
    @waktu_kedatangan DATETIME,
    @jumlah_orang     INT,
    @bukti_transaksi  VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @waktu_kedatangan < GETDATE()
            THROW 50001, 'Waktu tidak boleh di masa lalu.', 1;
        INSERT INTO Reservasi (id_pelanggan, id_meja, id_user, waktu_kedatangan, jumlah_orang, bukti_transaksi)
        VALUES (@id_pelanggan, @id_meja, @id_user, @waktu_kedatangan, @jumlah_orang, @bukti_transaksi);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateReservasi
    @id_reservasi     INT,
    @id_pelanggan     INT,
    @id_meja          INT,
    @id_user          INT,
    @waktu_kedatangan DATETIME,
    @jumlah_orang     INT,
    @bukti_transaksi  VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE Reservasi SET
            id_pelanggan = @id_pelanggan,
            id_meja = @id_meja,
            id_user = @id_user,
            waktu_kedatangan = @waktu_kedatangan,
            jumlah_orang = @jumlah_orang,
            bukti_transaksi = @bukti_transaksi
        WHERE id_reservasi = @id_reservasi;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteReservasi
    @id_reservasi INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        DELETE FROM Reservasi WHERE id_reservasi = @id_reservasi;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_SearchReservasi
    @keyword VARCHAR(100)
AS
BEGIN
    SELECT r.*, p.nama AS nama_pelanggan, m.kode AS kode_meja
    FROM Reservasi r
    JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
    JOIN Meja m      ON r.id_meja = m.id_meja
    WHERE p.nama LIKE '%' + @keyword + '%' OR m.kode LIKE '%' + @keyword + '%';
END;
GO

-- 7. VIEWS
GO
CREATE OR ALTER VIEW vw_DataAdmin
AS
    SELECT id_user, username FROM Admin;
GO

CREATE OR ALTER VIEW vw_DataPelanggan
AS
    SELECT * FROM Pelanggan;
GO

CREATE OR ALTER VIEW vw_DataMeja
AS
    SELECT * FROM Meja;
GO

CREATE OR ALTER VIEW vw_MejaWithDynamicStatus
AS
    SELECT m.id_meja, m.kode, m.kapasitas, m.status_meja,
        CASE
            WHEN EXISTS (
                SELECT 1 FROM Reservasi r
                WHERE r.id_meja = m.id_meja
                  AND CAST(r.waktu_kedatangan AS DATE) >= CAST(GETDATE() AS DATE)
            ) THEN 'Terpakai'
            ELSE 'Tersedia'
        END AS status_dinamis
    FROM Meja m;
GO

CREATE OR ALTER VIEW vw_DataReservasi
AS
    SELECT r.*, p.nama AS nama_pelanggan, m.kode AS kode_meja, a.username AS admin_name
    FROM Reservasi r
    JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
    JOIN Meja m      ON r.id_meja = m.id_meja
    JOIN Admin a     ON r.id_user = a.id_user;
GO

-- 8. COUNT PROCEDURES (OUTPUT PARAMETERS)
GO
CREATE OR ALTER PROCEDURE sp_CountAdmin
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Admin;
END;
GO

CREATE OR ALTER PROCEDURE sp_CountPelanggan
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Pelanggan;
END;
GO

CREATE OR ALTER PROCEDURE sp_CountMeja
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Meja;
END;
GO

CREATE OR ALTER PROCEDURE sp_CountReservasi
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Reservasi;
END;
GO

-- 9. REPORT PROCEDURE
GO
CREATE OR ALTER PROCEDURE sp_LaporanReservasi
    @tanggal_awal  DATETIME = NULL,
    @tanggal_akhir DATETIME = NULL,
    @id_pelanggan  INT = NULL,
    @id_meja       INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.id_reservasi,
        r.id_pelanggan,
        r.id_meja,
        r.id_user,
        p.nama          AS nama_pelanggan,
        p.no_telepon    AS telepon_pelanggan,
        m.kode          AS kode_meja,
        m.kapasitas     AS kapasitas_meja,
        a.username      AS admin_pembuat,
        r.waktu_kedatangan,
        r.jumlah_orang,
        r.bukti_transaksi,
        r.created_at,
        m.status_meja
    FROM Reservasi r
    JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
    JOIN Meja m      ON r.id_meja = m.id_meja
    JOIN Admin a     ON r.id_user = a.id_user
    WHERE (@tanggal_awal  IS NULL OR r.waktu_kedatangan >= @tanggal_awal)
      AND (@tanggal_akhir IS NULL OR r.waktu_kedatangan <= @tanggal_akhir)
      AND (@id_pelanggan  IS NULL OR r.id_pelanggan = @id_pelanggan)
      AND (@id_meja       IS NULL OR r.id_meja = @id_meja)
    ORDER BY r.waktu_kedatangan DESC;
END;
GO

USE MieAyamPakAgus;

-- 10. DASHBOARD STATS
GO
CREATE OR ALTER PROCEDURE sp_DashboardStats
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        (SELECT COUNT(*) FROM Reservasi) AS total_reservasi,
        (SELECT COUNT(*) FROM Reservasi WHERE CAST(waktu_kedatangan AS DATE) = CAST(GETDATE() AS DATE)) AS reservasi_hari_ini,
        (SELECT COUNT(*) FROM Pelanggan) AS total_pelanggan,
        (SELECT COUNT(*) FROM vw_MejaWithDynamicStatus WHERE status_dinamis = 'Tersedia') AS meja_tersedia,
        (SELECT COUNT(*) FROM vw_MejaWithDynamicStatus WHERE status_dinamis = 'Terpakai') AS meja_terpakai;
END;
GO

-- 11. TRIGGER — auto-update Meja status on Reservasi INSERT / UPDATE / DELETE
GO
CREATE OR ALTER TRIGGER trg_Reservasi_UpdateStatusMeja
ON Reservasi
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE Meja SET status_meja = 'Dipesan'
        WHERE id_meja IN (SELECT id_meja FROM inserted);
    END

    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE Meja SET status_meja = 'Tersedia'
        WHERE id_meja IN (SELECT id_meja FROM deleted)
          AND id_meja NOT IN (SELECT id_meja FROM Reservasi);
    END

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE Meja SET status_meja = 'Tersedia'
        WHERE id_meja IN (
            SELECT d.id_meja FROM deleted d
            INNER JOIN inserted i ON i.id_reservasi = d.id_reservasi
            WHERE i.id_meja <> d.id_meja
        ) AND id_meja NOT IN (SELECT id_meja FROM Reservasi);

        UPDATE Meja SET status_meja = 'Dipesan'
        WHERE id_meja IN (
            SELECT i.id_meja FROM inserted i
            INNER JOIN deleted d ON i.id_reservasi = d.id_reservasi
            WHERE i.id_meja <> d.id_meja
        );
    END
END;
GO
