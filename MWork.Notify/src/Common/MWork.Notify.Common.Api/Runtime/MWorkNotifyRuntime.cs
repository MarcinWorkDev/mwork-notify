using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MWork.Notify.Common.Api.Runtime.AWS;

namespace MWork.Notify.Common.Api.Runtime
{
    public static class MWorkNotifyRuntime<TStartup> where TStartup : class
    {
        // TODO: Add WindowsService, Docker
        public static void Run(string[] args) 
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME")))
            {
                // Use default runtime
                RunAsDefault(args);
            }
            else
            {
                // Use Lambda AWS runtime
                AwsLambdaRuntime.Run<TStartup>(args);
            }
        }
        
        private static void RunAsDefault(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<TStartup>(); })
                .Build()
                .Run();
        }
    }
}