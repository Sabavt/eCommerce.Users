using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(tmp => tmp.Email)
            .NotEmpty().WithMessage("Email must not be empty")
            .EmailAddress().WithMessage("Email is not correct");
        
        RuleFor(tmp => tmp.Password)
            .NotEmpty().WithMessage("Password must not be empty");
    }
} 