using System;

namespace MWork.Notify.Services.Endpoints.Domain
{
    public class UserEndpoint
    {
        public string Id { get; set; }
        
        public string UserId { get; set; }
        
        public EndpointType Type { get; set; }
        
        public string Endpoint { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public int FailedCounter { get; set; }
        
        public EndpointStatus Status { get; set; }
        
        public ApplicationInfo Application { get; set; }
        
        public DeviceInfo Device { get; set; }
    }
}