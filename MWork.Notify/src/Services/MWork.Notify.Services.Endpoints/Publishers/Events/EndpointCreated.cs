using MWork.Common.Sdk.CQRS;

namespace MWork.Notify.Services.Endpoints.Publishers.Events
{
    public class EndpointCreated : IEvent
    {
        public string EndpointName { get; set; }
    }
}