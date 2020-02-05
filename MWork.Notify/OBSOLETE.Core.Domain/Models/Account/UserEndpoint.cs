using System;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models.Account
{
    public class UserEndpoint
    {
        public string Id { get; set; }
        
        public string UserId { get; set; }
        
        public DeliveryMethod DeliveryMethod { get; set; }
        
        public string Name { get; set; }
        
        public string Endpoint { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool IsValid { get; set; }
        
        public bool IsActive { get; set; }
        
        public UserDeviceInfo Device { get; set; }
        
        public bool Deleted { get; set; }
    }
}