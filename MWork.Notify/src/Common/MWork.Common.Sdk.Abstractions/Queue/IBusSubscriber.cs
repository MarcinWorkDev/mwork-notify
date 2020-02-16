namespace MWork.Common.Sdk.Abstractions.Queue
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string exchangeName = null) where TCommand : IQueueCommand;
        IBusSubscriber SubscribeEvent<TEvent>(string exchangeName = null) where TEvent : IQueueEvent;
    }
}