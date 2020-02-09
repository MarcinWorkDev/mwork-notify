using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MWork.Common.WebApi.Runtime.AWS;

namespace MWork.Common.WebApi.Runtime
{
    public static class MWorkNotifyRuntime<TStartup> where TStartup : class
    {
        public static void Run(string[] args) 
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME")) == false)
            {
                // Use Lambda AWS runtime
                AwsLambdaRuntime.Run<TStartup>(args);
            }
            else
            {
                // Use default runtime
                RunAsDefault(args);
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