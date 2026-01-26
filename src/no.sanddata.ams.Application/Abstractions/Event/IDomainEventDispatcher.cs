using Microsoft.Extensions.DependencyInjection;

namespace no.sanddata.ams.Application.Abstractions.Event;

public interface IDomainEventDispatcher
{
    Task Dispatch<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : class;
}


public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Dispatch<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : class
    {
        IEnumerable<IDomainEventHandler<TDomainEvent>> handlers = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();
        
        foreach (IDomainEventHandler<TDomainEvent> handler in handlers)
        {
            await handler.Handle(domainEvent, cancellationToken).ConfigureAwait(false);
        }
    }
}
