using System.Text.Json.Serialization;

namespace MWork.Common.WebApi.Dtos
{
    public class PatchOperationDto
    {
        [JsonPropertyName("op")]
        public string Operation { get; set; }
        
        [JsonPropertyName("path")]
        public string Path { get; set; }
        
        [JsonPropertyName("value")]
        public object Value { get; set; }
    }
}