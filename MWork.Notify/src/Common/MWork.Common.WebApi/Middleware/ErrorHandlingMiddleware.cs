using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MWork.Common.WebApi.Dtos;

namespace MWork.Common.WebApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                var httpStatusCode = (int) HttpStatusCode.InternalServerError;
                var httpErrorMessage = "An unexpected error occurred";
                
                if (ex.Data["HttpResponseSetStatus"] is int statusCode)
                {
                    if (Enum.TryParse<HttpStatusCode>(statusCode.ToString(), out var httpStatus))
                    {
                        httpStatusCode = (int)httpStatus;
                    }
                }
                
                if (ex.Data["HttpResponseShowMessage"] is bool showErrorMessage && showErrorMessage)
                {
                    httpErrorMessage = ex.Message;
                }

                context.Response.StatusCode = httpStatusCode;
                context.Response.ContentType = "application/json";

                var error = new ErrorDto()
                {
                    StatusCode = httpStatusCode,
                    Message = httpErrorMessage
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            }
        }
    }
}