using System;
using System.Collections;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Domain.Models.Settings
{
    public class NotifyTrigger
    {
        public Guid Id { get; set; }
        
        public User User { get; set; }
        
        public string Name { get; set; }
        
        public bool Enabled { get; set; }
        
        public IEnumerable<NotifyDefinition> Definitions { get; set; }
    }
}