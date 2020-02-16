using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace MWork.Notify.Services.Messages.Commands
{
    public class UpdateMessageCommand : IRequest
    {
        public string MessageId { get; set; }
        
        public IEnumerable<Operation> Operations { get; set; }
    }
}