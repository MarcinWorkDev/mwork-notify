namespace MWork.Notify.Core.Api.Commands.Command
{
    public class SayHelloCommand : MediatR.INotification
    {
        public string Message { get; set; }

        public SayHelloCommand(string message)
        {
            Message = message;
        }
    }
}