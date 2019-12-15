using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Logic.Commands.Command;

namespace MWork.Notify.Core.Logic.Commands.Handler
{
    public class DispatchBasicMessageHandler : INotificationHandler<DispatchBasicMessageCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationBuilder _builder;
        private readonly INotifyQueue _queue;
        
        public DispatchBasicMessageHandler(INotificationBuilder builder, INotificationRepository notificationRepository, INotifyQueue queue)
        {
            _builder = builder;
            _notificationRepository = notificationRepository;
            _queue = queue;
        }
        
        public async Task Handle(DispatchBasicMessageCommand notification, CancellationToken cancellationToken)
        {
            // Build notification
            var message = await _builder.BuildNotification(notification.Title, notification.Content, notification.Recipient);
            
            // Store notification in database
            await _notificationRepository.Save(message);
            
            // Queue notification
            await _queue.Queue(message);
        }
    }
}