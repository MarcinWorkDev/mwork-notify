using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Abstractions.Services
{
    public interface INotifyQueuePublisher
    {
        DeliveryMethod DeliveryMethod { get; }
        
        /// <summary>
        /// Push to queue new notification
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        Task<QueueMessage> Queue(Notification notification, params UserEndpoint[] endpoints);
    }
}