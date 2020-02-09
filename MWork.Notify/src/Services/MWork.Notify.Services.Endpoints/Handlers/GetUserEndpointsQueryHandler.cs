using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;
using MWork.Notify.Services.Endpoints.Queries;

namespace MWork.Notify.Services.Endpoints.Handlers
{
    public class GetUserEndpointsQueryHandler : IRequestHandler<GetUserEndpointsQuery, IEnumerable<UserEndpoint>>
    {
        public Task<IEnumerable<UserEndpoint>> Handle(GetUserEndpointsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}