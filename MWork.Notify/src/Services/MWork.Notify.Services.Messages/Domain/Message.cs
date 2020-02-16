using System;
using System.Collections.Generic;
using MWork.Common.Sdk.Repository.Types;
using MWork.Notify.Services.Messages.Domain.Enums;

namespace MWork.Notify.Services.Messages.Domain
{
    public class Message : IWithId
    {
        public string Id { get; set; }
        
        public Payload Payload { get; set; }
        
        public string TriggeredBy { get; set; }
        
        public string TriggeredById { get; set; }
        
        public DateTime? ReadAtUtc { get; set; }
        
        public bool Starred { get; set; }
        
        public string UserId { get; set; }
        
        public IList<NotificationChannel> NotificationChannels { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool Deleted { get; set; }
    }
}