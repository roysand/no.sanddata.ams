using Microsoft.Extensions.DependencyInjection;

namespace no.sanddata.ams.Application;

public static class AddDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
