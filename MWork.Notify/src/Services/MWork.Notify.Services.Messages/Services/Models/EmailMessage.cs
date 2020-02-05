using Newtonsoft.Json;

namespace MWork.Notify.Services.Messages.Services.Models
{
    public class EmailMessage
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; }
        
        [JsonProperty("priority")]
        public string Priority { get; set; }
        
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}