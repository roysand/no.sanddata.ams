using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Application.Users.ListAllUsers;

public record ListAllUsersQuery() : IQuery<IReadOnlyList<Guid>>;