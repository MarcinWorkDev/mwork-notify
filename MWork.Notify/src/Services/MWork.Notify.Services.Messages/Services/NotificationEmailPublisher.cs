using System.Text.Json;
using System.Threading.Tasks;
using MWork.Notify.Common.Aws.SQS;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Domain.Enums;
using MWork.Notify.Services.Messages.Services.Abstractions;
using MWork.Notify.Services.Messages.Services.Models;

namespace MWork.Notify.Services.Messages.Services
{
    public class NotificationEmailPublisher : QueuePublishService, INotificationPublisher
    {
        public NotificationChannel NotificationChannel => NotificationChannel.Email;
        
        public NotificationEmailPublisher(PublisherOptions queueOptions) 
            : base(queueOptions)
        {
        }
        
        public async Task Queue(Message message)
        {
            var msg = new EmailMessage()
            {
                Subject = message.Payload?.Title,
                Body = message.Payload?.Body,
                Priority = message.Payload?.Priority.ToString().ToLowerInvariant(),
                UserId = message.UserId
            };

            var payload = JsonSerializer.Serialize(msg);

            await base.Queue(payload, ServiceConstants.ServiceName, message.Id);
        }
    }
}