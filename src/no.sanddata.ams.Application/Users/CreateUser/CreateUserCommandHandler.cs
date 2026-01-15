using no.sanddata.ams.Application.Abstractions.Clock;
using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Users;
using no.sanddata.ams.Domain.Users.Events;

namespace no.sanddata.ams.Application.Users.CreateUser;

public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        // Implementation to create a user and return the new user's ID
        ArgumentNullException.ThrowIfNull(command);
        
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var email = new Email(command.Email);
        var passwordHash = new PasswordHash(command.Password); // Hash the password here
        DateTime utcNow = DateTime.UtcNow;
        var user = User.Create(firstName, lastName, email, passwordHash, utcNow);

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id, utcNow));

        return Result.Success(user.Id);
    }
}



