using System;
using System.Data;
using MieAyamPakAgus.DAL;
using MieAyamPakAgus.Models;

namespace MieAyamPakAgus.BLL
{
    public class ReservasiBLL
    {
        private readonly ReservasiDAL _dal = new ReservasiDAL();

        public DataTable GetData()
        {
            return _dal.GetAll();
        }

        public bool AddReservasi(int idPel, int idMeja, DateTime waktu, int jumlah, string bukti)
        {
            if (idPel <= 0 || idMeja <= 0 || jumlah <= 0)
                throw new Exception("Data reservasi tidak lengkap!");

            Reservasi r = new Reservasi
            {
                id_pelanggan = idPel,
                id_meja = idMeja,
                waktu_kedatangan = waktu,
                jumlah_orang = jumlah,
                bukti_transaksi = bukti
            };
            return _dal.Insert(r) > 0;
        }

        public bool UpdateReservasi(int id, int idPel, int idMeja, DateTime waktu, int jumlah, string bukti)
        {
            Reservasi r = new Reservasi
            {
                id_reservasi = id,
                id_pelanggan = idPel,
                id_meja = idMeja,
                waktu_kedatangan = waktu,
                jumlah_orang = jumlah,
                bukti_transaksi = bukti
            };
            return _dal.Update(r) > 0;
        }

        public bool DeleteReservasi(int id)
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
