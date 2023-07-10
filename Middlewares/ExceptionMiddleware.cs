using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using Newtonsoft.Json;

namespace WEGGAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment hostingEnvironment;

        public ExceptionMiddleware(IHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature == null || contextFeature.Error == null)
                return;

            context.Response.ContentType = "application/json";

            if (contextFeature.Error is ApplicationException || contextFeature.Error is AggregateException)
            {
                var mensagem = contextFeature.Error.InnerException != null
                    ? contextFeature.Error.InnerException.Message
                    : contextFeature.Error.Message;

                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(
                    new { 
                        erro = mensagem
                    }));
                return;
            }

            context.Response.StatusCode = (int)GetErrorCode(contextFeature.Error);

            if (hostingEnvironment.IsDevelopment())
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ProblemDetails()
                {
                    Status = context.Response.StatusCode,
                    Title = DateTime.Now.ToString() + " - " + contextFeature.Error.Message,
                    Detail = contextFeature.Error.StackTrace
                }));
            else
                await context.Response.WriteAsync(JsonConvert.SerializeObject("Erro inesperado"));
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case FormatException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                case ApplicationException _:
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}