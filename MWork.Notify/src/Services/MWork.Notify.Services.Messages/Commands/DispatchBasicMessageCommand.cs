using System.Collections.Generic;
using MediatR;
using MWork.Notify.Services.Messages.Domain.Enums;

namespace MWork.Notify.Services.Messages.Commands
{
    public class DispatchBasicMessageCommand : IRequest
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<NotificationChannel> Channels { get; set; }
        public IDictionary<string, string> Data { get; set; }
    }
}