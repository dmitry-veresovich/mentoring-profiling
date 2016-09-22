using System;
using System.Security.Cryptography;

namespace PasswordHashGenerator
{
    public static class PasswordHashGenerator
    {
        //Original. Average ticks elapsed: ~200.000
        //public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        //{
        //    var iterate = 10000;
        //    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
        //    byte[] hash = pbkdf2.GetBytes(20);

        //    byte[] hashBytes = new byte[36];
        //    Array.Copy(salt, 0, hashBytes, 0, 16);
        //    Array.Copy(hash, 0, hashBytes, 16, 20);

        //    var passwordHash = Convert.ToBase64String(hashBytes);

        //    return passwordHash;
        //}

        // Optimized. Average ticks elapsed: ~192.000
        public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        {
            var iterate = 10000;

            var hash = new Rfc2898DeriveBytes(passwordText, salt, iterate).GetBytes(20);

            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
