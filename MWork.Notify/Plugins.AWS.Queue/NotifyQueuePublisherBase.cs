using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;
using MWork.Notify.Plugins.AWS.Queue.Models;
using Newtonsoft.Json;

namespace MWork.Notify.Plugins.AWS.Queue
{
    public abstract class NotifyQueuePublisherBase<T> : INotifyQueuePublisher
    {
        private readonly IAmazonSQS _sqsClient;

        protected readonly PublisherOptions QueueOptions;
        
        public DeliveryMethod DeliveryMethod { get; }

        protected NotifyQueuePublisherBase(DeliveryMethod deliveryMethod, PublisherOptions queueOptions)
        {
            DeliveryMethod = deliveryMethod;
            QueueOptions = queueOptions;
            
            var config = new AmazonSQSConfig();
            _sqsClient = new AmazonSQSClient(config);
        }

        public async Task<QueueMessage> Queue(Notification notification, IList<UserEndpoint> endpoints)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification), "Notification argument is required!");
            }
            
            if (endpoints?.Any() != true)
            {
                throw new ArgumentNullException(nameof(endpoints), "At least one endpoint is required!");
            }
            
            if (endpoints.Any(x => x.DeliveryMethod != DeliveryMethod))
            {
                throw new ArgumentNullException(nameof(endpoints), $"All endpoints must be '{DeliveryMethod}' delivery method type!");
            }

            var message = await PrepareMessage(notification, endpoints);
            
            var sqsRequest = new SendMessageRequest()
            {
                QueueUrl = await GetQueueUrl(QueueOptions.QueueName),
                MessageAttributes = new Dictionary<string, MessageAttributeValue>()
                {
                    {"notificationId", new MessageAttributeValue()
                    {
                        StringValue = notification.Id
                    }}
                },
                MessageBody = JsonConvert.SerializeObject(message)
            };
            
            var queueMessage = new QueueMessage()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAtUtc = DateTime.UtcNow,
                DeliveryMethod = DeliveryMethod,
                Endpoints = endpoints,
                Notification = notification,
                QueueName = QueueOptions.QueueName
            };

            try
            {
                var sqsResponse = await _sqsClient.SendMessageAsync(sqsRequest);

                queueMessage.QueueMessageId = sqsResponse.MessageId;
                queueMessage.PublishedAtUtc = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                queueMessage.PublishError = "Notification publish to queue failed due to error: " + ex.Message;
            }

            return queueMessage;
        }

        protected abstract Task<T> PrepareMessage(Notification notification, IList<UserEndpoint> endpoints);

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