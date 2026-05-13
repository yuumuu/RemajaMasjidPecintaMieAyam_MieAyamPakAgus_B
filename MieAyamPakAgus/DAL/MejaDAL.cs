using System.Data;
using System.Data.SqlClient;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.DAL
{
    public class MejaDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public DataTable GetAll()
        {
            return _db.ExecuteDataTable("SELECT * FROM vw_DataMeja");
        }

        public int Insert(Meja m)
        {
            SqlParameter[] param = {
                new SqlParameter("@kode", m.kode),
                new SqlParameter("@kapasitas", m.kapasitas)
            };
            return _db.ExecuteNonQuery("sp_TambahMeja", param);
        }

        public int UpdateStatus(int id, string status)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_meja", id),
                new SqlParameter("@status_meja", status)
            };
            return _db.ExecuteNonQuery("sp_UpdateStatusMeja", param);
        }

        public int Delete(int id)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_meja", id)
            };
            return _db.ExecuteNonQuery("sp_DeleteMeja", param);
        }

        public DataTable Search(string keyword)
        {
            SqlParameter[] param = {
                new SqlParameter("@keyword", keyword)
            };
            return _db.ExecuteDataTable("sp_SearchMeja", param);
        }

        public int GetCount()
        {
            return (int)_db.ExecuteOutputParameter("sp_CountMeja", "@Total");
        }
    }
}
