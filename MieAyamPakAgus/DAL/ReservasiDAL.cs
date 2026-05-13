using System.Data;
using System.Data.SqlClient;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.DAL
{
    public class ReservasiDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public DataTable GetAll()
        {
            return _db.ExecuteDataTable("SELECT * FROM vw_DataReservasi");
        public int GetCount() { return (int)_db.ExecuteOutputParameter(\sp_CountReservasi\, \@Total\); }
 }

        public int Insert(Reservasi r)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_pelanggan", r.id_pelanggan),
                new SqlParameter("@id_meja", r.id_meja),
                new SqlParameter("@id_user", r.id_user),
                new SqlParameter("@waktu_kedatangan", r.waktu_kedatangan),
                new SqlParameter("@jumlah_orang", r.jumlah_orang),
                new SqlParameter("@bukti_transaksi", (object)r.bukti_transaksi ?? System.DBNull.Value)
            };
            return _db.ExecuteNonQuery("sp_TambahReservasi", param);
        public int GetCount() { return (int)_db.ExecuteOutputParameter(\sp_CountReservasi\, \@Total\); }
 }

        public int Update(Reservasi r)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_reservasi", r.id_reservasi),
                new SqlParameter("@id_pelanggan", r.id_pelanggan),
                new SqlParameter("@id_meja", r.id_meja),
                new SqlParameter("@id_user", r.id_user),
                new SqlParameter("@waktu_kedatangan", r.waktu_kedatangan),
                new SqlParameter("@jumlah_orang", r.jumlah_orang),
                new SqlParameter("@bukti_transaksi", (object)r.bukti_transaksi ?? System.DBNull.Value)
            };
            return _db.ExecuteNonQuery("sp_UpdateReservasi", param);
        public int GetCount() { return (int)_db.ExecuteOutputParameter(\sp_CountReservasi\, \@Total\); }
 }

        public int Delete(int id)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_reservasi", id)
            };
            return _db.ExecuteNonQuery("sp_DeleteReservasi", param);
        public int GetCount() { return (int)_db.ExecuteOutputParameter(\sp_CountReservasi\, \@Total\); }
 }

        public DataTable Search(string keyword)
        {
            SqlParameter[] param = {
                new SqlParameter("@keyword", keyword)
            };
            return _db.ExecuteDataTable("sp_SearchReservasi", param);
        public int GetCount() { return (int)_db.ExecuteOutputParameter(\sp_CountReservasi\, \@Total\); }
 }
    public int GetCount() { return (int)_db.ExecuteOutputParameter(\sp_CountReservasi\, \@Total\); }
 }
}
