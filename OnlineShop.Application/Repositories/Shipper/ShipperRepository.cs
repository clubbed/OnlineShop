using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Caching;
using OnlineShop.Application.Commands.Ship;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Shipper
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly IShopDbContext _dbContext;
        private readonly ICacheService _cacheService;

        public ShipperRepository(IShopDbContext dbContext,
            ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }
        public async Task<bool> CreateAsync(CreateShipperCommand req)
        {
            var shippingTypes = new List<OnlineShop.Domain.Entities.ShippingType>();

            foreach (var id in req.ShippingTypes)
            {
                var sT = await _dbContext.ShippingTypes.FindAsync(id);

                if (sT != null)
                {
                    shippingTypes.Add(sT);
                }
            }

            var shipper = new OnlineShop.Domain.Entities.Shipper
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Address = req.Address,
                City = req.City,
                State = req.State,
                ShippingTypes = shippingTypes
            };

            try
            {
                await _dbContext.Shippers.AddAsync(shipper);
                var result = await _dbContext.SaveChangesAsync() > 0;

                if (result)
                {
                    await _cacheService
                        .DeleteKeyAsync(RedisDefaultKeys.GetAllShippers);
                }

                return result;
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return false;
            }
        }

        public async Task<IResponse> DeleteAsync(DeleteShipperByIdCommand request)
        {
            var toDelete = await _dbContext.Shippers.FindAsync(request.Id);

            if (toDelete == null)
            {
                return new NotFoundResponse();
            }

            _dbContext.Shippers.Remove(toDelete);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result)
            {
                await _cacheService
                        .DeleteKeyAsync(RedisDefaultKeys.GetAllShippers);
                return new OkResponse<string>();
            }
            else
            {
                return new BadResponse();
            }
        }

        public async Task<List<ShipperVm>> GetAllAsync()
        {
            if(await _cacheService.KeyExistsAsync(RedisDefaultKeys.GetAllShippers))
            {
                return await _cacheService
                    .GetValueAsync<List<ShipperVm>>
                    (RedisDefaultKeys.GetAllShippers);
            }
            else
            {
                var result = await _dbContext.Shippers
                .Include(c => c.ShippingTypes)
                .Select(c => new ShipperVm
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    City = c.City,
                    State = c.State,
                    ShippingTypes = c.ShippingTypes.Select(sh => new ShippingTypeVM
                    {
                        Label = sh.Label
                    }).ToList()
                }).ToListAsync();

                await _cacheService
                    .SetValueAsync<List<ShipperVm>>
                    (RedisDefaultKeys.GetAllShippers, result);

                return result;
            }
        }

        public async Task<IResponse> UpdateAsync(UpdateShipperCommand request)
        {
            var shipperUpdate = await _dbContext.Shippers.FindAsync(request.Id);

            if (shipperUpdate == null)
            {
                //return new { error = "There is no shipper with that id" };
                return new NotFoundResponse();
            }

            shipperUpdate.FirstName = request.FirstName;
            shipperUpdate.LastName = request.LastName;
            shipperUpdate.Address = request.Address;
            shipperUpdate.City = request.City;
            shipperUpdate.State = request.State;

            _dbContext.Shippers.Update(shipperUpdate);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result)
            {
                await _cacheService
                        .DeleteKeyAsync(RedisDefaultKeys.GetAllShippers);
                return new OkResponse<string>();
            }
            else
            {
                return new BadResponse();
            }
        }
    }
}
