using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MieAyamPakAgus.DAL
{
    public class DBHelper
    {
        private readonly string connStr;

        public DBHelper()
        {
            //connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            connStr = $@"Data Source=Haidaryuum,1433;Initial Catalog=MieAyamPakAgus;User ID=sa;Password=123456;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }

        public DataTable ExecuteDataTable(string spName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = spName.Trim().Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string spName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = spName.Trim().Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string spName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = spName.Trim().Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public object ExecuteOutputParameter(string spName, string outputParamName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = spName.Trim().Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    SqlParameter outParam = new SqlParameter(outputParamName, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return outParam.Value;
                }
            }
        }
    }
}
