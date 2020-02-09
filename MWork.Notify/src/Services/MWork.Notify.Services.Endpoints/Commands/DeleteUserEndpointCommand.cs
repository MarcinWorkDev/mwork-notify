using MediatR;

namespace MWork.Notify.Services.Endpoints.Commands
{
    public class DeleteUserEndpointCommand : IRequest
    {
        public DeleteUserEndpointCommand(string id)
        {
            Id = id;
        }
        
        public string Id { get; set; }
    }
}