using System.Threading;
using System.Threading.Tasks;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Consumers.Queries;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class GetEndpointQueryHandler : IQueryHandler<GetEndpointQuery, Endpoint>
    {
        public Task<Endpoint> HandleAsync(GetEndpointQuery command, ICorrelationContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}