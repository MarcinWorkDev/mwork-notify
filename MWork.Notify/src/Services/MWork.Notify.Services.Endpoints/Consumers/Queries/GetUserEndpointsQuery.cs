using System;
using System.Collections.Generic;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Queries
{
    public class GetUserEndpointsQuery : IQuery<IEnumerable<Endpoint>>
    {
        public GetUserEndpointsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}