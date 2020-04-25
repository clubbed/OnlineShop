using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.MeasureUnit
{
    public class CreateMeasureUnitCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
