using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context, CancellationToken cancellationToken);
    }
}