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
    public class DeleteShipperByIdCommandHandler : IRequestHandler<DeleteShipperByIdCommand, IResponse>
    {
        private readonly IShipperRepository _shipperRepository;

        public DeleteShipperByIdCommandHandler(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<IResponse> Handle(DeleteShipperByIdCommand request, CancellationToken cancellationToken)
        {
            return await _shipperRepository.DeleteAsync(request);

             
            //var toDelete = await _dbContext.Shippers.FindAsync(request.Id);

            //if(toDelete == null)
            //{
            //    return new { error = "There is no shipper with that id" };
            //}

            //_dbContext.Shippers.Remove(toDelete);

            //return await _dbContext.SaveChangesAsync() > 0
            //    ? new { message = $"Succesfuly deleted shipper with id = {request.Id}" }
            //    : new { message = "Something went wrong while deleting, please try again." };
        }
    }
}
