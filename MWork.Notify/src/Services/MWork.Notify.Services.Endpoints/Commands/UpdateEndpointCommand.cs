using System;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Commands
{
    public class UpdateEndpointCommand : IRequest
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