using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Domain.Abstractions;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Logic.Commands.Command;

namespace MWork.Notify.Core.Logic.Commands.Handler
{
    public class DispatchBasicMessageHandler : INotificationHandler<DispatchBasicMessageCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationBuilder _builder;
        private readonly INotificationDispatcher _dispatcher;
        
        public DispatchBasicMessageHandler(INotificationDispatcher dispatcher, INotificationBuilder builder, INotificationRepository notificationRepository)
        {
            _dispatcher = dispatcher;
            _builder = builder;
            _notificationRepository = notificationRepository;
        }
        
        public async Task Handle(DispatchBasicMessageCommand notification, CancellationToken cancellationToken)
        {
            var message = await _builder.BuildNotification(notification.Title, notification.Content, notification.Recipient);
            await _notificationRepository.Save(message);
            await _dispatcher.Dispatch(message);
            await _notificationRepository.Save(message);
        }
    }
}