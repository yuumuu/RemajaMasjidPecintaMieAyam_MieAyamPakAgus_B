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
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool AddReservasi(int idPelanggan, int idMeja, DateTime waktu, int jumlah, string bukti)
        {
            Validate(idPelanggan, idMeja, waktu, jumlah);
            Reservasi r = new Reservasi
            {
                id_pelanggan = idPelanggan,
                id_meja = idMeja,
                id_user = Session.IdUser,
                waktu_kedatangan = waktu,
                jumlah_orang = jumlah,
                bukti_transaksi = bukti
            };
            return _dal.Insert(r) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool UpdateReservasi(int id, int idPelanggan, int idMeja, DateTime waktu, int jumlah, string bukti)
        {
            if (id <= 0) throw new Exception("ID tidak valid.");
            Validate(idPelanggan, idMeja, waktu, jumlah);
            Reservasi r = new Reservasi
            {
                id_reservasi = id,
                id_pelanggan = idPelanggan,
                id_meja = idMeja,
                id_user = Session.IdUser,
                waktu_kedatangan = waktu,
                jumlah_orang = jumlah,
                bukti_transaksi = bukti
            };
            return _dal.Update(r) > 0;
            public int GetTotal() { return _dal.GetCount(); }
    }

        public bool DeleteReservasi(int id)
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

        private void Validate(int idPelanggan, int idMeja, DateTime waktu, int jumlah)
        {
            if (idPelanggan <= 0) throw new Exception("Pilih pelanggan.");
            if (idMeja <= 0) throw new Exception("Pilih meja.");
            if (waktu < DateTime.Now.AddMinutes(-5)) throw new Exception("Waktu kedatangan tidak boleh di masa lalu.");
            if (jumlah <= 0) throw new Exception("Jumlah orang harus lebih dari 0.");
            public int GetTotal() { return _dal.GetCount(); }
    }
        public int GetTotal() { return _dal.GetCount(); }
    }
}
