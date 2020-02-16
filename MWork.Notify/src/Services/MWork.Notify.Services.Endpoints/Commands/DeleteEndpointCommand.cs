using System;
using MediatR;

namespace MWork.Notify.Services.Endpoints.Commands
{
    public class DeleteEndpointCommand : IRequest
    {
        public DeleteEndpointCommand(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
    }
}