using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using no.sanddata.ams.Application.Abstractions.Clock;
using no.sanddata.ams.Application.Abstractions.Email;
using no.sanddata.ams.Infrastructure.Clock;
using no.sanddata.ams.Infrastructure.Email;

namespace no.sanddata.ams.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();
        
        return services;
    }
}
