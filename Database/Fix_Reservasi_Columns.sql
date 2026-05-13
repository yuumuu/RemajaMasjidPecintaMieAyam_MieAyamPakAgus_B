USE MieAyamPakAgus;
GO

-- 1. Update View agar menyertakan ID FK untuk Binding
ALTER VIEW vw_DataReservasi
AS
SELECT
    r.id_reservasi,
    r.id_pelanggan,
    r.id_meja,
    p.nama AS nama_pelanggan,
    m.kode AS kode_meja,
    a.username AS admin,
    r.waktu_kedatangan,
    r.jumlah_orang,
    r.bukti_transaksi,
    r.created_at
FROM Reservasi r
JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
JOIN Meja m ON r.id_meja = m.id_meja
JOIN Admin a ON r.id_user = a.id_user;
GO

-- 2. Update Search Procedure agar menyertakan kolom lengkap
ALTER PROCEDURE sp_SearchReservasi
    @keyword VARCHAR(100)
AS
BEGIN
    IF @keyword IS NULL OR @keyword = ''
        THROW 50001, 'Keyword pencarian tidak boleh kosong.', 1;

    SELECT
        r.id_reservasi,
        r.id_pelanggan,
        r.id_meja,
        p.nama AS nama_pelanggan,
        m.kode AS kode_meja,
        r.waktu_kedatangan,
        r.jumlah_orang,
        r.bukti_transaksi,
        r.created_at
    FROM Reservasi r
    JOIN Pelanggan p ON r.id_pelanggan = p.id_pelanggan
    JOIN Meja m ON r.id_meja = m.id_meja
    WHERE p.nama LIKE '%' + @keyword + '%'
       OR m.kode LIKE '%' + @keyword + '%';
END;
GO
