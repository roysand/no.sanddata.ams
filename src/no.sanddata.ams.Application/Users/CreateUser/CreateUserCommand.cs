using no.sanddata.ams.Application.Abstractions.Messaging;

namespace no.sanddata.ams.Application.Users.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : ICommand<Guid>;