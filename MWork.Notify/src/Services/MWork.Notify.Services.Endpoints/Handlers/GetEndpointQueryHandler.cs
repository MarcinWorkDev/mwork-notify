using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;
using MWork.Notify.Services.Endpoints.Queries;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class GetEndpointQueryHandler : IRequestHandler<GetEndpointQuery, Endpoint>
    {
        public Task<Endpoint> Handle(GetEndpointQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}