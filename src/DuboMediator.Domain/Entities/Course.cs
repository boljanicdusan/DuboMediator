using System.ComponentModel.DataAnnotations;
using DuboMediator.Domain.EntityBase;

namespace DuboMediator.Domain.Entities
{
    public class Course : AuditedEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Topic { get; set; }
        public double Price { get; set; }

        // Relation to Users table
        public Guid AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}