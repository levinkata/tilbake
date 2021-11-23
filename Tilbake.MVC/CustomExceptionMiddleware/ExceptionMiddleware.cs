using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger = Serilog.Log.ForContext<ExceptionMiddleware>();

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex.Message}");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorViewModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
