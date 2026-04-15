using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MieAyamPakAgus
{
    /// <summary>
    /// Kelas utilitas untuk mengelola koneksi dan eksekusi query ke database SQL Server.
    /// </summary>
    public static class DBConfig
    {
        /// <summary>
        /// Connection string ke database MieAyamPakAgus.
        /// Sesuaikan dengan konfigurasi SQL Server lokal Anda.
        /// </summary>
        public static string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MieAyamPakAgus;Integrated Security=True";

        /// <summary>
        /// Timeout eksekusi command dalam detik (default: 30 detik).
        /// </summary>
        private const int CommandTimeout = 30;

        /// <summary>
        /// Membuat dan mengembalikan objek SqlConnection baru.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Mencoba koneksi ke database dan mengembalikan status berhasil/gagal.
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Mengeksekusi query SELECT dan mengembalikan hasilnya sebagai DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = CommandTimeout;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        /// <summary>
        /// Mengeksekusi query INSERT, UPDATE, atau DELETE.
        /// Mengembalikan jumlah baris yang terpengaruh, atau -1 jika terjadi error.
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = CommandTimeout;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        /// <summary>
        /// Mengeksekusi query dan mengembalikan nilai tunggal (baris pertama, kolom pertama).
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = CommandTimeout;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
