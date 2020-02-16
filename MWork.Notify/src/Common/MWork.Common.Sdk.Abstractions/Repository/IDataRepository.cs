using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MWork.Common.Sdk.Abstractions.Repository.Types;

namespace MWork.Common.Sdk.Abstractions.Repository
{
    public interface IDataRepository<TEntity> where TEntity : IWithId
    {
        Task Create(TEntity entity);
        
        Task<TEntity> GetOne(Guid Id);

        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);

        Task Update(Guid Id, Action<TEntity> changes);

        Task Update(TEntity entity);
        
        Task Delete(Guid Id);
    }
}