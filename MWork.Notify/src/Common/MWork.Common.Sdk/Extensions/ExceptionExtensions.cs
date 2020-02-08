using System;
using System.Net;

namespace MWork.Common.Sdk.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception SetHttpStatus(this Exception ex, HttpStatusCode status)
        {
            return ex.SetHttpStatus((int) status);
        }
        
        public static Exception SetHttpStatus(this Exception ex, int status)
        {
            ex.Data["HttpResponseSetStatus"] = status;

            return ex;
        }

        public static Exception ShowErrorMessage(this Exception ex, bool show = true)
        {
            ex.Data["HttpResponseShowMessage"] = show;

            return ex;
        }
    }
}