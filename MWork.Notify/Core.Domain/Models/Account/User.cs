using System;
using System.Collections.Generic;

namespace MWork.Notify.Core.Domain.Models.Account
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public UserPreferences Preferences { get; set; }
        
        public IEnumerable<UserEndpoint> Endpoints { get; set; }
    }
}