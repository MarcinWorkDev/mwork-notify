using System;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Commands
{
    public class CreateEndpointCommand : IRequest
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public EndpointType Type { get; set; }
        
        public string Endpoint { get; set; }
        
        public string Name { get; set; }
        
        public ApplicationInfo Application { get; set; }
        
        public DeviceInfo Device { get; set; }
    }
}