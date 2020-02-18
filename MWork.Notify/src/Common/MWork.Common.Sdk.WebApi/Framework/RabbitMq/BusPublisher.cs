using System;
using System.Threading.Tasks;
using MWork.Common.Sdk.Abstractions.Queue;
using RawRabbit;
using RawRabbit.Enrichers.MessageContext;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context = null)
            where TCommand : IQueueCommand
            => await QueueAsync(command, context);

        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context = null)
            where TEvent : IQueueEvent
            => await QueueAsync(@event, context);

        private async Task QueueAsync<T>(T item, ICorrelationContext context = null)
            => await _busClient.PublishAsync(item, async ctx =>
            {
                if (context != null)
                {
                    ctx.UseMessageContext(context);
                }
                
                await Task.WhenAll(_busClient.DeclareExchangeAsync<T>(), _busClient.DeclareQueueAsync<T>());
                await _busClient.BindQueueAsync<T>();

                ctx.UsePublishAcknowledge();
            });
    }
}