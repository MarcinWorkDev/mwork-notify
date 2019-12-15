using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using MWork.Notify.Core.Data.Models;
using MWork.Notify.Core.Data.Repositories.Abstractions;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Data.Repositories
{
    public class UserEndpointRepository : BaseRepository<UserEndpointEntity>, IUserEndpointRepository
    {
        public async Task<UserEndpoint> Get(string id)
        {
            var notificationEntity = await base.Get(id);
            var notification = notificationEntity.ToDomain();

            return notification;
        }

        public async Task<IEnumerable<UserEndpoint>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo, bool includeDeleted = false)
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

        public async Task Save(UserEndpoint notification)
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