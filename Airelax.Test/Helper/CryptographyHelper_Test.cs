using System.Net;
using Airelax.Infrastructure.Helpers;
using Shouldly;
using Xunit;

namespace Airelax.Test.Helper
{
    public class CryptographyHelperTest
    {
        private const string Plaintext = "{\"Name\":\"Test\",\"ID\":\"A123456789\"}";
        private const string Key = "A123456789012345";
        private const string IV = "B123456789012345";
        private const string Ciphertext = "7woM9RorZKAtXJRVccAb0qhHYm+5lnlhBzyfh5EZdNck7PacNsRHgv/Jvp//ajJidqcQcs0UmAgPQVjXQHeziw==";

        [Fact]
        public void AESEncrypt_Test()
        {
            var aesEncrypt = CryptographyHelper.AesEncrypt(Plaintext, Key, IV, true);
            aesEncrypt.ShouldBe(Ciphertext);
        }

        [Fact]
        public void AESDecrypt_Test()
        {
            var aesDecrypt = CryptographyHelper.AesDecrypt(Ciphertext, Key, IV, true);
            aesDecrypt.ShouldBe(Plaintext);
        }
    }
}