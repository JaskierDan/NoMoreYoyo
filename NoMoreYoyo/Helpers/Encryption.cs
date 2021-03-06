using System;
using System.Security.Cryptography;
using System.Text;

namespace NoMoreYoyo.Helpers
{
    public static class Encryption
    {
        public static string SaltPassword(string password)
        {
            Random random = new Random();
            int salt = random.Next();
            string saltedPassword = salt.ToString();
            return saltedPassword;
        }
        public static string GenerateHashWithSalt(string enteredPassword, string enteredSalt)
        {
            string sHashWithSalt = enteredPassword + enteredSalt;
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(sHashWithSalt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
