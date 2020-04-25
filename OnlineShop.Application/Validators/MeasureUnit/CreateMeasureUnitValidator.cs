using FluentValidation;
using OnlineShop.Application.Commands.MeasureUnit;

namespace OnlineShop.Application.Validators.MeasureUnit
{
    public class CreateMeasureUnitValidator : AbstractValidator<CreateMeasureUnitCommand>
    {
        public CreateMeasureUnitValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}
