using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Commands;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class CreateUserEndpointCommandHandler : AsyncRequestHandler<CreateUserEndpointCommand>
    {
        protected override Task Handle(CreateUserEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}