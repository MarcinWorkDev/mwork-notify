using System;
using System.Text.Json;
using System.Threading.Tasks;
using MWork.Notify.Common.Aws.SQS;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Domain.Enums;
using MWork.Notify.Services.Messages.Services.Abstractions;
using MWork.Notify.Services.Messages.Services.Models;

namespace MWork.Notify.Services.Messages.Services
{
    public class NotificationPushPublisher : QueuePublishService, INotificationPublisher // TODO: Change UserId to Tokens / Email address! SQS should not use UserId!
    {
        public NotificationChannel NotificationChannel => NotificationChannel.Push;
        
        public NotificationPushPublisher(PublisherOptions queueOptions) 
            : base(queueOptions)
        {
        }

        public async Task Queue(Message message)
        {
            if (message.Payload?.Data?.Count > 9)
            {
                throw new ArgumentException("Too many items in Data object!");
            }
            
            var msg = new PushMessage()
            {
                Title = message.Payload?.Title,
                Body = message.Payload?.Body,
                UserId = message.UserId,
                Data = message.Payload?.Data
            };

            var payload = JsonSerializer.Serialize(msg);
            
            await base.Queue(payload, ServiceConstants.ServiceName, message.Id);
        }
    }
}