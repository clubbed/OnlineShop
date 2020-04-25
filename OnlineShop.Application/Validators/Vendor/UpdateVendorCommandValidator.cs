using FluentValidation;
using OnlineShop.Application.Commands.Vendor;

namespace OnlineShop.Application.Validators.Vendor
{
    public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
    {
        public UpdateVendorCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.State).NotEmpty();
            RuleFor(c => c.TaxId).NotEmpty().GreaterThan(0);
        }
    }
}
