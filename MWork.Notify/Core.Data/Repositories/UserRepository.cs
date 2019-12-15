using System.Threading.Tasks;
using MWork.Notify.Core.Data.Models;
using MWork.Notify.Core.Data.Repositories.Abstractions;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public async Task<User> Get(string id)
        {
            var entity = await base.Get(id);

            return entity.ToDomain();
        }

        public async Task Save(User user)
        {
            var entity = user.ToEntity();

            await base.Put(entity);
        }

        public async Task SoftDelete(string userId)
        {
            await base.Delete(userId, true);
        }
    }
}