using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MWork.Notify.Core.Api.Commands.Command;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Api.Commands.Handler
{
    public class DispatchBasicMessageHandler : INotificationHandler<DispatchBasicMessageCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IQueueMessageRepository _queueMessageRepository;
        private readonly INotifyQueuePublisherFactory _queuePublisherFactory;
        
        public DispatchBasicMessageHandler(INotificationRepository notificationRepository, INotifyQueuePublisherFactory queuePublisherFactory, IQueueMessageRepository queueMessageRepository)
        {
            _notificationRepository = notificationRepository;
            _queuePublisherFactory = queuePublisherFactory;
            _queueMessageRepository = queueMessageRepository;
        }
        
        public async Task Handle(DispatchBasicMessageCommand message, CancellationToken cancellationToken)
        {
            var notification = new Notification()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAtUtc = DateTime.UtcNow,
                Body = message.Body,
                Title = message.Title,
                Data = message.Data
            };
            
            var endpoint = new UserEndpoint()
            {
                DeliveryMethod = DeliveryMethod.Push,
                Endpoint = message.Token,
                Id = Guid.NewGuid().ToString()
            };
            
            // Store notification in database
            await _notificationRepository.Save(notification);
            
            // Queue notification
            var response = await _queuePublisherFactory.GetPublisher(DeliveryMethod.Push).Queue(notification, endpoint);

            await _queueMessageRepository.Save(response);
        }
    }
}