using MWork.Notify.Services.Endpoints.Handlers;
using Xunit;

namespace MWork.Notify.Services.Endpoints.Tests.Handlers
{
    public class CreateEndpointCommandHandlerTests
    {
        [Fact]
        public void Create_Endpoint_Valid_Request()
        {
            var handler = new CreateEndpointCommandHandler();
        }
    }
}