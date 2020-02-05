using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using MWork.Notify.Services.Messages.Services.Models;

namespace MWork.Notify.Common.Aws.SQS
{
    public class QueuePublishService
    {
        private readonly IAmazonSQS _sqsClient;

        protected readonly PublisherOptions QueueOptions;
        
        protected QueuePublishService(PublisherOptions queueOptions)
        {
            QueueOptions = queueOptions;
            
            var config = new AmazonSQSConfig();
            _sqsClient = new AmazonSQSClient(config);
        }

        public async Task<string> Queue(string payload, string sourceName, string messageId)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload), "Payload is required!");
            }
            
            var sqsRequest = new SendMessageRequest()
            {
                QueueUrl = await GetQueueUrl(QueueOptions.QueueName),
                MessageAttributes = new Dictionary<string, MessageAttributeValue>()
                {
                    {"sourceName", new MessageAttributeValue()
                    {
                        DataType = "String",
                        StringValue = sourceName
                    }},
                    {"messageId", new MessageAttributeValue()
                    {
                        DataType = "String",
                        StringValue = messageId
                    }}
                },
                MessageBody = payload
            };
   
            var sqsResponse = await _sqsClient.SendMessageAsync(sqsRequest);

            return sqsResponse.MessageId;
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