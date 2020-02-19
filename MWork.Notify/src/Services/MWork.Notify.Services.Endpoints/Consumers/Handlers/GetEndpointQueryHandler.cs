using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Consumers.Queries;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class GetEndpointQueryHandler : IRequestHandler<GetEndpointQuery, Endpoint>
    {
        public Task<Endpoint> Handle(GetEndpointQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}