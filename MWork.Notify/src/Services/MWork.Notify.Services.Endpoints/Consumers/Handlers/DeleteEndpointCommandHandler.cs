using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Consumers.Commands;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class DeleteEndpointCommandHandler : AsyncRequestHandler<DeleteEndpointCommand>
    {
        protected override Task Handle(DeleteEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}