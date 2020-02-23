using System.Threading;

namespace MWork.Common.Sdk.RabbitMQ
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string exchangeName = null, string queueName = null, CancellationToken cancellationToken = default) 
            where TCommand : ICommand;
        
        IBusSubscriber SubscribeEvent<TEvent>(string exchangeName = null, string queueName = null, CancellationToken cancellationToken = default) 
            where TEvent : IEvent;
    }
}