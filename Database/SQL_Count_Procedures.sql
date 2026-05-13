-- Stored Procedure for Counting using Output Parameter
-- Run this in SQL Server Management Studio (SSMS)

CREATE OR ALTER PROCEDURE sp_CountAdmin
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Admin;
END
GO

CREATE OR ALTER PROCEDURE sp_CountPelanggan
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Pelanggan;
END
GO

CREATE OR ALTER PROCEDURE sp_CountMeja
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Meja;
END
GO

CREATE OR ALTER PROCEDURE sp_CountReservasi
    @Total INT OUTPUT
AS
BEGIN
    SELECT @Total = COUNT(*) FROM Reservasi;
END
GO
