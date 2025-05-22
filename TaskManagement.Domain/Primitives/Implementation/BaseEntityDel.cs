namespace TaskMangement.Domain.Entities.Common
{
    public abstract class BaseEntityDel<T> : AuditableEntity<T>, IBaseEntityDel
    {
        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
