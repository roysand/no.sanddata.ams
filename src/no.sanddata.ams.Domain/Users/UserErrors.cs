using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Domain.Users;

public static class UserErrors
{
    public static Error NotFound { get; } = new("User.NotFund", "The specified user was not found.", ErrorType.NotFound);
    public static Error Exists { get; } = new("User.Exists", "The specified user with email exists.", ErrorType.Conflict);
    public static Error NoUsersFound { get; } = new("Users.NotFound", "No users were found.", ErrorType.NotFound);
}
