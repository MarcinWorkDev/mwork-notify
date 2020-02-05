using System.Collections.Generic;
using Newtonsoft.Json;

namespace MWork.Notify.Services.Messages.Services.Models
{
    public class PushMessage
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; }
        
        [JsonProperty("userId")]
        public string UserId { get; set; }
        
        [JsonProperty("data")]
        public IDictionary<string, string> Data { get; set; }
    }
}