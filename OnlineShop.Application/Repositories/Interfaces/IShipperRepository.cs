using MediatR;
using OnlineShop.Application.Commands.Ship;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Interfaces
{
    public interface IShipperRepository
    {
        Task<List<ShipperVm>> GetAllAsync();
        Task<IResponse> DeleteAsync(DeleteShipperByIdCommand request);
        Task<IResponse> UpdateAsync(UpdateShipperCommand request);
        Task<bool> CreateAsync(CreateShipperCommand request);
    }
}
