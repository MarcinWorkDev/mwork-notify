using System;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.Queue
{
    public interface IBusPublisher
    {
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : IQueueCommand;
        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IQueueEvent;
    }
}