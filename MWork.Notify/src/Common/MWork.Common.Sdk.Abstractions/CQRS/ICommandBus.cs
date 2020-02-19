using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface ICommandBus
    {
        /// <summary>
        /// Send command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TCommand"></typeparam>
        /// <returns></returns>
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context, CancellationToken cancellationToken)
            where TCommand : ICommand;
    }
}