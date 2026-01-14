namespace no.sanddata.ams.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<User>?> GetAllAsync(CancellationToken cancellationToken = default);
    void Add(User user);
}