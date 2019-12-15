using System;

namespace MWork.Notify.Core.Domain.Models
{
    public class NotificationDispatch
    {
        public Guid EndpointId { get; set; }
        
        public string QueueName { get; set; }
        
        public string QueueMessageId { get; set; }
        
        public DateTime? DispatchedAtUtc { get; set; }

        public string DispatchError { get; set; }
        
        public bool Dispatched => DispatchedAtUtc.HasValue;

        public bool Failed => string.IsNullOrWhiteSpace(DispatchError) == false;
    }
}