namespace MWork.Notify.Core.Services.Commands.Command
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