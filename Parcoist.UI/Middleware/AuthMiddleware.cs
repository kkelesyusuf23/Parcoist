using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Parcoist.UI.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Kullanıcı giriş yapmamışsa
            var userId = context.Session.GetInt32("UserID");

            // Sadece /Admin yoluna erişim kontrolü
            if (userId == null && context.Request.Path.StartsWithSegments("/Admin"))
            {
                // Yönlendirme sadece /Auth/Login olacak
                context.Response.Redirect("/Auth/Login");
                return;
            }

            await _next(context);
        }
    }
}
