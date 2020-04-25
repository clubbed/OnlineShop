using FluentValidation;
using OnlineShop.Application.Commands.Product;

namespace OnlineShop.Application.Validators.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.MeasureUnit).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Qty).NotEmpty();
        }
    }
}
