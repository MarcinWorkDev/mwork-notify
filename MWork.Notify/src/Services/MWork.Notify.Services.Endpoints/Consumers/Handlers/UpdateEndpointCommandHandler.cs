using System.Threading;
using System.Threading.Tasks;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Consumers.Commands;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class UpdateEndpointCommandHandler : ICommandHandler<UpdateEndpointCommand>
    {
        public Task HandleAsync(UpdateEndpointCommand command, ICorrelationContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}