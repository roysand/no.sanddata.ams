using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Users;

namespace no.sanddata.ams.Application.Users.GetAllUsers;

public sealed class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IReadOnlyList<GetAllUsersResponse>>
{
//    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(
        IUnitOfWork unitOfWork
//        ,IUserRepository userRepository
        )
    {
  //      _userRepository = userRepository;
    }

    public Task<Result<IReadOnlyList<GetAllUsersResponse>>> HandleAsync(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
