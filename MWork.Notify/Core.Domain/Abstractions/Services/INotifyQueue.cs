using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Domain.Abstractions.Services
{
    public interface INotifyQueue
    {
        /// <summary>
        /// Queue new notification
        /// </summary>
        /// <param name="notification">Notification item</param>
        /// <returns></returns>
        Task Queue(Notification notification);
        
        /// <summary>
        /// Queue new notifications
        /// </summary>
        /// <param name="notifications">List of notification items</param>
        /// <returns></returns>
        Task Queue(IEnumerable<Notification> notifications);
    }
}