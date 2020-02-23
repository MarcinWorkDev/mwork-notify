using System;
using MWork.Common.Sdk.CQRS;

namespace MWork.Notify.Services.Endpoints.Consumers.Commands
{
    public class DeleteEndpointCommand : ICommand
    {
        public DeleteEndpointCommand(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
    }
}