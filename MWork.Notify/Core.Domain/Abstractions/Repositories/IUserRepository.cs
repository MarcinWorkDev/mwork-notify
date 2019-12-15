using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string id);

        Task Save(User user);

        Task SoftDelete(string userId);
    }
}