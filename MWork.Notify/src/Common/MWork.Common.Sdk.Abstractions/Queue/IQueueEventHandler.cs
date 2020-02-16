using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.Queue
{
    public interface IQueueEventHandler<in TEvent> where TEvent : IQueueEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}