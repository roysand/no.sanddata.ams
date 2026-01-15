using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using no.sanddata.ams.Application.Abstractions.Event;
using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Infrastructure.Events;

public sealed class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        
        Type handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        IEnumerable<object?> handlers = _serviceProvider.GetServices(handlerType);

        foreach (object? handler in handlers)
        {
            MethodInfo? handleMethod = handlerType.GetMethod("Handle");
            if (handleMethod != null)
            {
                await (Task)handleMethod.Invoke(handler, [domainEvent, cancellationToken])!;
            }
        }
    }
}
