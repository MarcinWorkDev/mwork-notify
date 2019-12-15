using System;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models.Settings
{
    public class NotifyDefinition
    {
        public Guid Id { get; set;  }
        
        public User User { get; set; }
        
        public string Name { get; set; }
        
        public bool Enabled { get; set; }
        
        public EndpointType EndpointType { get; set; }
        
        public string TitleTemplate { get; set; }
        
        public string ContentTemplate { get; set; }
    }
}