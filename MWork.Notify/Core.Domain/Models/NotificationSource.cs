namespace MWork.Notify.Core.Domain.Models
{
    public class NotificationSource
    {
        public NotificationDefinition Definition { get; }
        
        public dynamic Data { get; }

        public NotificationSource(NotificationDefinition definition, dynamic data)
        {
            Definition = definition;
            Data = data;
        }
    }
}