using System;

namespace MieAyamPakAgus.Models
{
    public class Reservasi
    {
        public int id_reservasi { get; set; }
        public int id_pelanggan { get; set; }
        public int id_meja { get; set; }
        public int id_user { get; set; }
        public DateTime waktu_kedatangan { get; set; }
        public int jumlah_orang { get; set; }
        public string bukti_transaksi { get; set; }
        public DateTime created_at { get; set; }
    }
}
