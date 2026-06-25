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
        }

        public int Insert(Reservasi r)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_pelanggan", r.id_pelanggan),
                new SqlParameter("@id_meja", r.id_meja),
                new SqlParameter("@id_user", Session.IdUser),
                new SqlParameter("@waktu_kedatangan", r.waktu_kedatangan),
                new SqlParameter("@jumlah_orang", r.jumlah_orang),
                new SqlParameter("@bukti_transaksi", r.bukti_transaksi)
            };
            return _db.ExecuteNonQuery("sp_TambahReservasi", param);
        }

        public int Update(Reservasi r)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_reservasi", r.id_reservasi),
                new SqlParameter("@id_pelanggan", r.id_pelanggan),
                new SqlParameter("@id_meja", r.id_meja),
                new SqlParameter("@id_user", Session.IdUser),
                new SqlParameter("@waktu_kedatangan", r.waktu_kedatangan),
                new SqlParameter("@jumlah_orang", r.jumlah_orang),
                new SqlParameter("@bukti_transaksi", r.bukti_transaksi)
            };
            return _db.ExecuteNonQuery("sp_UpdateReservasi", param);
        }

        public int Delete(int id)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_reservasi", id)
            };
            return _db.ExecuteNonQuery("sp_DeleteReservasi", param);
        }

        public DataTable Search(string keyword)
        {
            SqlParameter[] param = {
                new SqlParameter("@keyword", keyword)
            };
            return _db.ExecuteDataTable("sp_SearchReservasi", param);
        }

        public int GetCount()
        {
            return (int)_db.ExecuteOutputParameter("sp_CountReservasi", "@Total");
        }
    }
}
