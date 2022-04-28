using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TicTac.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, logger);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex, ILogger<ExceptionHandlingMiddleware> logger)
        {
            logger.LogError(ex.ToString());

            HttpStatusCode statusCode;

            if (ex is ArgumentOutOfRangeException)
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else if (ex is ArgumentException)
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (ex is NotImplementedException || ex is NotSupportedException)
            {
                statusCode = HttpStatusCode.NotImplemented;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message + Environment.NewLine + ex.ToString(), Code = "GE" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
