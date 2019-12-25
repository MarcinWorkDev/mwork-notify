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
    public class NotificationRepository : BaseRepository<NotificationEntity>, INotificationRepository
    {
        public async Task<Notification> Get(string id)
        {
            var notificationEntity = await base.Get(id);
            var notification = notificationEntity.ToDomain();

            return notification;
        }

        public async Task<IEnumerable<Notification>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo, bool includeDeleted = false)
        {
            var notificationEntities =
                await Find(
                    userId,
                    new object[]
                    {
                        modifiedFrom,
                        modifiedTo ?? DateTime.UtcNow
                    },
                    NotificationEntity.UserIndex,
                    QueryOperator.Between);

            var notifications = notificationEntities
                .Select(x => x.ToDomain())
                .ToList();

            if (includeDeleted == false)
            {
                notifications.RemoveAll(x => x.Deleted);
            }
            
            return notifications;
        }

        public async Task Save(Notification notification)
        {
            var notificationEntity = notification.ToEntity();

            await base.Put(notificationEntity);
        }

        public async Task SoftDelete(string id)
        {
            await base.Delete(id, true);
        }
    }
}