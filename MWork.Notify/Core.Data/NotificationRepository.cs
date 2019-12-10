using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Core.Data.Models;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Data
{
    public class NotificationRepository : BaseRepository<Notification, NotificationEntity>, INotificationRepository
    {
        public Task<IEnumerable<Notification>> Get(Predicate<Notification> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}