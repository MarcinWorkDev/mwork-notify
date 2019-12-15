namespace MWork.Notify.Plugins.AWS.Queue.Models
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        
        public string Body { get; set; }
        
        public string Priority { get; set; }
        
        public string To { get; set; }
    }
}