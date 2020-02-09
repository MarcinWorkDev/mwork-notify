using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;
using MWork.Notify.Services.Endpoints.Queries;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class GetUserEndpointQueryHandler : IRequestHandler<GetUserEndpointQuery, UserEndpoint>
    {
        public Task<UserEndpoint> Handle(GetUserEndpointQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}