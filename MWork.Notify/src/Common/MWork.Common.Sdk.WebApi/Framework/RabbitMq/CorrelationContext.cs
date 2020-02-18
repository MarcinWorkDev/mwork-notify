using System;
using System.Collections.Generic;
using MWork.Common.Sdk.Abstractions.Queue;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public class CorrelationContext : ICorrelationContext
    {
        public Guid MessageId { get; set; } = Guid.Empty;
        
        public Guid UserId { get; set; } = Guid.Empty;
        public IList<string> UserScopes { get; set; } = new List<string>();
        
        public string Resource { get; set; }
        public string ResourceId { get; set; }
        
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public static CorrelationContext Initialize(Action<CorrelationContext> set)
        {
            var correlationContext = new CorrelationContext();
            set.Invoke(correlationContext);

            return correlationContext;
        }
    }
}