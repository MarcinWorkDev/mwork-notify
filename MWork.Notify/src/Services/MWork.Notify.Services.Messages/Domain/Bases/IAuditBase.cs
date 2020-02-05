using System;

namespace MWork.Notify.Services.Messages.Domain.Bases
{
    internal interface IAuditBase
    {
        DateTime CreatedAtUtc { get; set; }
        
        DateTime ModifiedAtUtc { get; set; }
        
        bool Deleted { get; set; }
    }
}