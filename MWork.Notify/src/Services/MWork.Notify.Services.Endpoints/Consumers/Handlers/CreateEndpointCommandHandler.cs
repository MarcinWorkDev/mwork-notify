using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MWork.Common.Sdk.Abstractions.CQRS;
using MWork.Common.Sdk.WebApi.Framework.RabbitMq;
using MWork.Notify.Services.Endpoints.Consumers.Commands;
using MWork.Notify.Services.Endpoints.Publishers.Events;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class CreateEndpointCommandHandler : AsyncRequestHandler<CreateEndpointCommand>
    {
        private readonly IBusPublisher _publisher;
        private readonly ILogger<CreateEndpointCommandHandler> _logger;

        public CreateEndpointCommandHandler(IBusPublisher publisher, ILogger<CreateEndpointCommandHandler> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        protected override async Task Handle(CreateEndpointCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Debug test");
            _logger.LogInformation("Information test");
            await _publisher.QueueEventAsync(new EndpointCreated() {EndpointName = "dasdadas"}, new CorrelationContext()
            {
                Resource = "endpoints",
                ResourceId = request.Id.ToString()
            });
        }
    }
}