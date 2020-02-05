using System;

namespace MWork.Notify.Common.Aws.DynamoDb
{
    public interface IModifiedColumn
    {
        DateTime ModifiedAtUtc { get; set; }
    }
}