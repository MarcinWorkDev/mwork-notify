using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface IQueryBus
    {
        /// <summary>
        /// Query data (and handle locally)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TQuery"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<TOutput> QueryAsync<TQuery, TOutput>(TQuery query, ICorrelationContext context, CancellationToken cancellationToken)
            where TQuery : IQuery<TOutput>;
    }
}