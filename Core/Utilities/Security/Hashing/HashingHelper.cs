using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt)) 
            {
                var computedash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedash.Length; i++)
                {
                    if (computedash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }
        public static string CreateUserAddress(string firstName, string lastName, string email)
        {
            string key = $"{firstName}/{lastName}+:-{email}";
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            using (var hashstring = new SHA256Managed())
            {
                byte[] hash = hashstring.ComputeHash(bytes);
                string hashString = string.Empty;
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                return hashString;
            }
        }
    }
}
