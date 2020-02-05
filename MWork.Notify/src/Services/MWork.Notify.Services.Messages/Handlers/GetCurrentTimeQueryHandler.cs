using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Services.Messages.Queries;

namespace MWork.Notify.Services.Messages.Handlers
{
    public class GetCurrentTimeQueryHandler : IRequestHandler<GetCurrentTimeQuery, DateTime>
    {
        public Task<DateTime> Handle(GetCurrentTimeQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(DateTime.UtcNow);
        }
    }
}