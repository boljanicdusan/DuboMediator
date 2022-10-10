namespace DuboMediator.Domain.EntityBase
{
    public interface IAuditCreating
    {
        public DateTime? CreationTime { get; set; }
        public string CreatedByUserId { get; set; }
    }
}