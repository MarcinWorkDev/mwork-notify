using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MWork.Notify.Common.Api.Runtime;
using MWork.Notify.Services.Messages.Repositories;
using MWork.Notify.Services.Messages.Services;
using MWork.Notify.Services.Messages.Services.Abstractions;
using MWork.Notify.Services.Messages.Services.Models;

namespace MWork.Notify.Services.Messages
{
    public class Program
    {
        public static void Main(string[] args) => MWorkNotifyRuntime<Startup>.Run(args);
    }
    
    public class Startup : MWorkNotifyStartup
    {
        public Startup(IConfiguration configuration) : base(configuration, true)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            
            services.AddSingleton<IMessageRepository, MessageRepository>();
            
            DataMapper.ValidateConfiguration();
            
            // Register publishers
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
        }
    }
}