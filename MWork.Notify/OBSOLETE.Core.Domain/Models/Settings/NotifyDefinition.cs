using System;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models.Settings
{
    public class NotifyDefinition
    {
        public string Id { get; set;  }
        
        public string UserId { get; set; }
        
        public string Name { get; set; }
        
        public bool Enabled { get; set; }
        
        public DeliveryMethod DeliveryMethod { get; set; }
        
        public string TitleTemplate { get; set; }
        
        public string BodyTemplate { get; set; }
        
        public IDictionary<string, string> DataTemplate { get; set; }
        
        public PriorityType Priority { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool Deleted { get; set; }
    }
}