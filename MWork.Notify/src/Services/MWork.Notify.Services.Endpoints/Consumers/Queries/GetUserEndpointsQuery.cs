using System;
using System.Collections.Generic;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Queries
{
    public class GetUserEndpointsQuery : IRequest<IEnumerable<Endpoint>>
    {
        public GetUserEndpointsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}