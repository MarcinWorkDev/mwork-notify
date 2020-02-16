using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.Queue
{
    public interface IQueueCommandHandler<in TCommand> where TCommand : IQueueCommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}