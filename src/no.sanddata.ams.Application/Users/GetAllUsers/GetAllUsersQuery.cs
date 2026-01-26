using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Application.Users.GetAllUsers;

public sealed record GetAllUsersQuery(bool IncludeInactive = false) : IQuery<IReadOnlyList<GetAllUsersResponse>>;
