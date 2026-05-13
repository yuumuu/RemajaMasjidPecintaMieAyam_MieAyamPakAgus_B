using System;
using System.Data;
using MieAyamPakAgus.DAL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.BLL
{
    public class AdminBLL
    {
        private readonly AdminDAL _dal = new AdminDAL();

        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Username dan Password harus diisi!");

            int id;
            if (_dal.Login(username, password, out id))
            {
                Session.IdUser = id;
                Session.Username = username;
                Session.IsSuperadmin = false;
                return true;
            }
            return false;
        }

        public DataTable GetData()
        {
            return _dal.GetAll();
        }

        public bool AddAdmin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Data tidak lengkap!");

            Admin a = new Admin { username = username, password = password };
            return _dal.Insert(a) > 0;
        }

        public bool UpdateAdmin(int id, string username, string password)
        {
            if (id <= 0 || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Data tidak valid!");

            Admin a = new Admin { id_user = id, username = username, password = password };
            return _dal.Update(a) > 0;
        }

        public bool DeleteAdmin(int id)
        {
            return _dal.Delete(id) > 0;
        }

        public DataTable SearchAdmin(string keyword)
        {
            return _dal.Search(keyword);
        }

        public int GetTotal()
        {
            return _dal.GetCount();
        }
    }
}
