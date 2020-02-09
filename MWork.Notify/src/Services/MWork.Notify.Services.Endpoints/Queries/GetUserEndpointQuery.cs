using MediatR;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Queries
{
    public class GetUserEndpointQuery : IRequest<UserEndpoint>
    {
        public GetUserEndpointQuery(string id)
        {
            Id = id;
        }
        
        public string Id { get; set; }
    }
}