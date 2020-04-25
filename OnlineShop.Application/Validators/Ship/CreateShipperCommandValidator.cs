using FluentValidation;
using OnlineShop.Application.Commands.Ship;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Validators.Ship
{
    public class CreateShipperCommandValidator : AbstractValidator<CreateShipperCommand>
    {
        public CreateShipperCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.State).NotEmpty();
            RuleFor(c => c.ShippingTypes).NotEmpty();
        }
    }
}
