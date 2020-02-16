using System.Net;

namespace MWork.Common.Sdk.WebApi.Framework.ErrorHandling
{
    public class ErrorHandlingMiddlewareOptions
    {
        public string DefaultErrorMessage { get; set; } = "An unexpected error occurred";
        public int DefaultErrorStatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;
    }
}