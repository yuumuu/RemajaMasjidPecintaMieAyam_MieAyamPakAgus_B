using System;
using System.Data;
using System.Linq;
using MieAyamPakAgus.DAL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.BLL
{
    public class MejaBLL
    {
        private readonly MejaDAL _dal = new MejaDAL();

        public DataTable GetData()
        {
            return _dal.GetAll();
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool AddMeja(string kode, int kapasitas)
        {
            if (string.IsNullOrEmpty(kode) || kode.Length > 5)
                throw new Exception("Kode meja wajib diisi dan maksimal 5 karakter.");
            if (kapasitas <= 0)
                throw new Exception("Kapasitas harus lebih dari 0.");

            Meja m = new Meja { kode = kode, kapasitas = kapasitas };
            return _dal.Insert(m) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool UpdateStatus(int id, string status)
        {
            string[] validStatus = { "Tersedia", "Terisi", "Dipesan" };
            if (!validStatus.Contains(status))
                throw new Exception("Status tidak valid.");

            return _dal.UpdateStatus(id, status) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool DeleteMeja(int id)
        {
            return _dal.Delete(id) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public DataTable Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return GetData();
            return _dal.Search(keyword);
            public int GetTotal() { return _dal.GetCount(); }
    }
        public int GetTotal() { return _dal.GetCount(); }
    }
}
