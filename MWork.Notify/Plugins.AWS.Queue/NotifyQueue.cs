using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Plugins.AWS.Queue.Models;
using Newtonsoft.Json;

namespace MWork.Notify.Plugins.AWS.Queue
{
    public class NotifyQueue : INotifyQueue
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IOptionsMonitor<NotifyQueueOptions> _options;
        private readonly IAmazonSQS _sqsClient;

        public NotifyQueue(INotificationRepository notificationRepository, IOptionsMonitor<NotifyQueueOptions> options)
        {
            _notificationRepository = notificationRepository;
            _options = options;

            var config = new AmazonSQSConfig();
            _sqsClient = new AmazonSQSClient(config);
        }

        public async Task Queue(Notification notification)
        {
            var options = _options.CurrentValue;
            var request = new SendMessageRequest()
            {
                MessageBody = JsonConvert.SerializeObject(notification),
                QueueUrl = await GetQueueUrl(options.NotificationQueueName)
            };

            await _sqsClient.SendMessageAsync(request);
        }

        public async Task Queue(IEnumerable<Notification> notifications)
        {
            await Task.WhenAll(notifications.Select(Queue));
        }

        private async Task<string> GetQueueUrl(string queueName)
        {
            var request = new GetQueueUrlRequest
            {
                QueueName = queueName
            };
            
            var response = await _sqsClient.GetQueueUrlAsync(request);

            return response.QueueUrl;
        }
    }
}