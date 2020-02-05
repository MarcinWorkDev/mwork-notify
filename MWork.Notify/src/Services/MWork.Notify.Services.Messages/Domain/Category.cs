using System;
using System.Collections.Generic;
using MWork.Notify.Services.Messages.Domain.Bases;

namespace MWork.Notify.Services.Messages.Domain
{
    public class Category : IAuditBase, IUserBase
    {
        public string Id { get; set; }
        
        public IEnumerable<Category> ChildCategories { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string UserId { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        
        public DateTime ModifiedAtUtc { get; set; }
        
        public bool Deleted { get; set; }
    }
}