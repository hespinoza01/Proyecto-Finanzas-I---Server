using System;
using System.Security.Cryptography;
using System.Text;

namespace Financecalc_Server.Utils
{
    public abstract class PasswordCipher
    {
        protected const string PUBLIC_KEY="random_secret-key";
        protected const int HasingIterationsCount = 10101;
        protected const int HashByteSize = 32;

        public static string Encrypt(string password)
        {
            Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(PUBLIC_KEY));
            hashGenerator.IterationCount = HasingIterationsCount;
            byte[] key = hashGenerator.GetBytes(HashByteSize);

            return Convert.ToBase64String(key);
        }

        public static bool CheckPasswordEncrypt(string passwordToCheck, string passwordStorage)
        {
            string result = Encrypt(passwordToCheck);

            return result.Equals(( passwordStorage ));
        }
    }
}