using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Abstractions.Services
{
    public interface INotifyQueuePublisherFactory
    {
        INotifyQueuePublisher GetPublisher(DeliveryMethod method);
    }
}