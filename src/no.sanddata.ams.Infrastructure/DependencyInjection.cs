using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using no.sanddata.ams.Application.Abstractions.Clock;
using no.sanddata.ams.Application.Abstractions.Email;
using no.sanddata.ams.Application.Abstractions.Event;
using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Users;
using no.sanddata.ams.Infrastructure.Clock;
using no.sanddata.ams.Infrastructure.Email;
using no.sanddata.ams.Infrastructure.Events;
using no.sanddata.ams.Infrastructure.Repositories;

namespace no.sanddata.ams.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();
        
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options 
            => options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        
        return services;
    }
}
