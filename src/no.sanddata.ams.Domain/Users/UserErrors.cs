using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Domain.Users;

public static class UserErrors
{
    public static Error NotFund { get; } = new("User.NotFund", "The specified user was not found.");
    public static Error Exists { get; } = new("User.Exists", "The specified user with email exists.");
}