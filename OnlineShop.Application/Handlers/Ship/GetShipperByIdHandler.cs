using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Ship;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Ship
{
    public class GetShipperByIdHandler : IRequestHandler<GetShipperByIdQuery, ShipperVm>
    {
        private readonly IShopDbContext _dbContext;

        public GetShipperByIdHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShipperVm> Handle(GetShipperByIdQuery request, CancellationToken cancellationToken)
        {
            var shipper = await _dbContext.Shippers
                .Include(c => c.ShippingTypes)
                .FirstAsync(c => c.Id == request.Id);

            var result = new ShipperVm
            {
                FirstName = shipper.FirstName,
                LastName = shipper.LastName,
                Address = shipper.Address,
                City = shipper.City,
                State = shipper.City,
                ShippingTypes = shipper.ShippingTypes.Select(c => new ShippingTypeVM
                {
                    Label = c.Label
                }).ToList()
            };

            return result;
        }
    }
}
