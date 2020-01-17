using System;
using System.Security.Cryptography;

namespace Financecalc_Server.Utils
{
    public abstract class PasswordCipher
    {
        protected string PUBLIC_KEY="random_secret-key";

        public static string Encrypt(string password)
        {
            byte[] salt;
            using (var derivedBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(password, saltSize: 32, iterations: 50000, HashAlgorithmName.SHA256))
            {
                salt = derivedBytes.Salt;
                byte[] key = derivedBytes.GetBytes(32); // 128 bits key

                return Convert.ToBase64String(key);
            }
        }

        public static bool CheckPasswordEncrypt(string passwordToCheck, string passwordStorage)
        {
            string result = Encrypt(passwordToCheck);

            return result.Equals(( passwordStorage ));
        }
    }
}