using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;
using MWork.Notify.Plugins.AWS.Queue.Models;

namespace MWork.Notify.Plugins.AWS.Queue
{
    public class NotifyQueueEmailPublisher : NotifyQueuePublisherBase<EmailMessage>
    {
        public NotifyQueueEmailPublisher(PublisherOptions queueOptions) 
            : base(DeliveryMethod.Email, queueOptions)
        {
        }

        protected override Task<EmailMessage> PrepareMessage(Notification notification, IList<UserEndpoint> endpoints)
        {
            var message = new EmailMessage()
            {
                Subject = notification.Title,
                Body = notification.Body,
                Priority = notification.Priority.ToString().ToLowerInvariant(),
                To = string.Join(',', endpoints.Select(x => x.Endpoint))
            };

            return Task.FromResult(message);
        }
    }
}