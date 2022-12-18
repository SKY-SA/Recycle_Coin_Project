using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
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
        public static string CreateUserId(string userName)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                var key = hmac.Key;
                var userId = hmac.ComputeHash(Encoding.UTF8.GetBytes(userName));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < userId.Length; i++)
                {
                    builder.Append(userId[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
