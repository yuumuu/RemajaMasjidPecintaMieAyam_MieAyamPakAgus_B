CREATE DATABASE MieAyamPakAgus;
GO

USE	MieAyamPakAgus;
GO

-- TABEL ADMIN--
CREATE TABLE Admin (
	id_user INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(100) NOT NULL UNIQUE,
	password VARCHAR(100) NOT NULL
);
GO

--TABEL PELANGGAN --
CREATE TABLE Pelanggan (
	id_pelanggan INT PRIMARY KEY IDENTITY(1,1),
	nama VARCHAR(100) NOT NULL,
	no_telepon VARCHAR(100) NOT NULL
);
GO

--TABEL MEJA --
CREATE TABLE Meja (
	id_meja     INT PRIMARY KEY IDENTITY(1,1),
	kode        VARCHAR(5)  UNIQUE,
	kapasitas   INT,
	status_meja VARCHAR(20) NOT NULL DEFAULT 'Tersedia'
		 CONSTRAINT CHK_StatusMeja CHECK (status_meja IN ('Tersedia', 'Terisi', 'Dipesan'))
);
GO

--TABEL RESERVASI --
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
    CONSTRAINT FK_Reservasi_User        FOREIGN KEY (id_user)       REFERENCES Admin(id_user)
);
GO


-- Baru buat composite unique
ALTER TABLE Reservasi
ADD CONSTRAINT UQ_Reservasi_Meja_Waktu 
    UNIQUE (id_meja, waktu_kedatangan);
GO

--MASUKAN DATA USER--
INSERT INTO Admin(username, password) VALUES
	('Agus', 'Admin123');

exec sp_rename '[User]', 'Admin';

SELECT * FROM Admin;

--membuat stored procudere admin --
--insert admin--
CREATE PROCEDURE sp_TambahAdmin
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    IF @username IS NULL OR @username = ''
        THROW 50001, 'Username tidak boleh kosong.', 1;

    IF @password IS NULL OR @password = ''
        THROW 50001, 'Password tidak boleh kosong.', 1;

        THROW 50001, 'Username minimal 3 karakter.', 1;

        THROW 50001, 'Password minimal 6 karakter.', 1;

    IF EXISTS (
        SELECT 1 FROM Admin
        WHERE username = @username
    )
        THROW 50002, 'Username sudah digunakan.', 1;

    INSERT INTO Admin(username, password)
    VALUES(@username, @password);
END;
GO

-- update admin --
CREATE PROCEDURE sp_UpdateAdmin
    @id_user INT,
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    IF @id_user IS NULL
        THROW 50001, 'ID admin tidak boleh kosong.', 1;

    IF @username IS NULL OR @username = ''
        THROW 50001, 'Username tidak boleh kosong.', 1;

    IF @password IS NULL OR @password = ''
        THROW 50001, 'Password tidak boleh kosong.', 1;

        THROW 50001, 'Username minimal 3 karakter.', 1;

        THROW 50001, 'Password minimal 6 karakter.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Admin
        WHERE id_user = @id_user
    )
        THROW 50004, 'Admin tidak ditemukan.', 1;

    IF EXISTS (
        SELECT 1 FROM Admin
        WHERE username = @username
          AND id_user <> @id_user
    )
        THROW 50002, 'Username sudah digunakan oleh admin lain.', 1;

    UPDATE Admin
    SET
        username = @username,
        password = @password
    WHERE id_user = @id_user;
END;
GO

--delete admin--
CREATE PROCEDURE sp_DeleteAdmin
    @id_user INT
AS
BEGIN
    IF @id_user IS NULL
        THROW 50001, 'ID admin tidak boleh kosong.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Admin
        WHERE id_user = @id_user
    )
        THROW 50004, 'Admin tidak ditemukan.', 1;

    IF EXISTS (
        SELECT 1 FROM Reservasi
        WHERE id_user = @id_user
    )
        THROW 50003, 'Admin tidak dapat dihapus karena masih memiliki data reservasi.', 1;

    DELETE FROM Admin
    WHERE id_user = @id_user;
END;
GO

--search admin--
CREATE PROCEDURE sp_SearchAdmin
    @keyword VARCHAR(100)
AS
BEGIN
    IF @keyword IS NULL OR @keyword = ''
        THROW 50001, 'Keyword pencarian tidak boleh kosong.', 1;

    SELECT *
    FROM Admin
    WHERE username LIKE '%' + @keyword + '%';
END;
GO

--memebuat stored procudere pelanggan --
--insert pelanggan--
CREATE PROCEDURE sp_TambahPelanggan
    @nama VARCHAR(100),
    @no_telepon VARCHAR(12)
