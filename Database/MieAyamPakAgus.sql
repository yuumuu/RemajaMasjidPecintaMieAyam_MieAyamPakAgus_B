CREATE DATABASE MieAyamPakAgus;

USE	MieAyamPakAgus;

-- TABEL ADMIN--
CREATE TABLE Admin (
	id_user INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(100) NOT NULL UNIQUE,
	password VARCHAR(100) NOT NULL
);

--TABEL PELANGGAN --
CREATE TABLE Pelanggan (
	id_pelanggan INT PRIMARY KEY IDENTITY(1,1),
	nama VARCHAR(100) NOT NULL,
	no_telepon VARCHAR(100) NOT NULL
);

--TABEL MEJA --
CREATE TABLE Meja (
	id_meja     INT PRIMARY KEY IDENTITY(1,1),
	kode        VARCHAR(5)  UNIQUE,
	kapasitas   INT,
	status_meja VARCHAR(20) NOT NULL DEFAULT 'Tersedia'
		 CONSTRAINT CHK_StatusMeja CHECK (status_meja IN ('Tersedia', 'Terisi', 'Dipesan'))
);

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
    CONSTRAINT FK_Reservasi_User        FOREIGN KEY (id_user)       REFERENCES Admin(id_user),
	CONSTRAINT UQ_Reservasi_Meja_Waktu  UNIQUE (id_meja, waktu_kedatangan)
);

--MASUKAN DATA USER--
INSERT INTO Admin(username, password) VALUES
	('Agus', 'Admin123');

SELECT * FROM Admin;