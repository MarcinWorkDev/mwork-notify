using System;
using Amazon.DynamoDBv2.DataModel;
using MWork.Notify.Core.Data.Models.Abstractions;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Data.Models
{
    [DynamoDBTable(nameof(NotificationEntity))]
    public class NotificationEntity : IDeleteColumn, IModifiedColumn
    {
        public const string UserIndex = nameof(NotificationEntity) + "_" + nameof(UserIndex) + "_GSI";

        [DynamoDBHashKey]
        public string Id { get; set; }
        
        public string Source { get; set; }
        
        public string SourceId { get; set; }
        
        [DynamoDBGlobalSecondaryIndexHashKey(UserIndex)]
        public string UserId { get; set; }
        
        [DynamoDBGlobalSecondaryIndexRangeKey(UserIndex)]
        public DateTime CreatedAtUtc { get; set; }
        
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public object Data { get; set; }
        
        public int Priority { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool Starred { get; set; }
        
        public bool Deleted { get; set; }
    }
}