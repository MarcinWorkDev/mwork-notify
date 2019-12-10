using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MWork.Notify.Core.Data;
using MWork.Notify.Core.Domain.Abstractions;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Logic;
using MWork.Notify.Core.Services;
using MWork.Notify.Plugins.Dispatchers.Push;

namespace MWork.Notify.Presentation.Api
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
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            
            services.AddSingleton<INotificationBuilder, NotificationBuilder>();
            services.AddSingleton<INotificationDispatcher>(new PushMessageDispatcher(o =>
            {
                o.Credentials = System.IO.File.ReadAllText("Secure/firebase-adminsdk.json");
            }));
            
            services.AddMediatR(CoreServicesConstants.Assembly);
            
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