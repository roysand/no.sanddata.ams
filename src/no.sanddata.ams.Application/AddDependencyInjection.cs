using Microsoft.Extensions.DependencyInjection;
using no.sanddata.ams.Application.Abstractions.Event;
using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Application.Users.CreateUser;
using no.sanddata.ams.Application.Users.GetAllUsers;
using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Users.Events;

namespace no.sanddata.ams.Application;

public static class AddDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddScoped<IDomainEventHandler<UserCreatedDomainEvent>, CreateUserDomainEventHandler>();
        services.AddScoped<IQueryHandler<GetAllUsersQuery, IReadOnlyList<GetAllUsersResponse>>, GetAllUsersQueryHandler>();
        
        return services;
    }
}
