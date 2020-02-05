using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using MWork.Notify.Common.Aws.DynamoDb;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Repositories.Models;

namespace MWork.Notify.Services.Messages.Repositories
{
    internal class MessageRepository : BaseRepository<MessageEntity>, IMessageRepository
    {
        public MessageRepository() : base(ServiceConstants.TableNamePrefix)
        {
        }
        
        public async Task<Message> Get(string id)
        {
            var notificationEntity = await base.Get(id);
            var notification = notificationEntity.ToDomain();

            return notification;
        }

        public async Task<IEnumerable<Message>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo, bool includeDeleted = false)
        {
            var notificationEntities =
                await Find(
                    userId,
                    new object[]
                    {
                        modifiedFrom,
                        modifiedTo ?? DateTime.UtcNow
                    },
                    MessageEntity.UserIndex,
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

        public async Task Save(Message message)
        {
            var notificationEntity = message.ToEntity();

            await base.Put(notificationEntity);
        }

        public async Task SoftDelete(string id)
        {
            await base.Delete(id, true);
        }
    }
}