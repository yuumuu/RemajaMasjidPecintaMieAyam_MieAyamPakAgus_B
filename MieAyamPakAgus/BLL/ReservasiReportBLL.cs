using System;
using System.Data;
using MieAyamPakAgus.DAL;

namespace MieAyamPakAgus.BLL
{
    public class ReservasiReportBLL
    {
        private readonly ReservasiReportDAL _dal = new ReservasiReportDAL();

        public DataTable GetReportData(DateTime? tanggalAwal, DateTime? tanggalAkhir, int? idPelanggan, int? idMeja)
        {
            if (tanggalAwal > tanggalAkhir)
                throw new Exception("Tanggal awal tidak boleh lebih besar dari tanggal akhir.");

            return _dal.GetReportData(tanggalAwal, tanggalAkhir, idPelanggan, idMeja);
        }

        public DataTable GetPelangganLookup()
        {
            return _dal.GetFilterLookup("Pelanggan");
        }

        public DataTable GetMejaLookup()
        {
            return _dal.GetFilterLookup("Meja");
        }
    }
}
