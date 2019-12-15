using System;

namespace MWork.Notify.Core.Data.Models.Abstractions
{
    public interface IModifiedColumn
    {
        public DateTime ModifiedAtUtc { get; set; }
    }
}