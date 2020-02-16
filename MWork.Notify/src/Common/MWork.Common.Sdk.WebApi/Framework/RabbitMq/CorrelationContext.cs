using System;
using MWork.Common.Sdk.Abstractions.Queue;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public class CorrelationContext : ICorrelationContext
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string ResourceId { get; }
        public string Name { get; }
        public string Origin { get; }
        public string Resource { get; }
        public string Culture { get; }
        public DateTime CreatedAt { get; }
    }
}