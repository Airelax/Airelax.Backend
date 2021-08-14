using System;

namespace Airelax.Application
{
    public static class ByteExtension
    {
        public static string ConvertToBase64String(this byte[] bytes)
        {
            var from = bytes;
            if (bytes == null) from = Array.Empty<byte>();
            return Convert.ToBase64String(from);
        }
    }
}