using MWork.Common.Sdk.Abstractions.Queue;

namespace MWork.Notify.Services.Endpoints.Events
{
    public class EndpointCreated : IQueueEvent
    {
        public string EndpointName { get; set; }
    }
}