using System.Data;
using System.Data.SqlClient;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.DAL
{
    public class AdminDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public bool Login(string username, string password, out int id)
        {
            id = 0;
            SqlParameter[] param = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dt = _db.ExecuteDataTable("sp_LoginAdmin", param);
            if (dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["id_user"];
                return true;
            }
            return false;
        }

        public DataTable GetAll()
        {
            return _db.ExecuteDataTable("SELECT * FROM vw_DataAdmin");
        }

        public int Insert(Admin a)
        {
            SqlParameter[] param = {
                new SqlParameter("@username", a.username),
                new SqlParameter("@password", a.password)
            };
            return _db.ExecuteNonQuery("sp_TambahAdmin", param);
        }

        public int Update(Admin a)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_user", a.id_user),
                new SqlParameter("@username", a.username),
                new SqlParameter("@password", a.password)
            };
            return _db.ExecuteNonQuery("sp_UpdateAdmin", param);
        }

        public int Delete(int id)
        {
            SqlParameter[] param = {
                new SqlParameter("@id_user", id)
            };
            return _db.ExecuteNonQuery("sp_DeleteAdmin", param);
        }

        public DataTable Search(string keyword)
        {
            SqlParameter[] param = {
                new SqlParameter("@keyword", keyword)
            };
            return _db.ExecuteDataTable("sp_SearchAdmin", param);
        }

        public int GetCount()
        {
            return (int)_db.ExecuteOutputParameter("sp_CountAdmin", "@Total");
        }
    }
}
