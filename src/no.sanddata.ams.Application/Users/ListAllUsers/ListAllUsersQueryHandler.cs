using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Application.Users.ListAllUsers;

public class ListAllUsersQueryHandler : IQueryHandler<ListAllUsersQuery, IReadOnlyList<Guid>>
{
    public Task<Result<IReadOnlyList<Guid>>> HandleAsync(ListAllUsersQuery query, CancellationToken cancellationToken)
    {    
        throw new NotImplementedException();
    }
}