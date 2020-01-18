using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;

namespace MWork.Notify.Presentation.Api.Framework.Runtime.AWS
{
    public static class AwsRuntime
    {
        public static void Run<TStartup>(string[] args) where TStartup : class
        {
            var lambdaEntry = new LambdaEntryPoint<TStartup>();
            var functionHandler = (Func<APIGatewayProxyRequest, ILambdaContext, Task<APIGatewayProxyResponse>>) (lambdaEntry.FunctionHandlerAsync);
            using var handlerWrapper = HandlerWrapper.GetHandlerWrapper(functionHandler, new JsonSerializer());
            using var bootstrap = new LambdaBootstrap(handlerWrapper);
            bootstrap.RunAsync().Wait();
        }
    }
}