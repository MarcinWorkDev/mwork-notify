using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Api.Notifications;

namespace MWork.Notify.Core.Api.Handlers
{
    public class SayHelloNotificationHandler : INotificationHandler<SayHelloNotification>
    {
        public Task Handle(SayHelloNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Message);

            return Task.CompletedTask;
        }
    }
}