using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Domain.Users.Events;

public record UserCreatedDomainEvent(
    Guid UserId,
    DateTime CreatedAtUtc
    )  
    : IDomainEvent;