using MieAyamPakAgus.DAL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dal = new DashboardDAL();

        public DashboardStats GetStats()
        {
            return _dal.GetStats();
        }
    }
}
