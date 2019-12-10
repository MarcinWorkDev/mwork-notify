using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FcmSharp;
using FcmSharp.Requests;
using FcmSharp.Settings;
using MWork.Notify.Core.Domain.Abstractions;
using MWork.Notify.Core.Domain.Abstractions.Repositories;
using MWork.Notify.Core.Domain.Abstractions.Services;
using MWork.Notify.Core.Domain.Models.Enums;
using MWork.Notify.Plugins.Dispatchers.Push.Models;
using Newtonsoft.Json;
using Notification = MWork.Notify.Core.Domain.Models.Notification;

namespace MWork.Notify.Plugins.Dispatchers.Push
{
    public class PushMessageDispatcher : INotificationDispatcher, IDisposable
    {
        private readonly FcmClient _fcmClient;
        private readonly PushMessageDispatcherOptions _options;

        public PushMessageDispatcher(Action<PushMessageDispatcherOptions> options)
        {
            _options = new PushMessageDispatcherOptions();
            options.Invoke(_options);
            
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(_options.Credentials);
            if (_options.Project == null) _options.Project = dictionary["project_id"];
            
            _fcmClient = new FcmClient(new FcmClientSettings(_options.Project, _options.Credentials));
        }

        public async Task Dispatch(Notification notification)
        {
            // Set pending status
            notification.Status = DispatchStatus.Pending;

            try
            {
                // Dispatch message
                var message = new FcmMessage()
                {
                    Message = new Message()
                    {
                        Token = notification.Recipient,
                        Notification = new FcmSharp.Requests.Notification()
                        {
                            Title = notification.Title,
                            Body = notification.Content
                        }
                    }
                };

                var response = await _fcmClient.SendAsync(message);
                Console.WriteLine(response.Name);

                notification.Status = DispatchStatus.Sent;
                notification.DispatchedAtUtc = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                notification.Status = DispatchStatus.Failed;
                notification.DispatchError = ex.Message;
            }
        }

        public void Dispose()
        {
            _fcmClient?.Dispose();
        }
    }
}