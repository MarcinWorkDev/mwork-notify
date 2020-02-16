using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Repositories
{
    public class EndpointMongoRepository : IEndpointRepository
    {
        private readonly ILogger<EndpointMongoRepository> _logger;
        private readonly IMongoCollection<Endpoint> _collection;

        public EndpointMongoRepository(IMongoCollection<Endpoint> collection, ILogger<EndpointMongoRepository> logger)
        {
            _logger = logger;
            _collection = collection;
        }

        public async Task<Endpoint> GetOne(Guid id)
        {
            var items = await _collection.FindAsync(x => x.Id == id);
            return items.FirstOrDefault();
        }

        public async Task<IEnumerable<Endpoint>> GetAll(Expression<Func<Endpoint, bool>> filter)
        {
            var items = await _collection.FindAsync(filter);
            return items.ToEnumerable();
        }
        
        public async Task Create(Endpoint endpoint)
        {
            endpoint.CreatedAtUtc = endpoint.ModifiedAtUtc = DateTime.UtcNow;
            await _collection.InsertOneAsync(endpoint);
        }

        public async Task Update(Guid id, Action<Endpoint> changes)
        {
            var item = await GetOne(id);
            changes.Invoke(item);
            await _collection.ReplaceOneAsync(x => x.Id == id, item);
        }
    }
}