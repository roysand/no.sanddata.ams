using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Users;

namespace no.sanddata.ams.Application.Users.ListAllUsers;

public sealed class ListAllUsersQueryHandler : IQueryHandler<ListAllUsersQuery, IReadOnlyList<Guid>>
{
    private readonly IUserRepository _userRepository;

    public ListAllUsersQueryHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<IReadOnlyList<Guid>>> HandleAsync(ListAllUsersQuery query, CancellationToken cancellationToken)
    {    
        var users = await _userRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
        if (users is null)
        {
            return Result.Failure<IReadOnlyList<Guid>>(UserErrors.NoUsersFound);
        }
        var userIds = users.Select(u => u.Id).ToList();
        
        return Result.Success<IReadOnlyList<Guid>>(userIds);

    }
}