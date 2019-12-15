using System;
using MWork.Notify.Core.Data.Models.Abstractions;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Data.Models
{
    public class UserEntityEndpoint
    {
        public string Id { get; set; }
        
        public int DeliveryMethod { get; set; }
        
        public string Name { get; set; }
        
        public string Endpoint { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool IsValid { get; set; }
        
        public bool IsActive { get; set; }
        
        public UserEntityEndpointDeviceInfo Device { get; set; }
    }
}