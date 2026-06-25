using System;
using System.Data;
using System.Data.SqlClient;

namespace MieAyamPakAgus.DAL
{
    public class ReservasiReportDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public DataTable GetReportData(DateTime? tanggalAwal, DateTime? tanggalAkhir, int? idPelanggan, int? idMeja)
        {
            SqlParameter[] param = {
                new SqlParameter("@tanggal_awal", (object)tanggalAwal ?? DBNull.Value),
                new SqlParameter("@tanggal_akhir", (object)tanggalAkhir ?? DBNull.Value),
                new SqlParameter("@id_pelanggan", (object)idPelanggan ?? DBNull.Value),
                new SqlParameter("@id_meja", (object)idMeja ?? DBNull.Value)
            };
            return _db.ExecuteDataTable("sp_LaporanReservasi", param);
        }

        public DataTable GetFilterLookup(string tableName)
        {
            if (tableName == "Pelanggan")
                return _db.ExecuteDataTable("SELECT id_pelanggan, nama FROM Pelanggan");
            if (tableName == "Meja")
                return _db.ExecuteDataTable("SELECT id_meja, kode FROM Meja");
            return _db.ExecuteDataTable("SELECT 1 WHERE 1=0");
        }
    }
}
