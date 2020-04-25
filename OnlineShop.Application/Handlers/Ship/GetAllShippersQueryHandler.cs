using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Ship;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Ship
{
    public class GetAllShippersQueryHandler : IRequestHandler<GetAllShippersQuery, List<ShipperVm>>
    {
        private readonly IShipperRepository _shipperRepository;

        public GetAllShippersQueryHandler(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<List<ShipperVm>> Handle(GetAllShippersQuery request, CancellationToken cancellationToken)
        {
            return await _shipperRepository.GetAllAsync();
        }
    }
}
