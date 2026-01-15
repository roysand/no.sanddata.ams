using Microsoft.Extensions.DependencyInjection;
using no.sanddata.ams.Application.Abstractions.Event;
using no.sanddata.ams.Application.Users.CreateUser;
using no.sanddata.ams.Domain.Users.Events;

namespace no.sanddata.ams.Application;

public static class AddDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddScoped<IDomainEventHandler<UserCreatedDomainEvent>, CreateUserDomainEventHandler>();
        
        return services;
    }
}
