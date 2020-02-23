using System;
using Microsoft.AspNetCore.JsonPatch;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Commands
{
    public class UpdateEndpointCommand : ICommand
    {
        public UpdateEndpointCommand(Guid id, JsonPatchDocument<Endpoint> operations)
        {
            Id = id;
            Operations = operations;
        }

        public Guid Id { get; }
        
        public JsonPatchDocument<Endpoint> Operations { get; }
    }
}