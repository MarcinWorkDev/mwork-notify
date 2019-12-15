using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace MWork.Notify.Core.Data.Models
{
    [DynamoDBTable(nameof(QueueMessageEntity))]
    public class QueueMessageEntity
    {
        public const string NotificationIndex = nameof(NotificationIndex) + "_GSI";

        [DynamoDBHashKey]
        public string Id { get; set; }
        
        [DynamoDBGlobalSecondaryIndexHashKey(NotificationIndex)]
        public string NotificationId { get; set; }
        
        public int DeliveryMethod { get; set; }
        
        public string QueueName { get; set; }
        
        public string QueueMessageId { get; set; }
        
        [DynamoDBGlobalSecondaryIndexRangeKey(NotificationIndex)]
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime? PublishedAtUtc { get; set; }
        
        public string PublishError { get; set; }
        
        public IEnumerable<string> Endpoints { get; set; }
    }
}