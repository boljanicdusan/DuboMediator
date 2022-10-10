namespace DuboMediator.Domain.EntityBase
{
    public interface IAuditUpdating
    {
        public DateTime? LastModificationTime { get; set; }
        public string LastModifiedByUserId { get; set; }
    }
}