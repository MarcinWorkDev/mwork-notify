using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Domain.Abstractions.Repositories
{
    public interface IUserEndpointRepository
    {
        Task<UserEndpoint> Get(string id);

        Task<IEnumerable<UserEndpoint>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo, bool includeDeleted = false);
        
        Task Save(UserEndpoint notification);

        Task SoftDelete(string id);
    }
}