using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Common.Sdk.Repository;
using MWork.Notify.Services.Messages.Commands;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Services.Abstractions;

namespace MWork.Notify.Services.Messages.Handlers
{
    public class DispatchBasicMessageCommandHandler : AsyncRequestHandler<DispatchBasicMessageCommand>
    {
        private readonly IDataRepository<Message> _messageRepository;
        private readonly INotificationPublisherFactory _notificationPublisherFactory;
        
        public DispatchBasicMessageCommandHandler(IDataRepository<Message> messageRepository, INotificationPublisherFactory notificationPublisherFactory)
        {
            _messageRepository = messageRepository;
            _notificationPublisherFactory = notificationPublisherFactory;
        }
        
        protected override async Task Handle(DispatchBasicMessageCommand command, CancellationToken cancellationToken)
        {
            var message = new Message()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAtUtc = DateTime.UtcNow,
                Payload = new Payload()
                {
                    Body = command.Body,
                    Title = command.Title,
                    Data = command.Data
                },
                NotificationChannels = command.Channels
            };
            
            // Store notification in database
            await _messageRepository.Create(message);
            
            // Queue notifications
            command?.Channels?
                .Distinct()
                .AsParallel()
                .Select(async channel => await _notificationPublisherFactory.GetPublisher(channel).Queue(message));
        }
    }
}