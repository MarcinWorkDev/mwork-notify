using System;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models.Account
{
    public class UserEndpoint
    {
        public Guid Id { get; set; }
        
        public EndpointType Type { get; set; }
        
        public string Name { get; set; }
        
        public string Endpoint { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime? LastUsedAtUtc { get; set; }
        
        public bool IsActive { get; set; }
        
        public UserDeviceInfo Device { get; set; }
    }
}