using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MWork.Notify.Core.Api.Framework;
using MWork.Notify.Core.Api.Framework.Runtime;
using MWork.Notify.Core.Api.Framework.Runtime.AWS;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Logic;

namespace MWork.Notify.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register core services
            services.AddScoped<INotifyQueuePublisherFactory, NotifyQueuePublisherFactory>();
            
            // Register AWS plugins
            services.RegisterAwsPlugins(Configuration);
            
            // Register CQRS
            services.AddMediatR(CoreServicesConstants.Assembly);
            
            // Add controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}