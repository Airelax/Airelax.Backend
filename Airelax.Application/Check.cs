using System.Net;
using Lazcat.Infrastructure.ExceptionHandlers;

namespace Airelax.Application
{
    public static class Check
    {
        public static void CheckNull<T>(T obj)
        {
            if (obj == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"{nameof(T)} should not be null");
        }
    }
}