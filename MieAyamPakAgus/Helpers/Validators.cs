using System;
using System.Text.RegularExpressions;

namespace MieAyamPakAgus.Helpers
{
    public static class Validators
    {
        public static string SanitizeInput(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Replace("'", "''").Replace("--", "").Replace(";", "");
        }

        public static string ValidateRequired(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                return fieldName + " tidak boleh kosong.";
            return null;
        }

        public static string ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return "Username tidak boleh kosong.";
            if (username.Length < 3)
                return "Username minimal 3 karakter.";
            if (username.Length > 50)
                return "Username maksimal 50 karakter.";
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                return "Username hanya boleh huruf, angka, dan underscore.";
            return null;
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Password tidak boleh kosong.";
            if (password.Length < 6)
                return "Password minimal 6 karakter.";
            if (password.Length > 100)
                return "Password maksimal 100 karakter.";
            return null;
        }

        public static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Nama tidak boleh kosong.";
            if (name.Length < 2)
                return "Nama minimal 2 karakter.";
            if (name.Length > 100)
                return "Nama maksimal 100 karakter.";
            if (Regex.IsMatch(name, @"[<>{}=()]"))
                return "Nama tidak boleh mengandung karakter khusus.";
            return null;
        }

        public static string ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return "Nomor telepon tidak boleh kosong.";
            if (!Regex.IsMatch(phone, @"^[0-9]+$"))
                return "Nomor telepon hanya boleh angka.";
            if (phone.Length < 10 || phone.Length > 15)
                return "Nomor telepon harus 10-15 digit.";
            return null;
        }

        public static string ValidateKodeMeja(string kode)
        {
            if (string.IsNullOrWhiteSpace(kode))
                return "Kode meja tidak boleh kosong.";
            if (kode.Length < 1 || kode.Length > 5)
                return "Kode meja harus 1-5 karakter.";
            return null;
        }

        public static string ValidateJumlahOrang(int value)
        {
            if (value < 1)
                return "Jumlah orang minimal 1.";
            if (value > 50)
                return "Jumlah orang maksimal 50.";
            return null;
        }
    }
}
