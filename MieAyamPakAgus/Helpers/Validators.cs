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
            if (username == null) username = "";
            username = username.Trim();

            if (username.Length == 0)
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
            if (password == null) password = "";

            if (password.Length == 0)
                return "Password tidak boleh kosong.";
            if (password.Length < 6)
                return "Password minimal 6 karakter.";
            if (password.Length > 100)
                return "Password maksimal 100 karakter.";
            return null;
        }

        public static string ValidateName(string name)
        {
            if (name == null) name = "";
            name = name.Trim();

            if (name.Length == 0)
                return "Nama tidak boleh kosong.";
            if (name.Length < 3)
                return "Nama minimal 3 karakter.";
            if (name.Length > 100)
                return "Nama maksimal 100 karakter.";
            if (Regex.IsMatch(name, @"[<>{}=()]"))
                return "Nama tidak boleh mengandung karakter khusus.";
            return null;
        }

        public static string ValidatePhone(string phone)
        {
            if (phone == null) phone = "";
            phone = phone.Trim();

            if (phone.Length == 0)
                return "Nomor telepon tidak boleh kosong.";

            int digitCount = 0;
            foreach (char c in phone)
                if (char.IsDigit(c)) digitCount++;

            if (digitCount < 10 || digitCount > 15)
                return "Nomor telepon harus 10-15 digit.";

            if (!Regex.IsMatch(phone, @"^[\+\d\-\(\)\s]+$"))
                return "Nomor telepon tidak valid.";

            return null;
        }

        public static string ValidateKodeMeja(string kode)
        {
            if (kode == null) kode = "";
            kode = kode.Trim();

            if (kode.Length == 0)
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
