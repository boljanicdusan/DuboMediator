using DuboMediator.Domain.EntityBase;

namespace DuboMediator.Domain.Entities
{
    public class Lecture : AuditedEntity
    {
        public string Name { get; set; }
        public int DurationInSeconds { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}