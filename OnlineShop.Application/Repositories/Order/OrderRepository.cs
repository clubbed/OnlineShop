using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Caching;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IShopDbContext _dbContext;
        private readonly ICacheService _cacheService;

        public OrderRepository(IShopDbContext dbContext,
            ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }
    
        private IQueryable GetQueryable()
        {
            var orders = _dbContext.Orders
                .Include(c => c.OrderDetails)
                    .ThenInclude(c => c.Product)
                .Include(c => c.Customer)
                    .ThenInclude(c => c.User)
                    .AsQueryable();

            return orders;
        }
        public async Task<List<OrderVm>> GetAllAsync()
        {
            if(await _cacheService.KeyExistsAsync(RedisDefaultKeys.GetAllOrders))
            {
                return await _cacheService
                    .GetValueAsync<List<OrderVm>>(RedisDefaultKeys.GetAllOrders);
            }
            else
            {
                var orders = await _dbContext.Orders
                .Include(c => c.OrderDetails)
                    .ThenInclude(c => c.Product)
                .Include(c => c.Customer)
                    .ThenInclude(c => c.User)
                .Select(c => new OrderVm
                {
                    Id = c.Id,
                    Customer = c.Customer.User.UserName,
                    Total = c.Total,
                    OrderDetails = c.OrderDetails.Select(x => new OrderDetailsVm
                    {
                        ProductId = x.ProductId,
                        Discount = x.Discount,
                        Price = x.Price,
                        ProductName = x.Product.Name,
                        Qty = x.Qty,
                        TaxId = x.TaxId
                    }).ToList()
                })
                .ToListAsync();

                if (orders != null)
                {
                    await _cacheService
                        .SetValueAsync<List<OrderVm>>(RedisDefaultKeys.GetAllOrders, orders);
                }

                return orders;
            }            
        }

        public async Task<List<OrderVm>> GetAllByUserAsync(int userId)
        {
            if(await _cacheService.KeyExistsAsync(string.Format(RedisDefaultKeys.GetAllOrdersByUser,userId)))
            {
                return await _cacheService
                    .GetValueAsync<List<OrderVm>>(string.Format(RedisDefaultKeys.GetAllOrdersByUser, userId));
            }
            else
            {
                var orders = await _dbContext.Orders
               .Include(c => c.OrderDetails)
                   .ThenInclude(c => c.Product)
               .Include(c => c.Customer)
                   .ThenInclude(c => c.User)
               .Where(c => c.CustomerId == userId)
               .Select(c => new OrderVm
               {
                   Id = c.Id,
                   Customer = c.Customer.User.UserName,
                   Total = c.Total,
                   OrderDetails = c.OrderDetails.Select(x => new OrderDetailsVm
                   {
                       ProductId = x.ProductId,
                       Discount = x.Discount,
                       Price = x.Price,
                       ProductName = x.Product.Name,
                       Qty = x.Qty,
                       TaxId = x.TaxId
                   }).ToList()
               })
               .ToListAsync();

                if(orders != null)
                {
                    await _cacheService
                        .SetValueAsync<List<OrderVm>>
                        (string.Format(RedisDefaultKeys.GetAllOrdersByUser, userId), orders);
                }

                return orders;
            }            
        }

        public async Task<OrderVm> GetSingleAsync(int id)
        {
            var orders = await GetAllAsync();

            return orders.SingleOrDefault(c => c.Id == id);
        }

        public async Task<OrderVm> GetSingleByUserAsync(int id, int userId)
        {
            var order = await _dbContext.Orders
                .Include(c => c.OrderDetails)
                    .ThenInclude(c => c.Product)
                .Include(c => c.Customer)
                    .ThenInclude(c => c.User)
                .Where(c => c.CustomerId == userId && c.Id == id)
                .Select(c => new OrderVm
                {
                    Id = c.Id,
                    Customer = c.Customer.User.UserName,
                    Total = c.Total,
                    OrderDetails = c.OrderDetails.Select(x => new OrderDetailsVm
                    {
                        ProductId = x.ProductId,
                        Discount = x.Discount,
                        Price = x.Price,
                        ProductName = x.Product.Name,
                        Qty = x.Qty,
                        TaxId = x.TaxId
                    }).ToList()
                })
                .SingleOrDefaultAsync();

            return order;
        }

        public async Task<bool> DeleteAsync(DeleteOrderCommand command)
        {
            var orderToDelete = await _dbContext.Orders.FindAsync(command.Id);

            if (orderToDelete == null)
                return false;

            _dbContext.Orders.Remove(orderToDelete);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if(result)
            {
                await _cacheService
                    .DeleteKeyAsync(RedisDefaultKeys.GetAllOrders);
            }

            return result;
        }

        public async Task<bool> CreateAsync(CreateOrderCommand command)
        {
            try
            {
                var order = new OnlineShop.Domain.Entities.Order
                {
                    CustomerId = command.UserId,
                    Total = command.Total,
                    InvoiceDate = command.InvoiceDate,
                };

                var orderDetails = command.OrderDetails.Select(c => new OrderDetails
                {
                    Discount = c.Discount,
                    Qty = c.Qty,
                    ProductId = c.ProductId,
                    Price = c.Price,
                    TaxId = c.TaxId
                }).ToList();

                order.OrderDetails = orderDetails;

                await _dbContext.Orders.AddAsync(order);

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
