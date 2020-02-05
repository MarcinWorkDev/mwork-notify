using System;
using Amazon.DynamoDBv2.DataModel;
using MWork.Notify.Plugins.AWS.Data.Models.Abstractions;

namespace MWork.Notify.Plugins.AWS.Data.Models
{
    [DynamoDBTable(nameof(UserEndpointEntity))]
    public class UserEndpointEntity : IDeleteColumn, IModifiedColumn
    {
        public const string UserIndex = nameof(UserIndex) + "_GSI";
        
        [DynamoDBHashKey]
        public string Id { get; set; }
        
        [DynamoDBGlobalSecondaryIndexHashKey(UserIndex)]
        public string UserId { get; set; }
        
        public int DeliveryMethod { get; set; }
        
        public string Name { get; set; }
        
        public string Endpoint { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        [DynamoDBGlobalSecondaryIndexRangeKey(UserIndex)]
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool IsValid { get; set; }
        
        public bool IsActive { get; set; }
        
        public UserDeviceInfoEntity Device { get; set; }
        
        public bool Deleted { get; set; }
    }
}