using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Presentation.Api.Framework
{
    public class NotifyQueuePublisherFactory : INotifyQueuePublisherFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public NotifyQueuePublisherFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public INotifyQueuePublisher GetPublisher(DeliveryMethod method)
        {
            var services = _serviceProvider.GetServices<INotifyQueuePublisher>();

            if (services?.FirstOrDefault(x => x.DeliveryMethod == method) is { } publisher)
            {
                return publisher;
            }
            
            throw new NotSupportedException($"Publisher for delivery method: '{method}' not found!");
        }
    }
}