using System;
using MediatR;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Consumers.Queries
{
    public class GetEndpointQuery : IRequest<Endpoint>
    {
        public GetEndpointQuery(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
    }
}