using System.Data;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.DAL
{
    public class DashboardDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public DashboardStats GetStats()
        {
            DataTable dt = _db.ExecuteDataTable("sp_DashboardStats");
            if (dt.Rows.Count == 0) return new DashboardStats();

            DataRow r = dt.Rows[0];
            return new DashboardStats
            {
                TotalReservasi = (int)r["total_reservasi"],
                ReservasiHariIni = (int)r["reservasi_hari_ini"],
                TotalPelanggan = (int)r["total_pelanggan"],
                MejaTersedia = (int)r["meja_tersedia"],
                MejaTerpakai = (int)r["meja_terpakai"]
            };
        }
    }
}
