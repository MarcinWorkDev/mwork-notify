using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Endpoints.Consumers.Queries;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Handlers
{
    public class GetUserEndpointsQueryHandler : IRequestHandler<GetUserEndpointsQuery, IEnumerable<Endpoint>>
    {
        public Task<IEnumerable<Endpoint>> Handle(GetUserEndpointsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}