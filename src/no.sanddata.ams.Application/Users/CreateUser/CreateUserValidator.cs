using FluentValidation;
using no.sanddata.ams.Domain.Users;

namespace no.sanddata.ams.Application.Users.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress().WithMessage("Your email address is not valid");
        
        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("First name is required");

        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("Last name is required");
        
        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
