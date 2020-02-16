using System;
using MWork.Common.Sdk.Abstractions.Repository.Types;

namespace MWork.Notify.Services.Endpoints.Domain
{
    public class Endpoint : IWithId, IWithCreatedMetadata, IWithModifiedMetadata
    {
        public Guid Id { get; set; }
        
        public string UserId { get; set; }
        
        public EndpointType Type { get; set; }

        public string Name { get; set; }
        
        public string Value { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAtUtc { get; set; }
        
        public int FailedCounter { get; set; }
        
        public EndpointStatus Status { get; set; }
        
        public ApplicationInfo Application { get; set; }
        
        public DeviceInfo Device { get; set; }
    }
}