using System;
using MWork.Common.Sdk.CQRS;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Queries
{
    public class GetEndpointQuery : IQuery<Endpoint>
    {
        public GetEndpointQuery(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
    }
}