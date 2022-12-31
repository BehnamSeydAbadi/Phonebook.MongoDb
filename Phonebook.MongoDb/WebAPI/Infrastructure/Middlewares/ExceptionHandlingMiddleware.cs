using WebAPI.Common.ViewModels;
using Business.Common;
using Newtonsoft.Json;
using System.Net;

namespace WebAPI.Infrastructure.Middlewares
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;

                if (ex is BaseException)
                    statusCode = (int)HttpStatusCode.BadRequest;

                context.Response.StatusCode = statusCode;
                var jsonOutput = JsonConvert.SerializeObject(new OutputViewModel { Error = ex.Message });
                await context.Response.WriteAsync(jsonOutput);
            }
        }
    }
}
