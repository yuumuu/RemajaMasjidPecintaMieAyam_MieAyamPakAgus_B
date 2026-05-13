using System;
using System.Data;
using System.Text.RegularExpressions;
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
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool AddPelanggan(string nama, string no_telepon)
        {
            Validate(nama, no_telepon);
            Pelanggan p = new Pelanggan { nama = nama, no_telepon = no_telepon };
            return _dal.Insert(p) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool UpdatePelanggan(int id, string nama, string no_telepon)
        {
            if (id <= 0) throw new Exception("ID tidak valid.");
            Validate(nama, no_telepon);
            Pelanggan p = new Pelanggan { id_pelanggan = id, nama = nama, no_telepon = no_telepon };
            return _dal.Update(p) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool DeletePelanggan(int id)
        {
            if (id <= 0) throw new Exception("ID tidak valid.");
            return _dal.Delete(id) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public DataTable Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return GetData();
            return _dal.Search(keyword);
            public int GetTotal() { return _dal.GetCount(); }
    }

        private void Validate(string nama, string no_telepon)
        {
            if (string.IsNullOrEmpty(nama)) throw new Exception("Nama tidak boleh kosong.");
            if (string.IsNullOrEmpty(no_telepon)) throw new Exception("Nomor telepon tidak boleh kosong.");
            if (!Regex.IsMatch(no_telepon, @"^[0-9]{8,12}$"))
                throw new Exception("Nomor telepon harus angka dan 8-12 digit.");
            public int GetTotal() { return _dal.GetCount(); }
    }
        public int GetTotal() { return _dal.GetCount(); }
    }
}
