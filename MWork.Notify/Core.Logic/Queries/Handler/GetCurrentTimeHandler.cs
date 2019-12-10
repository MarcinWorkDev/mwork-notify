using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Logic.Queries.Query;

namespace MWork.Notify.Core.Logic.Queries.Handler
{
    public class GetCurrentTimeHandler : IRequestHandler<GetCurrentTimeQuery, DateTime>
    {
        public Task<DateTime> Handle(GetCurrentTimeQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(DateTime.UtcNow);
        }
    }
}