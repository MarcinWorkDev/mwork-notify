using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Consumers.Commands;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class UpdateEndpointCommandHandler : AsyncRequestHandler<UpdateEndpointCommand>
    {
        protected override Task Handle(UpdateEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}