using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace Airelax.Application.Helpers
{
    public class Cryptography
    {
        public static string Hash(string Text, out string Salt) //(要被加密的字串,亂數產生的字串)
        {
            Salt = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(Text, Salt);
        }
        public static bool VerifyHash(string Text, string HashedText) //密碼是否相符 VerifyHash(輸入的字串，亂數加密後的密碼)
        {
            return BCryptHelper.Verify(Text, HashedText);
        }
    }
}
