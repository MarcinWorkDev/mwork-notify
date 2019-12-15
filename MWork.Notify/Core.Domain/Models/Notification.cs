using System;
using System.Collections;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Account;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        
        public NotificationSource Source { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public User User { get; set; }
        
        public IEnumerable<NotificationDispatch> Dispatches { get; set; }
    }
}