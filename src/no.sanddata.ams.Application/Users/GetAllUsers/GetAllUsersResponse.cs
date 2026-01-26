using no.sanddata.ams.Application.Abstractions.Messaging;

namespace no.sanddata.ams.Application.Users.GetAllUsers;

public sealed class GetAllUsersResponse() : IQuery<IReadOnlyList<GetAllUsersResponse>>
{
    public Guid Id { get; init; }
}
