using System;

namespace MWork.Notify.Core.Domain.Models.Account
{
    public class User
    {
        public string Id { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public string ExternalUserId { get; set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public UserPreferences Preferences { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool Deleted { get; set; }
    }
}