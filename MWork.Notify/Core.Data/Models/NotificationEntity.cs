using System;
using Amazon.DynamoDBv2.DataModel;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Data.Models
{
    [DynamoDBTable(nameof(NotificationEntity))]
    public class NotificationEntity
    {
        public Guid Id { get; set; }
        
        public NotificationSource Source { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public string Recipient { get; set; }
        
        public string Status { get; set; }
        
        public string DispatchError { get; set; }
        
        public DateTime? DispatchedAtUtc { get; set; }
    }
}