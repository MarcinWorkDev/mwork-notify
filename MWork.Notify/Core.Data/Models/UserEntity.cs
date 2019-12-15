using System;
using Amazon.DynamoDBv2.DataModel;
using MWork.Notify.Core.Data.Models.Abstractions;

namespace MWork.Notify.Core.Data.Models
{
    [DynamoDBTable(nameof(UserEntity))]
    public class UserEntity : IDeleteColumn, IModifiedColumn
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public string ExternalUserId { get; set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public UserPreferencesEntity Preferences { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool Deleted { get; set; }
    }
}