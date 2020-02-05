using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using MWork.Notify.Common.Aws.DynamoDb;

namespace MWork.Notify.Services.Messages.Repositories.Models
{
    [DynamoDBTable(nameof(MessageEntity))]
    internal class MessageEntity : IDeleteColumn, IModifiedColumn
    {
        public const string UserIndex = nameof(UserIndex) + "_GSI";

        [DynamoDBHashKey]
        public string Id { get; set; }
        
        [DynamoDBGlobalSecondaryIndexHashKey(UserIndex)]
        public string UserId { get; set; }
        
        public string Source { get; set; }
        
        public string SourceId { get; set; }
        
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public Dictionary<string, string> Data { get; set; }
        
        public int Priority { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }

        [DynamoDBGlobalSecondaryIndexRangeKey(UserIndex)]
        public DateTime ModifiedAtUtc { get; set; }
        
        public DateTime? ReadAtUtc { get; set; }
        
        public bool Starred { get; set; }
        
        public bool Deleted { get; set; }
    }
}