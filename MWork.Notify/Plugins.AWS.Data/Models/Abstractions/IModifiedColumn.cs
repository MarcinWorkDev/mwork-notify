using System;

namespace MWork.Notify.Plugins.AWS.Data.Models.Abstractions
{
    internal interface IModifiedColumn
    {
        DateTime ModifiedAtUtc { get; set; }
    }
}