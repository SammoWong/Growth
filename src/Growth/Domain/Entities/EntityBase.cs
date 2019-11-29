namespace Growth.Domain.Entities
{
    public abstract class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
