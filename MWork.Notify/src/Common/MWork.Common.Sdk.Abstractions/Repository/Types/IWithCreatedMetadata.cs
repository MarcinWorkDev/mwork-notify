using System;

namespace MWork.Common.Sdk.Abstractions.Repository.Types
{
    public interface IWithCreatedMetadata
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}