using System.Collections.Generic;
using Newtonsoft.Json;

namespace MWork.Notify.Plugins.AWS.Queue.Models
{
    public class PushMessage
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; }
        
        [JsonProperty("tokens")]
        public string[] Tokens { get; set; }
        
        [JsonProperty("data")]
        public IDictionary<string, string> Data { get; set; }
    }
}