using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Commands;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class UpdateUserEndpointCommandHandler : AsyncRequestHandler<UpdateUserEndpointCommand>
    {
        protected override Task Handle(UpdateUserEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}