using FluentValidation;
using OnlineShop.Application.Commands.Vendor;

namespace OnlineShop.Application.Validators.Vendor
{
    public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
    {
        public CreateVendorCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.State).NotEmpty();
            RuleFor(c => c.TaxId).NotEmpty().GreaterThan(0);
        }
    }
}
