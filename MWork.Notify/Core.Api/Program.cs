using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MWork.Notify.Core.Api.Framework.Runtime.AWS;

namespace MWork.Notify.Core.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Add WindowsService, Docker
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME")))
            {
                // Use default runtime
                CreateHostBuilder(args).Build().Run();
            }
            else
            {
                // Use Lambda AWS runtime
                AwsRuntime.Run<Startup>(args);
            }
        }
        
        // Default runtime
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}