using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Domain.Users;

public sealed class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime ModifiedAtUtc { get; private set; }

    private User(Guid id, FirstName firstName, LastName lastName, Email email, PasswordHash passwordHash)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAtUtc = DateTime.UtcNow;
        ModifiedAtUtc = DateTime.UtcNow;
    }

    public static User Create(FirstName firstName, LastName lastName, Email email, PasswordHash passwordHash)
    {
        return new User(Guid.NewGuid(), firstName, lastName, email, passwordHash);
    }
}
