using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Common.Sdk.Abstractions.Queue;
using MWork.Notify.Services.Endpoints.Commands;
using MWork.Notify.Services.Endpoints.Events;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class CreateEndpointCommandHandler : AsyncRequestHandler<CreateEndpointCommand>
    {
        private readonly IBusPublisher _publisher;

        public CreateEndpointCommandHandler(IBusPublisher publisher)
        {
            _publisher = publisher;
        }

        protected override async Task Handle(CreateEndpointCommand request, CancellationToken cancellationToken)
        {
            await _publisher.PublishAsync(new EndpointCreated(), null);
        }
    }
}