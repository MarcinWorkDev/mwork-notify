using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Commands;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class DeleteUserEndpointCommandHandler : AsyncRequestHandler<DeleteUserEndpointCommand>
    {
        protected override Task Handle(DeleteUserEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}