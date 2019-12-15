using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MWork.Notify.Core.Data.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Logic;
using MWork.Notify.Plugins.AWS.Queue;
using MWork.Notify.Plugins.AWS.Queue.Models;

namespace MWork.Notify.Presentation.Api.Framework.DI
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IQueueMessageRepository, QueueMessageRepository>();
            services.AddSingleton<IUserEndpointRepository, UserEndpointRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            
            return services;
        }
        
        public static IServiceCollection RegisterQueuePublishers(this IServiceCollection services)
        {
            // Register factory
            services.AddSingleton<INotifyQueuePublisherFactory, NotifyQueuePublisherFactory>();
            
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
        
        public static IServiceCollection RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(CoreServicesConstants.Assembly);

            return services;
        }
    }
}