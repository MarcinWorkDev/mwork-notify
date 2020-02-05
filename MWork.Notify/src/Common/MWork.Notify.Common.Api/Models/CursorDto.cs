using System.Text.Json.Serialization;

namespace MWork.Notify.Common.Api.Models
{
    public abstract class CursorDto
    {
        [JsonPropertyName("cursor_prev")]
        public string CursorNext { get; set; }
        
        [JsonPropertyName("cursor_next")]
        public string CursorPrev { get; set; }
    }
}