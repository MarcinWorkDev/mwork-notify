using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MWork.Notify.Core.Domain.Abstractions.Repositories
{
    public interface IQueueMessageRepository
    {
        Task<QueueMessage> Get(string id);

        Task<IEnumerable<QueueMessage>> GetByNotification(string notificationId, DateTime? createdFrom, DateTime? createdTo);
        
        Task Save(QueueMessage notification);
    }
}