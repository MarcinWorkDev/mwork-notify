namespace MWork.Notify.Core.Logic.Commands.Command
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