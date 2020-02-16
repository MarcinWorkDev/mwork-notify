using System;
using System.Threading;
using System.Threading.Tasks;
using MWork.Notify.Services.Endpoints.Handlers;
using MWork.Notify.Services.Endpoints.Queries;
using Xunit;

namespace MWork.Notify.Services.Endpoints.Tests.Handlers
{
    public class GetEndpointQueryHandlerTests
    {
        [Fact]
        public async Task GetEndpoint_Exists_Return_Endpoint()
        {
            var handler = new GetEndpointQueryHandler();
            var request = new GetEndpointQuery(Guid.NewGuid().ToString("D"));

            var actual = await handler.Handle(request, CancellationToken.None);
            
            Assert.Equal(request.Id, actual.Id);
        }
        
        [Fact]
        public async Task GetEndpoint_NotExists_Throws_NotFound()
        {
            var handler = new GetEndpointQueryHandler();
            var request = new GetEndpointQuery(Guid.NewGuid().ToString("D"));

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, CancellationToken.None));
        }
        
        [Fact]
        public async Task GetEndpoint_MissingId_Throws_ArgumentNullException()
        {
            var handler = new GetEndpointQueryHandler();
            var request = new GetEndpointQuery(null);

            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(request, CancellationToken.None));
        }
    }
}