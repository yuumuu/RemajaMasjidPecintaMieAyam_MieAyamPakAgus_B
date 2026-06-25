using System;
using System.Data;
using MieAyamPakAgus.DAL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.BLL
{
    public class PelangganBLL
    {
        private readonly PelangganDAL _dal = new PelangganDAL();

        public DataTable GetData()
        {
            return _dal.GetAll();
        }

        public bool AddPelanggan(string nama, string noTelp)
        {
            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(noTelp))
                throw new Exception("Nama dan No Telepon wajib diisi!");

            Pelanggan p = new Pelanggan { nama = nama, no_telepon = noTelp };
            return _dal.Insert(p) > 0;
        }

        public bool UpdatePelanggan(int id, string nama, string noTelp)
        {
            if (id <= 0 || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(noTelp))
                throw new Exception("Data tidak valid!");

            Pelanggan p = new Pelanggan { id_pelanggan = id, nama = nama, no_telepon = noTelp };
            return _dal.Update(p) > 0;
        }

        public bool DeletePelanggan(int id)
        {
            return _dal.Delete(id) > 0;
        }

        public DataTable Search(string keyword)
        {
            return _dal.Search(keyword);
        }

        public int GetTotal()
        {
            return _dal.GetCount();
        }

        public (int success, int failed, string error) ImportExcel(System.Data.DataTable dt)
        {
            int success = 0, failed = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    string nama = dt.Rows[i]["nama"]?.ToString()?.Trim();
                    string noTelp = dt.Rows[i]["no_telepon"]?.ToString()?.Trim();
                    if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(noTelp))
                    {
                        failed++;
                        continue;
                    }
                    AddPelanggan(nama, noTelp);
                    success++;
                }
                catch
                {
                    failed++;
                }
            }
            return (success, failed, null);
        }
    }
}
