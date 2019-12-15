using System;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Extensions;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models
{
    public class QueueMessage
    {
        public string Id { get; set; }
        
        public Notification Notification { get; set; }
        
        public DeliveryMethod DeliveryMethod { get; set; }
        
        public string QueueName { get; set; }
        
        public string QueueMessageId { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime? PublishedAtUtc { get; set; }
        
        public string PublishError { get; set; }
        
        public IEnumerable<UserEndpoint> Endpoints { get; set; }
        
        public bool Published => PublishedAtUtc.HasValue;

        public bool Failed => PublishError.IsPresent();
    }
}