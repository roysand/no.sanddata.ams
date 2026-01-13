namespace no.sanddata.ams.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; }
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> GetDomainEvents => _domainEvents.AsReadOnly();
    protected Entity(Guid id)
    {
        Id = id;
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
