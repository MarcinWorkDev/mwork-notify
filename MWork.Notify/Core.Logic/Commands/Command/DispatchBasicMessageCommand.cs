using MediatR;

namespace MWork.Notify.Core.Logic.Commands.Command
{
    public class DispatchBasicMessageCommand : INotification
    {
        public string Recipient { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DispatchBasicMessageCommand()
        {
            
        }
        
        public DispatchBasicMessageCommand(string recipient, string title, string content)
        {
            Recipient = recipient;
            Title = title;
            Content = content;
        }
    }
}