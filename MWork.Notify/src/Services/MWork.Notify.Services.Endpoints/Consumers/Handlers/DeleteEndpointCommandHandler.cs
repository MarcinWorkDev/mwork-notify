using System.Threading;
using System.Threading.Tasks;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Consumers.Commands;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class DeleteEndpointCommandHandler : ICommandHandler<DeleteEndpointCommand>
    {
        public Task HandleAsync(DeleteEndpointCommand command, ICorrelationContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}