using System.Threading;
using MWork.Common.Sdk.Abstractions.CQRS;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string exchangeName = null, string queueName = null, CancellationToken cancellationToken = default) 
            where TCommand : ICommand;
        
        IBusSubscriber SubscribeEvent<TEvent>(string exchangeName = null, string queueName = null, CancellationToken cancellationToken = default) 
            where TEvent : IEvent;
    }
}