using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Domain.Abstractions.Services
{
    public interface INotificationBuilder
    {
        Task<Notification> BuildNotification(NotificationDefinition definition, dynamic data, string recipient);

        Task<Notification> BuildNotification(string title, string content, string recipient);
    }
}