using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Domain.Abstractions.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> Get(Guid id);

        Task<IEnumerable<Notification>> Get(Predicate<Notification> predicate = null);

        Task Save(Notification notification);

        Task Remove(Guid id);
    }
}