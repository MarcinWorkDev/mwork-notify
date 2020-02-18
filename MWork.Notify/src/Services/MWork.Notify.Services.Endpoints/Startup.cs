using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MWork.Common.Sdk.WebApi.Extensions;
using MWork.Common.Sdk.WebApi.Framework.ErrorHandling;
using MWork.Common.Sdk.WebApi.Framework.Mongo;
using MWork.Common.Sdk.WebApi.Framework.RabbitMq;
using Serilog;
using Serilog.Core;
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
                .AddMediatR(Assembly.GetEntryAssembly());
            
            services
                .AddRabbitMq(o =>
                {
                    o.Hostnames = new List<string>()
                    {
                        "docker-farm"
                    };
                });

            services
                .AddMongo(o =>
                {
                    o.ConnectionString = Configuration.GetSecret("MONGODB_URL");
                    o.Database = "notify";
                })
                .AddMongoRepository<Endpoint>("endpoints");
            
            services
                .AddErrorHandlingMiddleware();
            
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
                .UseRouting()
                .UseErrorHandlingMiddleware()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}