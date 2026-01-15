using no.sanddata.ams.Application.Abstractions.Event;
using no.sanddata.ams.Domain.Users.Events;

namespace no.sanddata.ams.Application.Users.CreateUser;

internal sealed class CreateUserDomainEventHandler : IDomainEventHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        // Implement your domain event handling logic here
        // For example: send email, update read models, etc.
        await Task.CompletedTask;
    }
}
