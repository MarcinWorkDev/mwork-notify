using System.Collections.Generic;
using MWork.Notify.Services.Messages.Domain.Enums;

namespace MWork.Notify.Services.Messages.Domain
{
    public class Payload
    {
        public Category Category { get; set; }
        
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public IDictionary<string, string> Data { get; set; }
        
        public PriorityType Priority { get; set; }
    }
}