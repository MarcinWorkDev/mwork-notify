using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWork.Notify.Services.Messages.Domain;

namespace MWork.Notify.Services.Messages.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> Get(string id);

        Task<IEnumerable<Message>> GetByUser(string userId, DateTime modifiedFrom, DateTime? modifiedTo, bool includeDeleted = false);
        
        Task Save(Message message);

        Task SoftDelete(string id);
    }
}