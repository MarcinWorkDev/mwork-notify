using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Repositories
{
    public interface IEndpointRepository
    {
        Task<Endpoint> GetOne(Guid id);

        Task<IEnumerable<Endpoint>> GetAll(Expression<Func<Endpoint, bool>> filter);
        
        Task Create(Endpoint endpoint);
        
        Task Update(Guid id, Action<Endpoint> changes);
    }
}