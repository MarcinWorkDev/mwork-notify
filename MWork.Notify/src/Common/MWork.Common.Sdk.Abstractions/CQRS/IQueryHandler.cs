using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface IQueryHandler<in TQuery, TOutput> where TQuery : IQuery<TOutput>
    {
        Task<TOutput> HandleAsync(TQuery command, ICorrelationContext context, CancellationToken cancellationToken);
    }
}