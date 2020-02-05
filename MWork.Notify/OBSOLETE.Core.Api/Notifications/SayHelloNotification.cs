using MediatR;

namespace MWork.Notify.Core.Api.Notifications
{
    public class SayHelloNotification : INotification
    {
        public string Message { get; set; }

        public SayHelloNotification(string message)
        {
            Message = message;
        }
    }
}