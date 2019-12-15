using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;
using MWork.Notify.Plugins.AWS.Queue.Models;

namespace MWork.Notify.Plugins.AWS.Queue
{
    public class NotifyQueuePushPublisher : NotifyQueuePublisherBase<PushMessage>
    {
        public NotifyQueuePushPublisher(PublisherOptions queueOptions) 
            : base(DeliveryMethod.Push, queueOptions)
        {
        }

        protected override Task<PushMessage> PrepareMessage(Notification notification, IList<UserEndpoint> endpoints)
        {
            if (notification.Data?.Count > 9)
            {
                throw new ArgumentException("Too many items in Data object!");
            }
            
            var message = new PushMessage()
            {
                Title = notification.Title,
                Body = notification.Body,
                Tokens = endpoints.Select(x => x.Endpoint).ToArray(),
                Data = notification.Data
            };
            
            return Task.FromResult(message);
        }
    }
}