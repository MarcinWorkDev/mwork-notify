using System.Collections.Generic;

namespace MWork.Notify.Plugins.AWS.Queue.Models
{
    public class PushMessage
    {
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public string[] Tokens { get; set; }
        
        public IDictionary<string, string> Data { get; set; }
    }
}