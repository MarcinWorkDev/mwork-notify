using MWork.Notify.Services.Messages.Domain.Enums;

namespace MWork.Notify.Services.Messages.Services.Abstractions
{
    public interface INotificationPublisherFactory
    {
        INotificationPublisher GetPublisher(NotificationChannel channel);
    }
}