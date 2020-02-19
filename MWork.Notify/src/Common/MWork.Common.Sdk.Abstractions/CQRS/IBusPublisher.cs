using System.Threading;
using System.Threading.Tasks;

namespace MWork.Common.Sdk.Abstractions.CQRS
{
    public interface IBusPublisher : ICommandBus, IEventBus
    {
    }
}