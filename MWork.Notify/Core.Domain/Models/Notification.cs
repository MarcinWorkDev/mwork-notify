using System;
using System.Collections;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; }
        
        public NotificationSource Source { get; }
        
        public DateTime CreatedAtUtc { get; }
        
        public string Title { get; }
        
        public string Content { get; }
        
        public string Recipient { get; }
        
        public DispatchStatus Status { get; set; }
        
        public string DispatchError { get; set; }
        
        public DateTime? DispatchedAtUtc { get; set; }

        public Notification(string title, string content, string recipient, NotificationSource source = null)
        {
            if (string.IsNullOrWhiteSpace(title)) 
                throw new ArgumentNullException(nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));
            
            if (string.IsNullOrWhiteSpace(recipient))
                throw new ArgumentNullException(nameof(recipient));
            
            Id = Guid.NewGuid();
            Source = source;
            CreatedAtUtc = DateTime.UtcNow;
            Title = title;
            Content = content;
            Recipient = recipient;
            Status = DispatchStatus.New;
        }
    }
}