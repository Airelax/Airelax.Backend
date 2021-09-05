using BCryptHelper = BCrypt.Net.BCrypt;

namespace Airelax.Application.Helpers
{
    public static class CryptographyHelper
    {
        public static string Hash(string text, out string salt) //(要被加密的字串,亂數產生的字串)
        {
            salt = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(text, salt);
        }

        public static bool VerifyHash(string text, string hashedText) //密碼是否相符 VerifyHash(輸入的字串，亂數加密後的密碼)
        {
            return BCryptHelper.Verify(text, hashedText);
        }
    }
}