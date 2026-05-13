using System;
using System.Data;
using MieAyamPakAgus.DAL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.BLL
{
    public class AdminBLL
    {
        private readonly AdminDAL _dal = new AdminDAL();

        public DataTable GetData()
        {
            return _dal.GetAll();
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool AddAdmin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 3)
                throw new Exception("Username minimal 3 karakter.");
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                throw new Exception("Password minimal 6 karakter.");

            Admin admin = new Admin { username = username, password = password };
            return _dal.Insert(admin) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool UpdateAdmin(int id, string username, string password)
        {
            if (id <= 0) throw new Exception("ID tidak valid.");
            if (string.IsNullOrEmpty(username) || username.Length < 3)
                throw new Exception("Username minimal 3 karakter.");
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                throw new Exception("Password minimal 6 karakter.");

            Admin admin = new Admin { id_user = id, username = username, password = password };
            return _dal.Update(admin) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool DeleteAdmin(int id)
        {
            if (id <= 0) throw new Exception("ID tidak valid.");
            return _dal.Delete(id) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public DataTable SearchAdmin(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return GetData();
            return _dal.Search(keyword);
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Username dan Password harus diisi.");

            DataTable dt = _dal.Login(username, password);
            if (dt.Rows.Count > 0)
            {
                Session.IdUser = Convert.ToInt32(dt.Rows[0]["id_user"]);
                Session.Username = dt.Rows[0]["username"].ToString();
                return true;
                public int GetTotal() { return _dal.GetCount(); }
    }
            return false;
            public int GetTotal() { return _dal.GetCount(); }
    }
        public int GetTotal() { return _dal.GetCount(); }
    }
}
