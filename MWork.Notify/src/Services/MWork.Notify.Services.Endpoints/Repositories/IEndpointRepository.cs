using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Repositories
{
    public interface IEndpointRepository
    {
        Task<UserEndpoint> Get(string id);

        Task<IEnumerable<UserEndpoint>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo);
        
        Task Create(UserEndpoint endpoint);
        
        Task Update(UserEndpoint endpoint);

        Task Delete(string id);
    }
}