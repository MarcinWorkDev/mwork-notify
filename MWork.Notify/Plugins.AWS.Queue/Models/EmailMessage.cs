using Newtonsoft.Json;

namespace MWork.Notify.Plugins.AWS.Queue.Models
{
    public class EmailMessage
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; }
        
        [JsonProperty("priority")]
        public string Priority { get; set; }
        
        [JsonProperty("to")]
        public string To { get; set; }
    }
}