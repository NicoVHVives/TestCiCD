using Microsoft.AspNetCore.Antiforgery;
using WebApp.Models;

namespace WebApp
{
    public class AntiForgery
    {
        private RequestDelegate _next;


        public AntiForgery(RequestDelegate next)
        { _next = next; }
        public async Task Invoke(HttpContext context, IAntiforgery antiforgery)
        {
            if (!context.Request.Path.StartsWithSegments("/api"))
            {
                
                string? token = antiforgery.GetAndStoreTokens(context).RequestToken;
                if(token != null)
                {
                    context.Response.Cookies.Append("XSRF-TOKEN", token, new CookieOptions { HttpOnly = false });
                }
            }
    
            await _next(context);
            
        }
    }
}
