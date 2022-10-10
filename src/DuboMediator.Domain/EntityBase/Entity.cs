namespace DuboMediator.Domain.EntityBase
{
    public class Entity : Entity<Guid>
    {
        
    }

    public class Entity<T>
    {
        public T Id { get; set; }
    }
}