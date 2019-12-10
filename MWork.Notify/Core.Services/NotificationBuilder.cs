using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Abstractions;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Services
{
    public class NotificationBuilder : INotificationBuilder
    {
        private readonly INotificationRepository _notificationRepository;
        
        public NotificationBuilder(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task<Notification> BuildNotification(NotificationDefinition definition, dynamic data, string recipient)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Notification> BuildNotification(string title, string content, string recipient)
        {
            var notification = new Notification(title, content, recipient);

            await _notificationRepository.Save(notification);

            return notification;
        }
    }
}