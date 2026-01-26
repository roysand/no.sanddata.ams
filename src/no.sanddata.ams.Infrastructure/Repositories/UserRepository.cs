using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using no.sanddata.ams.Domain.Users;

namespace no.sanddata.ams.Infrastructure.Repositories;

[SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Instantiated by DI container")]
internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<User>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<User>()
            .ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}
