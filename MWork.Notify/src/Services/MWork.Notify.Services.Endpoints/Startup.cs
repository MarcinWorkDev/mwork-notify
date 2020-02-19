using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MWork.Common.Sdk.WebApi.Extensions;
using MWork.Common.Sdk.WebApi.Framework.ErrorHandling;
using MWork.Common.Sdk.WebApi.Framework.Mongo;
using MWork.Common.Sdk.WebApi.Framework.RabbitMq;
using MWork.Notify.Services.Endpoints.Publishers.Events;
using Serilog;
using Endpoint = MWork.Notify.Services.Endpoints.Domain.Endpoint;

namespace MWork.Notify.Services.Endpoints
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRabbitMq(o =>
                {
                    o.Hostnames = new List<string>()
                    {
                        "docker-farm"
                    };
                });

            // Repository
            services
                .AddMongo(o =>
                {
                    o.ConnectionString = Configuration.GetSecret("MONGODB_URL");
                    o.Database = "notify";
                })
                .AddMongoRepository<Endpoint>("endpoints");
            
            // Middleware
            services
                .AddErrorHandlingMiddleware();
            
            // Common API
            services
                .AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            app
                .UseRabbitMq()
                .SubscribeEvent<EndpointCreated>();
            
            app
                .UseRouting()
                .UseErrorHandlingMiddleware()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}