using DuboMediator.Domain.Attributes;

namespace DuboMediator.Domain.EntityBase
{
    public class AuditedEntity : AuditedEntity<Guid>
    {
        
    }

    public class AuditedEntity<T> : Entity<T>, IAuditCreating, IAuditUpdating, IAuditDeleting, ISoftDelete
    {
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