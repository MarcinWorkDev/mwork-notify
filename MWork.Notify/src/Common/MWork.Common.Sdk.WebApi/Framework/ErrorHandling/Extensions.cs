using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MWork.Common.Sdk.WebApi.Framework.ErrorHandling
{
    public static class Extensions
    {
        public static IServiceCollection AddErrorHandlingMiddleware(this IServiceCollection services, Action<ErrorHandlingMiddlewareOptions> options = null)
        {
            services.Configure<ErrorHandlingMiddlewareOptions>(o => options?.Invoke(o));
            services.AddSingleton<ErrorHandlingMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}