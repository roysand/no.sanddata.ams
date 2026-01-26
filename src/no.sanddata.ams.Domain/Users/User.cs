using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Users.Events;

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
    
// due to ORM
#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
    
    private User(Guid id,
        FirstName firstName,
        LastName lastName,
        Email email,
        PasswordHash passwordHash,
        DateTime utcNow)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAtUtc = utcNow;
        ModifiedAtUtc = utcNow;
    }

    public static User Create(FirstName firstName,
        LastName lastName,
        Email email,
        PasswordHash passwordHash,
        DateTime utcNow)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email, passwordHash, utcNow);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id,utcNow));
        return user;
    }
}
