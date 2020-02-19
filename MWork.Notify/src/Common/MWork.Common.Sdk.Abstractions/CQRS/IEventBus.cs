using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface IEventBus
    {
        /// <summary>
        /// Publish event
        /// </summary>
        /// <param name="event"></param>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context, CancellationToken cancellationToken)
            where TEvent : IEvent;
    }
}