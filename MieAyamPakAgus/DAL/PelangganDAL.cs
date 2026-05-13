using System.Data;
using System.Data.SqlClient;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.DAL
{
    public class PelangganDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public DataTable GetAll()
        {
            return _db.ExecuteDataTable("SELECT * FROM vw_DataPelanggan");
        }

        public int Insert(Pelanggan p)
        {
            SqlParameter[] param = {
                new SqlParameter("@nama", p.nama),
                new SqlParameter("@no_telepon", p.no_telepon)
            };
            return _db.ExecuteNonQuery("sp_TambahPelanggan", param);
        }

        public int Update(Pelanggan p)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_pelanggan", p.id_pelanggan),
                new SqlParameter("@nama", p.nama),
                new SqlParameter("@no_telepon", p.no_telepon)
            };
            return _db.ExecuteNonQuery("sp_UpdatePelanggan", param);
        }

        public int Delete(int id)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_pelanggan", id)
            };
            return _db.ExecuteNonQuery("sp_DeletePelanggan", param);
        }

        public DataTable Search(string keyword)
        {
            SqlParameter[] param = {
                new SqlParameter("@keyword", keyword)
            };
            return _db.ExecuteDataTable("sp_SearchPelanggan", param);
        }

        public int GetCount()
        {
            return (int)_db.ExecuteOutputParameter("sp_CountPelanggan", "@Total");
        }
    }
}
