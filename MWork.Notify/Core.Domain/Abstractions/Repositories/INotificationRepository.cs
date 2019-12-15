using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Domain.Abstractions.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> Get(string id);

        Task<IEnumerable<Notification>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo);
        
        Task Save(Notification notification);

        Task SoftDelete(string id);
    }
}