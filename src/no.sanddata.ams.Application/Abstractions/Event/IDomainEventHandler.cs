namespace no.sanddata.ams.Application.Abstractions.Event;

public interface IDomainEventHandler<in TDomainEvent>
    where TDomainEvent : class
{
    Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}

