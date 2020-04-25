using MediatR;
using OnlineShop.Application.Commands.Ship;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Ship
{
    public class CreateShipperCommandHandler : IRequestHandler<CreateShipperCommand, bool>
    {

        //private readonly IShopDbContext dbContext;

        //public CreateShipperCommandHandler(IShopDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        private readonly IShipperRepository _shipperRepository;

        public CreateShipperCommandHandler(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<bool> Handle(CreateShipperCommand request, CancellationToken cancellationToken)
        {
            return await _shipperRepository.CreateAsync(request);

            //var shippingTypes = new List<OnlineShop.Domain.Entities.ShippingType>();

            //foreach (var id in request.ShippingTypes)
            //{
            //    var sT = await dbContext.ShippingTypes.FindAsync(id);

            //    if(sT != null)
            //    {
            //        shippingTypes.Add(sT);
            //    }
            //}

            //var shipper = new OnlineShop.Domain.Entities.Shipper
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    Address = request.Address,
            //    City = request.City,
            //    State = request.State,
            //    ShippingTypes = shippingTypes
            //};

            //try
            //{
            //    await dbContext.Shippers.AddAsync(shipper);
            //    await dbContext.SaveChangesAsync();
            //    return "Success";

            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}

        }
    }
}
