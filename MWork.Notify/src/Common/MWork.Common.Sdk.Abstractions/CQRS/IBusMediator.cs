using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface IBusMediator : ICommandBus, IEventBus, IQueryBus
    {
    }
}