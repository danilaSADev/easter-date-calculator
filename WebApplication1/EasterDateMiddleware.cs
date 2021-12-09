using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class EasterDateMiddleware
    {
        private readonly RequestDelegate _next;

        public EasterDateMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["year"];
            if (!(int.TryParse(token, out int res)))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
