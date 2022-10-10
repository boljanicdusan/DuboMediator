namespace DuboMediator.Domain.EntityBase
{
    public interface IAuditDeleting
    {
        public DateTime? DeletionTime { get; set; }
        public string DeletedByUserId { get; set; }
    }
}