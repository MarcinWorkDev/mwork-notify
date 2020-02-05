using System.Threading.Tasks;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Domain.Enums;

namespace MWork.Notify.Services.Messages.Services.Abstractions
{
    public interface INotificationPublisher
    {
        NotificationChannel NotificationChannel { get; }
        
        /// <summary>
        /// Push to queue new notification
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Queue(Message message);
    }
}