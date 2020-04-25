using MediatR;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.Ship
{
    public class GetShipperByIdQuery : IRequest<ShipperVm>
    {
        public GetShipperByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
