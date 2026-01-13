using Microsoft.Extensions.DependencyInjection;

namespace no.sanddata.ams.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
