using MWork.Notify.Core.Domain.Models.Settings;

namespace MWork.Notify.Core.Domain.Models
{
    public class NotificationSource
    {
        public NotifyTrigger Trigger { get; set; }
        
        public dynamic Data { get; set; }
    }
}