AS
BEGIN
    IF @nama IS NULL OR @nama = ''
        THROW 50001, 'Nama pelanggan tidak boleh kosong.', 1;

    IF @no_telepon IS NULL OR @no_telepon = ''
        THROW 50001, 'Nomor telepon tidak boleh kosong.', 1;

        THROW 50001, 'Nomor telepon tidak valid.', 1;

    IF @no_telepon LIKE '%[^0-9]%'
        THROW 50001, 'Nomor telepon hanya boleh berisi angka.', 1;

        THROW 50001, 'Nomor telepon harus antara 8 sampai 12 digit.', 1;

    INSERT INTO Pelanggan(nama, no_telepon)
    VALUES(@nama, @no_telepon);
END;
GO

--update pelanggan--
CREATE PROCEDURE sp_UpdatePelanggan
    @id_pelanggan INT,
    @nama VARCHAR(100),
    @no_telepon VARCHAR(12)
AS
BEGIN
    IF @id_pelanggan IS NULL
        THROW 50001, 'ID pelanggan tidak boleh kosong.', 1;

    IF @nama IS NULL OR @nama = ''
        THROW 50001, 'Nama pelanggan tidak boleh kosong.', 1;

    IF @no_telepon IS NULL OR @no_telepon = ''
        THROW 50001, 'Nomor telepon tidak boleh kosong.', 1;

    IF @no_telepon LIKE '%[^0-9]%'
        THROW 50001, 'Nomor telepon hanya boleh berisi angka.', 1;

        THROW 50001, 'Nomor telepon harus antara 8 sampai 12 digit.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Pelanggan
        WHERE id_pelanggan = @id_pelanggan
    )
        THROW 50004, 'Pelanggan tidak ditemukan.', 1;

    UPDATE Pelanggan
    SET
        nama = @nama,
        no_telepon = @no_telepon
    WHERE id_pelanggan = @id_pelanggan;
END;
GO

--delete pelanggan --
CREATE PROCEDURE sp_DeletePelanggan
    @id_pelanggan INT
AS
BEGIN
    IF @id_pelanggan IS NULL
        THROW 50001, 'ID pelanggan tidak boleh kosong.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Pelanggan
        WHERE id_pelanggan = @id_pelanggan
    )
        THROW 50004, 'Pelanggan tidak ditemukan.', 1;

    IF EXISTS (
        SELECT 1 FROM Reservasi
        WHERE id_pelanggan = @id_pelanggan
    )
        THROW 50003, 'Pelanggan tidak dapat dihapus karena masih memiliki data reservasi.', 1;

    DELETE FROM Pelanggan
    WHERE id_pelanggan = @id_pelanggan;
END;
GO

--seacrh pelanggan--
CREATE PROCEDURE sp_SearchPelanggan
    @keyword VARCHAR(100)
AS
BEGIN
    IF @keyword IS NULL OR @keyword = ''
        THROW 50001, 'Keyword pencarian tidak boleh kosong.', 1;

    SELECT *
    FROM Pelanggan
    WHERE nama LIKE '%' + @keyword + '%'
       OR no_telepon LIKE '%' + @keyword + '%';
END;
GO

--stored procudere meja--
--insert meja--
CREATE PROCEDURE sp_TambahMeja
    @kode VARCHAR(5),
    @kapasitas INT
AS
BEGIN
    IF @kode IS NULL OR @kode = ''
        THROW 50001, 'Kode meja tidak boleh kosong.', 1;

    IF @kapasitas IS NULL
        THROW 50001, 'Kapasitas meja tidak boleh kosong.', 1;

    IF @kapasitas <= 0
        THROW 50001, 'Kapasitas meja harus lebih dari 0.', 1;

    IF EXISTS (
        SELECT 1 FROM Meja
        WHERE kode = @kode
    )
        THROW 50002, 'Kode meja sudah digunakan.', 1;

    INSERT INTO Meja(kode, kapasitas)
    VALUES(@kode, @kapasitas);
END;
GO

--update meja--
CREATE PROCEDURE sp_UpdateStatusMeja
    @id_meja INT,
    @status_meja VARCHAR(20)
AS
BEGIN
    IF @id_meja IS NULL
        THROW 50001, 'ID meja tidak boleh kosong.', 1;

    IF @status_meja IS NULL OR @status_meja = ''
        THROW 50001, 'Status meja tidak boleh kosong.', 1;

    IF @status_meja NOT IN ('Tersedia', 'Terisi', 'Dipesan')
        THROW 50001, 'Status meja tidak valid. Nilai yang diizinkan: Tersedia, Terisi, Dipesan.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Meja
        WHERE id_meja = @id_meja
    )
        THROW 50004, 'Meja tidak ditemukan.', 1;

    UPDATE Meja
    SET status_meja = @status_meja
    WHERE id_meja = @id_meja;
