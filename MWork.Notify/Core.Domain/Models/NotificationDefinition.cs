using System;
using System.Collections.Generic;
using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models
{
    public class NotificationDefinition
    {
        public Guid Id { get; }
        
        public string Name { get; set; }
        
        public bool Enabled { get; set; }
        
        public string TitleTemplate { get; set; }
        
        public string ContentTemplate { get; set; }
        
        public NotificationDefinition(string name, string titleTemplate, string contentTemplate)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException(nameof(name));
            
            if (string.IsNullOrWhiteSpace(titleTemplate)) 
                throw new ArgumentNullException(nameof(titleTemplate));
            
            if (string.IsNullOrWhiteSpace(contentTemplate)) 
                throw new ArgumentNullException(nameof(contentTemplate));
            
            Id = Guid.NewGuid();
            Name = name;
            TitleTemplate = titleTemplate;
            ContentTemplate = contentTemplate;
            Enabled = false;
        }
    }
}