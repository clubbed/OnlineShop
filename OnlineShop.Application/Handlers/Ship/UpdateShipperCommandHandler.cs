using MediatR;
using OnlineShop.Application.Commands.Ship;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Ship
{
    public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommand, IResponse>
    {

        //private readonly IShopDbContext _dbContext;

        //public UpdateShipperCommandHandler(IShopDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        private readonly IShipperRepository _shipperRepository;

        public UpdateShipperCommandHandler(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<IResponse> Handle(UpdateShipperCommand request, CancellationToken cancellationToken)
        {
            return await _shipperRepository.UpdateAsync(request);

            //var shipperUpdate = await _dbContext.Shippers.FindAsync(request.Id);

            //if (shipperUpdate == null)
            //{
            //    return new { error = "There is no shipper with that id" };
            //}

            //shipperUpdate.FirstName = request.FirstName;
            //shipperUpdate.LastName = request.LastName;
            //shipperUpdate.Address = request.Address;
            //shipperUpdate.City = request.City;
            //shipperUpdate.State = request.State;

            //_dbContext.Shippers.Update(shipperUpdate);

            //return await _dbContext.SaveChangesAsync() > 0
            //         ? new { message = $"Succefuly updated shipper with id = {request.Id}" }
            //         : new { message = "Something went wrong while updating" };
        }
    }
}
