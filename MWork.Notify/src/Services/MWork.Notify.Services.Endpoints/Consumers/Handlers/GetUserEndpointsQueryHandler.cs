using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Consumers.Queries;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class GetUserEndpointsQueryHandler : IQueryHandler<GetUserEndpointsQuery, IEnumerable<Endpoint>>
    {
        public Task<IEnumerable<Endpoint>> HandleAsync(GetUserEndpointsQuery command, ICorrelationContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}