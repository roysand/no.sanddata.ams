using Infrastructure.DomainEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using SharedKernel;

namespace Infrastructure.Database;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Build configuration
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("local.appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        string connectionString = configuration.GetConnectionString("Database");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(
            connectionString,
            sqlOptions => sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default)
        ).UseSnakeCaseNamingConvention();

        // Minimal stub for DomainEventDispatcher
        var mockDispatcher = new NoOpDomainEventDispatcher();

        return new ApplicationDbContext(optionsBuilder.Options, mockDispatcher);
    }
}

// Minimal no-op implementation
// public class NoOpDomainEventDispatcher<T> : IDomainEventHandler<T> where T : IDomainEvent
// {
//     public Task Handle(T domainEvent, CancellationToken cancellationToken)
//         => Task.CompletedTask;
// }

public class NoOpDomainEventDispatcher : IDomainEventsDispatcher
{
    public Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
