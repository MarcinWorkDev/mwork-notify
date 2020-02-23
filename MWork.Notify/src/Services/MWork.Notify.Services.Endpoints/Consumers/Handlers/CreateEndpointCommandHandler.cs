using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Consumers.Commands;
using MWork.Notify.Services.Endpoints.Publishers.Events;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class CreateEndpointCommandHandler : ICommandHandler<CreateEndpointCommand>
    {
        private readonly IBusPublisher _publisher;
        private readonly ILogger<CreateEndpointCommandHandler> _logger;

        public CreateEndpointCommandHandler(IBusPublisher publisher, ILogger<CreateEndpointCommandHandler> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        public async Task HandleAsync(CreateEndpointCommand command, ICorrelationContext context, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Debug test");
            _logger.LogInformation("Information test");
            await _publisher.PublishAsync(new EndpointCreated() {EndpointName = "dasdadas"}, new CorrelationContext()
            {
                Resource = "endpoints",
                ResourceId = request.Id.ToString()
            });
        }
    }
}