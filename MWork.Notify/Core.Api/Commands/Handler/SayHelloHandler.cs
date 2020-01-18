using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Api.Commands.Command;

namespace MWork.Notify.Core.Api.Commands.Handler
{
    public class SayHelloHandler : INotificationHandler<SayHelloCommand>
    {
        public Task Handle(SayHelloCommand notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Message);

            return Task.CompletedTask;
        }
    }
}