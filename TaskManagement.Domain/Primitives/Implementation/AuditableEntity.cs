namespace TaskMangement.Domain.Entities.Common
{
    public abstract class AuditableEntity<T> : IAuditableEntity
    {
        public T Id { get; set; } = default!;
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
