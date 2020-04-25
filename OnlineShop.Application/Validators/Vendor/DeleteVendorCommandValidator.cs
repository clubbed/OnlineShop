using FluentValidation;
using OnlineShop.Application.Commands.Vendor;

namespace OnlineShop.Application.Validators.Vendor
{
    public class DeleteVendorCommandValidator : AbstractValidator<DeleteVendorCommand>
    {
        public DeleteVendorCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
        }
    }
}
