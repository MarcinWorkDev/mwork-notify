using System.Collections.Generic;
using MWork.Notify.Common.Api.Models;

namespace MWork.Notify.Services.Messages.Dto
{
    public class MessagesDto : CursorDto
    {
        public List<MessageDto> Results { get; set; }
    }
}