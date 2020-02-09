using System;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Commands
{
    public class CreateUserEndpointCommand : IRequest
    {
        public string Id { get; set; }
        
        public string UserId { get; set; }
        
        public EndpointType Type { get; set; }
        
        public string Endpoint { get; set; }
        
        public string Name { get; set; }
        
        public ApplicationInfo Application { get; set; }
        
        public DeviceInfo Device { get; set; }
    }
}