using System.Data;
using System.Data.SqlClient;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.DAL
{
    public class AdminDAL
    {
        private readonly DBHelper _db = new DBHelper();

        public DataTable GetAll()
        {
            return _db.ExecuteDataTable("SELECT * FROM vw_DataAdmin");
        }

        public int Insert(Admin admin)
        {
            SqlParameter[] p = {
                new SqlParameter("@username", admin.username),
                new SqlParameter("@password", admin.password)
            };
            return _db.ExecuteNonQuery("sp_TambahAdmin", p);
        }

        public int Update(Admin admin)
        {
            SqlParameter[] p = {
                new SqlParameter("@id_user", admin.id_user),
                new SqlParameter("@username", admin.username),
                new SqlParameter("@password", admin.password)
            };
            return _db.ExecuteNonQuery("sp_UpdateAdmin", p);
        }

        public int Delete(int id_user)
        {
            SqlParameter[] p = {
                new SqlParameter("@id_user", id_user)
            };
            return _db.ExecuteNonQuery("sp_DeleteAdmin", p);
        }

        public DataTable Search(string keyword)
        {
            SqlParameter[] p = {
                new SqlParameter("@keyword", keyword)
            };
            return _db.ExecuteDataTable("sp_SearchAdmin", p);
        }

        public DataTable Login(string username, string password)
        {
            string query = "SELECT id_user, username FROM Admin WHERE username = @u AND password = @p";
            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public int GetCount()
        {
            return (int)_db.ExecuteOutputParameter("sp_CountAdmin", "@Total");
        }
    }
}
