using System.Threading.Tasks;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Domain.Abstractions.Services
{
    public interface INotificationDispatcher
    {
        Task Dispatch(Notification notification);
    }
}