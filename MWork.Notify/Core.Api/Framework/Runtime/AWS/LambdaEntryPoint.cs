using Microsoft.AspNetCore.Hosting;

namespace MWork.Notify.Core.Api.Framework.Runtime.AWS
{
    public class LambdaEntryPoint<TStartup> : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction where TStartup : class
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
        }
    }
}