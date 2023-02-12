
using ThreePillarsTask.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Project.Services.Helper.ErrorHandler;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using Project.Services.ModalServices;

namespace ThreePillarsTask.Middlewares
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }


        public async Task Invoke(HttpContext httpContext, ILogErrorHandler logger)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (httpContext.User.Claims.Any())
                {
                    var screen = httpContext.GetRouteValue("controller");
                    var username = httpContext.User.Claims.FirstOrDefault(u => u.Type == nameof(UserInfo.ChildUserName))?.Value;
                    logger.SysError(new LogErrorModel()
                    {
                        Msg = ex.Message,
                        Screen = screen.ToString(),
                        User = username

                    });
                    HandleExceptionAsync(httpContext, ex);
                }
            }
        }
        private void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int?)exception.Data["StatusCode"] ?? context.Response.StatusCode;
            context.Response.WriteAsync(new
            {
                context.Response.StatusCode,
                exception.Message
            }.ToString());
        }

    }

    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
