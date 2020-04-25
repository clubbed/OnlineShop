using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderVm>> GetAllAsync();
        Task<OrderVm> GetSingleAsync(int id);
        Task<List<OrderVm>> GetAllByUserAsync(int userId);
        Task<OrderVm> GetSingleByUserAsync(int id, int userId);

        Task<bool> DeleteAsync(DeleteOrderCommand command);
        //Task<bool> UpdateAsync(UpdateOrderCommand command);
        Task<bool> CreateAsync(CreateOrderCommand command);
    }
}
