using System.Collections.Generic;
using MediatR;

namespace MWork.Notify.Core.Api.Commands.Command
{
    public class DispatchBasicMessageCommand : INotification
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IDictionary<string, string> Data { get; set; }
    }
}