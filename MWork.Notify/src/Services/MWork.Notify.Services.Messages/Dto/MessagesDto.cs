using System.Collections.Generic;

namespace MWork.Notify.Services.Messages.Dto
{
    public class MessagesDto
    {
        public List<MessageDto> Results { get; set; }
        
        public CursorDto Cursor { get; set; }
    }
}