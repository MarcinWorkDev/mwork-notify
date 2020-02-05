using System;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Plugins.AWS.Queue.Models
{
    public class QueueMessage
    {
        public string Id { get; set; }
        
        public string NotificationId { get; set; }
        
        public DeliveryMethod DeliveryMethod { get; set; }
        
        public string QueueName { get; set; }
        
        public string QueueMessageId { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime? PublishedAtUtc { get; set; }
        
        public string PublishError { get; set; }
        
        public IList<string> Endpoints { get; set; }
    }
}