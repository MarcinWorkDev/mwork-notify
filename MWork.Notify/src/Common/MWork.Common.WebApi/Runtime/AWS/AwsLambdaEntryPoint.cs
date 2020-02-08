using Microsoft.AspNetCore.Hosting;

namespace MWork.Common.WebApi.Runtime.AWS
{
    public class AwsLambdaEntryPoint<TStartup> : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction where TStartup : class
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
        }
    }
}