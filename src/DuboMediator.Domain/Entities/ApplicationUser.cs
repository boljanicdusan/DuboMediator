using System.ComponentModel.DataAnnotations;
using DuboMediator.Domain.Attributes;
using DuboMediator.Domain.EntityBase;
using Microsoft.AspNetCore.Identity;

namespace DuboMediator.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IAuditedEntity
    {
        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;
        public string FullName => $"{FirstName} {LastName}";

        public List<Course> AuthorCourses { get; set; }
        
        public List<Course> Courses { get; set; }

        // Creating
        [IgnoreAudit]
        public DateTime? CreationTime { get; set; }
        [IgnoreAudit]
        public string CreatedByUserId { get; set; }

        // Updating
        [IgnoreAudit]
        public DateTime? LastModificationTime { get; set; }
        [IgnoreAudit]
        public string LastModifiedByUserId { get; set; }

        // Deleting
        [IgnoreAudit]
        public DateTime? DeletionTime { get; set; }
        [IgnoreAudit]
        public string DeletedByUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}