END;
GO


--delete meja--
CREATE PROCEDURE sp_DeleteMeja
    @id_meja INT
AS
BEGIN
    IF @id_meja IS NULL
        THROW 50001, 'ID meja tidak boleh kosong.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM Meja
        WHERE id_meja = @id_meja
    )
        THROW 50004, 'Meja tidak ditemukan.', 1;

    IF EXISTS (
        SELECT 1
        FROM Reservasi
        WHERE id_meja = @id_meja
    )
        THROW 50003, 'Meja tidak dapat dihapus karena masih memiliki data reservasi.', 1;

    DELETE FROM Meja
    WHERE id_meja = @id_meja;
END;
GO

--search meja--
CREATE PROCEDURE sp_SearchMeja
    @keyword VARCHAR(20)
AS
BEGIN
    IF @keyword IS NULL OR @keyword = ''
        THROW 50001, 'Keyword pencarian tidak boleh kosong.', 1;

    SELECT *
    FROM Meja
    WHERE kode LIKE '%' + @keyword + '%'
       OR status_meja LIKE '%' + @keyword + '%';
END;
GO

--stored procudere reservasi--
--insert reservasi--
CREATE PROCEDURE sp_TambahReservasi
    @id_pelanggan INT,
    @id_meja INT,
    @id_user INT,
    @waktu_kedatangan DATETIME,
    @jumlah_orang INT,
    @bukti_transaksi VARCHAR(255)
AS
BEGIN
    IF @id_pelanggan IS NULL
        THROW 50001, 'ID pelanggan tidak boleh kosong.', 1;

    IF @id_meja IS NULL
        THROW 50001, 'ID meja tidak boleh kosong.', 1;

    IF @id_user IS NULL
        THROW 50001, 'ID user tidak boleh kosong.', 1;

    IF @waktu_kedatangan IS NULL
        THROW 50001, 'Waktu kedatangan tidak boleh kosong.', 1;

    IF @waktu_kedatangan < GETDATE()
        THROW 50001, 'Waktu kedatangan tidak boleh di masa lalu.', 1;

    IF @jumlah_orang IS NULL
        THROW 50001, 'Jumlah orang tidak boleh kosong.', 1;

    IF @jumlah_orang <= 0
        THROW 50001, 'Jumlah orang harus lebih dari 0.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Pelanggan
        WHERE id_pelanggan = @id_pelanggan
    )
        THROW 50004, 'Pelanggan tidak ditemukan.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Admin
        WHERE id_user = @id_user
    )
        THROW 50004, 'Admin tidak ditemukan.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Meja
        WHERE id_meja = @id_meja
    )
        THROW 50004, 'Meja tidak ditemukan.', 1;

    DECLARE @kapasitas INT;

    SELECT @kapasitas = kapasitas
    FROM Meja
    WHERE id_meja = @id_meja;

    IF @jumlah_orang > @kapasitas
        THROW 50001, 'Jumlah orang melebihi kapasitas meja.', 1;

    IF EXISTS (
        SELECT 1 FROM Reservasi
        WHERE id_meja = @id_meja
        AND waktu_kedatangan = @waktu_kedatangan
    )
        THROW 50002, 'Meja sudah dipesan pada waktu tersebut.', 1;

    INSERT INTO Reservasi(
        id_pelanggan,
        id_meja,
        id_user,
        waktu_kedatangan,
        jumlah_orang,
        bukti_transaksi
    )
    VALUES(
        @id_pelanggan,
        @id_meja,
        @id_user,
        @waktu_kedatangan,
        @jumlah_orang,
        @bukti_transaksi
    );

    -- Update status meja
    UPDATE Meja
    SET status_meja = 'Dipesan'
    WHERE id_meja = @id_meja;
END;
GO

--update reservasi--
CREATE PROCEDURE sp_UpdateReservasi
    @id_reservasi INT,
    @id_pelanggan INT,
    @id_meja INT,
    @id_user INT,
    @waktu_kedatangan DATETIME,
    @jumlah_orang INT,
    @bukti_transaksi VARCHAR(255)
