using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MWork.Common.WebApi.Middleware;
using MWork.Notify.Services.Messages.Repositories;
using MWork.Notify.Services.Messages.Services;
using MWork.Notify.Services.Messages.Services.Abstractions;
using MWork.Notify.Services.Messages.Services.Models;

namespace MWork.Notify.Services.Messages
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
            services.AddMediatR(Assembly.GetEntryAssembly());
            
            services.AddSingleton<IMessageRepository, MessageRepository>();
            //DataMapper.ValidateConfiguration();
            
            services.AddSingleton<INotificationPublisherFactory, NotificationPublisherFactory>();
            services.AddScoped<INotificationPublisher, NotificationEmailPublisher>(sp
                => new NotificationEmailPublisher(new PublisherOptions()
                {
                    QueueName = "mwork-notify-dispatcher-email"
                }));
            services.AddScoped<INotificationPublisher, NotificationPushPublisher>(sp
                => new NotificationPushPublisher(new PublisherOptions()
                {
                    QueueName = "mwork-notify-dispatcher-push"
                }));

            services.AddSingleton<ErrorHandlingMiddleware>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}