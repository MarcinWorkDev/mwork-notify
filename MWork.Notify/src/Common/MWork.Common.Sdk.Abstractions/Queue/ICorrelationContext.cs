using System;
using System.Collections.Generic;

namespace MWork.Common.Sdk.Abstractions.Queue
{
    public interface ICorrelationContext
    {
        Guid MessageId { get; }
        
        Guid UserId { get; }
        IList<string> UserScopes { get; }
        
        string Resource { get; }
        string ResourceId { get; }
        
        DateTime CreatedAtUtc { get; }
    }
}