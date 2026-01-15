using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Application.Abstractions.Event;


public interface IDomainEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
