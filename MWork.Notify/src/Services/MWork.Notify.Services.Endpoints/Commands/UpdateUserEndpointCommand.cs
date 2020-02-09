using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Commands
{
    public class UpdateUserEndpointCommand : IRequest
    {
        public UpdateUserEndpointCommand(string id, JsonPatchDocument<UserEndpoint> operations)
        {
            Id = id;
            Operations = operations;
        }

        public string Id { get; set; }
        
        public JsonPatchDocument<UserEndpoint> Operations { get; set; }
    }
}