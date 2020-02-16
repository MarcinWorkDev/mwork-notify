using System;

namespace MWork.Common.Sdk.Abstractions.Repository.Types
{
    public interface IWithId
    {
        public Guid Id { get; set; }
    }
}