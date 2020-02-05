using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MWork.Notify.Services.Messages.Domain.Enums;
using MWork.Notify.Services.Messages.Services.Abstractions;

namespace MWork.Notify.Services.Messages.Services
{
    public class NotificationPublisherFactory : INotificationPublisherFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationPublisherFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public INotificationPublisher GetPublisher(NotificationChannel channel)
        {
            var services = _serviceProvider.GetServices<INotificationPublisher>();

            if (services?.FirstOrDefault(x => x.NotificationChannel == channel) is { } publisher)
            {
                return publisher;
            }
            
            throw new NotSupportedException($"Publisher for notification channel: '{channel}' not found!");
        }
    }
}