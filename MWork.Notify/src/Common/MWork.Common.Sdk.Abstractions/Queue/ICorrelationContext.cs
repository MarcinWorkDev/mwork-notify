using System;

namespace MWork.Common.Sdk.Abstractions.Queue
{
    public interface ICorrelationContext
    {
        Guid Id { get; }
        Guid UserId { get; }
        string ResourceId { get; }
        string Name { get; }
        string Origin { get; }
        string Resource { get; }
        string Culture { get; }
        DateTime CreatedAt { get; }
    }
}