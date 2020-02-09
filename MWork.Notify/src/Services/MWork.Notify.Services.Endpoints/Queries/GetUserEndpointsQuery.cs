using System.Collections.Generic;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Queries
{
    public class GetUserEndpointsQuery : IRequest<IEnumerable<UserEndpoint>>
    {
        public GetUserEndpointsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}