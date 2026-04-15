using System;
using System.Windows.Forms;

namespace MieAyamPakAgus
{
    /// <summary>
    /// Aplikasi Manajemen Reservasi Mie Ayam Pak Agus
    /// Versi: 1.0.0
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Titik masuk utama aplikasi.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
