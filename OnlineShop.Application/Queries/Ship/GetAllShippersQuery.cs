using MediatR;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;

namespace OnlineShop.Application.Queries.Ship
{
    public class GetAllShippersQuery : IRequest<List<ShipperVm>>
    {
    }
}
