using MediatR;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.MeasureUnit
{
    public class GetMeasureUnitsQuery : IRequest<List<MeasureUnitVM>>
    {
    }
}
