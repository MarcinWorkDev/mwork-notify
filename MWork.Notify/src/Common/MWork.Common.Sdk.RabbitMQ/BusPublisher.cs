using System.Threading;
using System.Threading.Tasks;
using RawRabbit;
using RawRabbit.Enrichers.MessageContext;

namespace MWork.Common.Sdk.RabbitMQ
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context = null, CancellationToken cancellationToken = default)
            where TCommand : ICommand
            => await QueueAsync(command, context, cancellationToken);

        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context = null, CancellationToken cancellationToken = default)
            where TEvent : IEvent
            => await QueueAsync(@event, context, cancellationToken);

        private async Task QueueAsync<T>(T item, ICorrelationContext context = null, CancellationToken cancellationToken = default)
            => await _busClient.PublishAsync(item, async ctx =>
            {
                if (context != null)
                {
                    ctx.UseMessageContext(context);
                }
                
                await Task.WhenAll(_busClient.DeclareExchangeAsync<T>(ct: cancellationToken), _busClient.DeclareQueueAsync<T>(ct: cancellationToken));
                await _busClient.BindQueueAsync<T>(ct: cancellationToken);

                ctx.UsePublishAcknowledge();
            }, token: cancellationToken);
    }
}