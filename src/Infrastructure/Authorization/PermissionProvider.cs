namespace Infrastructure.Authorization;

internal sealed class PermissionProvider
{
    public static Task<HashSet<string>> GetForUserIdAsync(Guid userId)
    {
        HashSet<string> permissionsSet = [];

        return Task.FromResult(permissionsSet);
    }
}
