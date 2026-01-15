using Microsoft.EntityFrameworkCore;
using no.sanddata.ams.Domain.Users;

namespace no.sanddata.ams.Infrastructure.Repositories;

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
            .ToListAsync(cancellationToken);
    }
}
