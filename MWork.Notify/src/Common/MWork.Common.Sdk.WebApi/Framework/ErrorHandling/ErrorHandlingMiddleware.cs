using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MWork.Common.Sdk.WebApi.Dtos;

namespace MWork.Common.Sdk.WebApi.Framework.ErrorHandling
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly ErrorHandlingMiddlewareOptions _options;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, IOptions<ErrorHandlingMiddlewareOptions> options)
        {
            _logger = logger;
            _options = options.Value;
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

                var httpStatusCode = _options.DefaultErrorStatusCode;
                var httpErrorMessage = _options.DefaultErrorMessage;
                
                if (ex.Data["HttpResponseSetStatus"] is int statusCode)
                {
                    if (Enum.IsDefined(typeof(HttpStatusCode), statusCode))
                    {
                        httpStatusCode = statusCode;
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