using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Plugins.AWS.Data.Models;
using MWork.Notify.Plugins.AWS.Data.Repositories.Abstractions;

namespace MWork.Notify.Plugins.AWS.Data.Repositories
{
    public class QueueMessageRepository : BaseRepository<QueueMessageEntity>, IQueueMessageRepository
    {
        public async Task<QueueMessage> Get(string id)
        {
            var entity = await base.Get(id);

            return entity.ToDomain();
        }

        public async Task<IEnumerable<QueueMessage>> GetByNotification(string notificationId, DateTime? createdFrom, DateTime? createdTo)
        {
            var entities = await base.Find(
                notificationId,
                new object[]
                {
                    createdFrom ?? DateTime.MinValue,
                    createdTo ?? DateTime.MaxValue
                },
                QueueMessageEntity.NotificationIndex,
                QueryOperator.Between
            );

            return entities.Select(x => x.ToDomain());
        }

        public async Task Save(QueueMessage notification)
        {
            var entity = notification.ToEntity();

            await base.Put(entity);
        }
    }
}