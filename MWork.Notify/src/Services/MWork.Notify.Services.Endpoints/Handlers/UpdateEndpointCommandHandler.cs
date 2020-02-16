using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Commands;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class UpdateEndpointCommandHandler : AsyncRequestHandler<UpdateEndpointCommand>
    {
        protected override Task Handle(UpdateEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}