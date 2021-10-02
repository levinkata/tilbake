using Microsoft.AspNetCore.Builder;
using Tilbake.MVC.CustomExceptionMiddleware;

namespace Tilbake.MVC.Extensions
{
    public static class GlobalExceptionMiddleware
    {
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
