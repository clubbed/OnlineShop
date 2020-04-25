using FluentValidation;
using OnlineShop.Application.Commands.Auth;

namespace OnlineShop.Application.Validators.Auth
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
        }
    }
}
