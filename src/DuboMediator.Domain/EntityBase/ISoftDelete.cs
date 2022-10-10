namespace DuboMediator.Domain.EntityBase
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}