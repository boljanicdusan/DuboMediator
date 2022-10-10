using DuboMediator.Domain.EntityBase;

namespace DuboMediator.Domain.Entities
{
    public class ChangeLog : Entity<long>
    {
        // public long Id { get; set; }
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string ChangeType { get; set; }
        public DateTime ChangeTime { get; set; }
        public string ChangedByUserId { get; set; }
    }
}