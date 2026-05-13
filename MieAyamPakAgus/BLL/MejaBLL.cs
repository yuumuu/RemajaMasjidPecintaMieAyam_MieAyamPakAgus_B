using System;
using System.Data;
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
        }

        public bool AddMeja(string kode, int kapasitas)
        {
            if (string.IsNullOrEmpty(kode) || kapasitas <= 0)
                throw new Exception("Kode meja dan kapasitas tidak valid!");

            Meja m = new Meja { kode = kode, kapasitas = kapasitas };
            return _dal.Insert(m) > 0;
        }

        public bool UpdateStatus(int id, string status)
        {
            return _dal.UpdateStatus(id, status) > 0;
        }

        public bool DeleteMeja(int id)
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
    }
}
