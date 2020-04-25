using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.MeasureUnit
{
    public class DeleteMeasureUnitCommand : IRequest<bool>
    {
        public DeleteMeasureUnitCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
