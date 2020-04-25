using FluentValidation;
using OnlineShop.Application.Commands.Auth;

namespace OnlineShop.Application.Validators.Auth
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
        }
    }
}
