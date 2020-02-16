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

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) 
            where TCommand : IQueueCommand
            => await _busClient.PublishAsync(command, ctx => ctx.UseMessageContext(context));

        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) 
            where TEvent : IQueueEvent
            => await _busClient.PublishAsync(@event, ctx => ctx.UseMessageContext(context));
    }
}