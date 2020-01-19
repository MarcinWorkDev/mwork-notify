using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Api.Queries;

namespace MWork.Notify.Core.Api.Handlers
{
    public class GetCurrentTimeQueryHandler : IRequestHandler<GetCurrentTimeQuery, DateTime>
    {
        public Task<DateTime> Handle(GetCurrentTimeQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(DateTime.UtcNow);
        }
    }
}