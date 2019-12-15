using System;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models
{
    public class Notification
    {
        public string Id { get; set; }
        
        public string UserId { get; set; }
        
        public string Source { get; set; }
        
        public string SourceId { get; set; }

        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public IDictionary<string, string> Data { get; set; }
        
        public PriorityType Priority { get; set; }

        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public DateTime? ReadAtUtc { get; set; }
        
        public bool Starred { get; set; }
        
        public bool Deleted { get; set; }
    }
}