AS
BEGIN
    BEGIN TRY

        IF @id_reservasi IS NULL
            THROW 50001, 'ID reservasi tidak boleh kosong.', 1;

        IF @id_pelanggan IS NULL
            THROW 50001, 'ID pelanggan tidak boleh kosong.', 1;

        IF @id_meja IS NULL
            THROW 50001, 'ID meja tidak boleh kosong.', 1;

        IF @id_user IS NULL
            THROW 50001, 'ID user tidak boleh kosong.', 1;

        IF @waktu_kedatangan IS NULL
            THROW 50001, 'Waktu kedatangan tidak boleh kosong.', 1;

        IF @waktu_kedatangan < GETDATE()
            THROW 50001, 'Waktu kedatangan tidak boleh di masa lalu.', 1;

        IF @jumlah_orang IS NULL
            THROW 50001, 'Jumlah orang tidak boleh kosong.', 1;

        IF @jumlah_orang <= 0
            THROW 50001, 'Jumlah orang harus lebih dari 0.', 1;

        IF NOT EXISTS (
            SELECT 1
            FROM Reservasi
            WHERE id_reservasi = @id_reservasi
        )
            THROW 50004, 'Reservasi tidak ditemukan.', 1;

        IF NOT EXISTS (
            SELECT 1 FROM Pelanggan
            WHERE id_pelanggan = @id_pelanggan
        )
            THROW 50004, 'Pelanggan tidak ditemukan.', 1;

        IF NOT EXISTS (
            SELECT 1 FROM Admin
            WHERE id_user = @id_user
        )
            THROW 50004, 'Admin tidak ditemukan.', 1;

        IF NOT EXISTS (
            SELECT 1
            FROM Meja
            WHERE id_meja = @id_meja
        )
            THROW 50004, 'Meja tidak ditemukan.', 1;

        DECLARE @kapasitas INT;

        SELECT @kapasitas = kapasitas
        FROM Meja
        WHERE id_meja = @id_meja;

        IF @jumlah_orang > @kapasitas
            THROW 50001, 'Jumlah orang melebihi kapasitas meja.', 1;

        IF EXISTS (
            SELECT 1
            FROM Reservasi
            WHERE id_meja = @id_meja
              AND waktu_kedatangan = @waktu_kedatangan
              AND id_reservasi <> @id_reservasi
        )
            THROW 50002, 'Meja sudah digunakan pada waktu tersebut.', 1;

        -- Update reservasi
        UPDATE Reservasi
        SET
            id_pelanggan = @id_pelanggan,
            id_meja = @id_meja,
            id_user = @id_user,
            waktu_kedatangan = @waktu_kedatangan,
            jumlah_orang = @jumlah_orang,
            bukti_transaksi = @bukti_transaksi
        WHERE id_reservasi = @id_reservasi;

    END TRY

    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

--delete reservasi--
CREATE PROCEDURE sp_DeleteReservasi
    @id_reservasi INT
AS
BEGIN
    IF @id_reservasi IS NULL
        THROW 50001, 'ID reservasi tidak boleh kosong.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM Reservasi
        WHERE id_reservasi = @id_reservasi
    )
        THROW 50004, 'Reservasi tidak ditemukan.', 1;

    DECLARE @id_meja INT;

    SELECT @id_meja = id_meja
    FROM Reservasi
    WHERE id_reservasi = @id_reservasi;

    DELETE FROM Reservasi
    WHERE id_reservasi = @id_reservasi;

    UPDATE Meja
    SET status_meja = 'Tersedia'
    WHERE id_meja = @id_meja;
END;
GO

--search reservasi--
CREATE PROCEDURE sp_SearchReservasi
    @keyword VARCHAR(100)
AS
BEGIN
    IF @keyword IS NULL OR @keyword = ''
        THROW 50001, 'Keyword pencarian tidak boleh kosong.', 1;

    SELECT
        r.id_reservasi,
        p.nama,
        m.kode,
        r.waktu_kedatangan,
        r.jumlah_orang,
        r.created_at
    FROM Reservasi r
    JOIN Pelanggan p
        ON r.id_pelanggan = p.id_pelanggan
    JOIN Meja m
        ON r.id_meja = m.id_meja
    WHERE p.nama LIKE '%' + @keyword + '%'
       OR m.kode LIKE '%' + @keyword + '%';
END;
GO

--membuat VIEW--
--admin--
CREATE VIEW vw_DataAdmin
AS
SELECT
    id_user,
    username
FROM Admin;
GO

--pelanggan--
CREATE VIEW vw_DataPelanggan
AS
SELECT
    id_pelanggan,
    nama,
    no_telepon
FROM Pelanggan;
GO

--meja--
CREATE VIEW vw_DataMeja
AS
SELECT
    id_meja,
    kode,
    kapasitas,
    status_meja
FROM Meja;
GO

--reservasi--
CREATE VIEW vw_DataReservasi
AS
SELECT
    r.id_reservasi,
    p.nama AS nama_pelanggan,
    m.kode AS kode_meja,
    a.username AS admin,
    r.waktu_kedatangan,
    r.jumlah_orang,
    r.bukti_transaksi,
    r.created_at
FROM Reservasi r
JOIN Pelanggan p
    ON r.id_pelanggan = p.id_pelanggan
JOIN Meja m
    ON r.id_meja = m.id_meja
JOIN Admin a
    ON r.id_user = a.id_user;
GO