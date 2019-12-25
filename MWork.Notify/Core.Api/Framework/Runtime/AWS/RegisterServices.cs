using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Plugins.AWS.Data;
using MWork.Notify.Plugins.AWS.Data.Repositories;
using MWork.Notify.Plugins.AWS.Queue;
using MWork.Notify.Plugins.AWS.Queue.Models;

namespace MWork.Notify.Core.Api.Framework.Runtime.AWS
{
    internal static class RegisterServices
    {
        public static IServiceCollection RegisterAwsPlugins(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories();
            services.RegisterQueuePublishers();

            return services;
        }
        
        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IQueueMessageRepository, QueueMessageRepository>();
            services.AddSingleton<IUserEndpointRepository, UserEndpointRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            
            CoreDataConstants.ValidateDataMapper();
            
            return services;
        }
        
        private static IServiceCollection RegisterQueuePublishers(this IServiceCollection services)
        {
            // Register publishers
            services.AddScoped<INotifyQueuePublisher, NotifyQueueEmailPublisher>(sp
                => new NotifyQueueEmailPublisher(new PublisherOptions()
                {
                    QueueName = "mwork-notify-dispatcher-email"
                }));
            services.AddScoped<INotifyQueuePublisher, NotifyQueuePushPublisher>(sp
                => new NotifyQueuePushPublisher(new PublisherOptions()
                {
                    QueueName = "mwork-notify-dispatcher-push"
                }));
            
            return services;
        }
    }
}