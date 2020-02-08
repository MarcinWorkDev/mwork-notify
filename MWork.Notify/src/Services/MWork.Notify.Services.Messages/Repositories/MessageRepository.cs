using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MWork.Notify.Services.Messages.Domain;

namespace MWork.Notify.Services.Messages.Repositories
{
    internal class MessageRepository : IMessageRepository
    {
        private readonly IMongoCollection<Message> _collection;

        public MessageRepository(IMongoClient client)
        {
            var database = client.GetDatabase("notify");
            _collection = database.GetCollection<Message>("messages");
        }
        
        public async Task<Message> Get(string id)
        {
            var found = await _collection.FindAsync(x => x.Id == id);
            return await found.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Message>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo)
        {
            var found = await _collection.FindAsync(x => x.UserId == userId
                                                         && x.ModifiedAtUtc > modifiedFrom
                                                         && x.ModifiedAtUtc <= (modifiedTo ?? DateTime.UtcNow));

            return found.ToEnumerable();
        }

        public async Task Create(Message message)
        {
            message.CreatedAtUtc = DateTime.UtcNow;
            message.ModifiedAtUtc = message.CreatedAtUtc;
            await _collection.InsertOneAsync(message);
        }
        
        public async Task Update(Message message)
        {
            message.ModifiedAtUtc = DateTime.UtcNow;
            await _collection.ReplaceOneAsync(x => x.Id == message.Id, message);
        }

        public async Task SoftDelete(string id)
        {
            var update = Builders<Message>.Update
                .Set(x => x.ModifiedAtUtc, DateTime.UtcNow)
                .Set(x => x.Deleted, true);
            await _collection.UpdateOneAsync(x => x.Id == id, update);
        }
    }
}