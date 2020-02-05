using Microsoft.AspNetCore.Hosting;

namespace MWork.Notify.Common.Api.Runtime.AWS
{
    public class AwsLambdaEntryPoint<TStartup> : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction where TStartup : class
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
        }
    }
}