using TaskMangement.Domain.Primitives.Contracts;

namespace TaskMangement.Domain.Entities.Common;

public abstract class AggregateRoot<T> : BaseEntityDel<T>, IAggregateRoot
{
    //private readonly List<IDomainEvent> _domainEvents = new();
    //private readonly List<IIntegrationEvent> _integrationEvents = new();

    //public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    //public IReadOnlyCollection<IIntegrationEvent> IntegrationEvents => _integrationEvents.AsReadOnly();

    //public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    //public void AddIntegrationEvent(IIntegrationEvent integrationEvent) => _integrationEvents.Add(integrationEvent);

    //public void ClearDomainEvents() => _domainEvents.Clear();
    //public void ClearIntegrationEvents() => _integrationEvents.Clear();

}