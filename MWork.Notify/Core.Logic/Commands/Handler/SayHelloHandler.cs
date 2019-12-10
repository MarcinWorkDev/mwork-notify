using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Logic.Commands.Command;

namespace MWork.Notify.Core.Logic.Commands.Handler
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