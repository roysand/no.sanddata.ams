using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using no.sanddata.ams.Application.Abstractions.Event;
using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Infrastructure;

public sealed class ApplicationDbContext(
    DbContextOptions options,
    IDomainEventPublisher eventPublisher)
    : DbContext(options), IUnitOfWork
{
    private readonly IDomainEventPublisher _eventPublisher = eventPublisher;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        await PublishDomainEventsAsync(cancellationToken).ConfigureAwait(false);
        return result;
    }
    private async Task PublishDomainEventsAsync(CancellationToken cancellationToken)
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                IReadOnlyList<IDomainEvent> domainEvents = entity.GetDomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent, cancellationToken).ConfigureAwait(false);
        }
    }
}
