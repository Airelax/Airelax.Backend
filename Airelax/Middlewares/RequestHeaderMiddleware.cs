using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace Airelax.Middlewares
{
    public class RequestHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey(Defines.Define.Authorization.JWT_COOKIE_KEY))
            {
                context.Request.Headers.Add("Authorization", JwtBearerDefaults.AuthenticationScheme + " " + context.Request.Cookies[Defines.Define.Authorization.JWT_COOKIE_KEY]);
            }

            await _next(context);
        }
    }
}