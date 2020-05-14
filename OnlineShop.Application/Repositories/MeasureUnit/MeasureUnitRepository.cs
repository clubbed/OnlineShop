using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Caching;
using OnlineShop.Application.Commands.MeasureUnit;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.MeasureUnit
{
    public class MeasureUnitRepository : IMeasureUnitRepository
    {
        private readonly IShopDbContext _dbContext;
        private readonly ICacheService _cacheService;

        public MeasureUnitRepository(IShopDbContext dbContext,
            ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        public async Task<List<MeasureUnitVM>> GetMeasureUnitsAsync()
        {
            if(await _cacheService.KeyExistsAsync(RedisDefaultKeys.GetAllMeasureUnits))
            {
                return await _cacheService
                    .GetValueAsync<List<MeasureUnitVM>>
                    (RedisDefaultKeys.GetAllMeasureUnits);
            }
            else
            {
                var result =  await _dbContext.MeasureUnits.Select(c => new MeasureUnitVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

                await _cacheService
                    .SetValueAsync<List<MeasureUnitVM>>
                    (RedisDefaultKeys.GetAllMeasureUnits, result);

                return result;
            }
        }

        public async Task<bool> CreateAsync(CreateMeasureUnitCommand request)
        {
            var measureUnit = new OnlineShop.Domain.Entities.MeasureUnit
            {
                Name = request.Name
            };

            await _dbContext.MeasureUnits.AddAsync(measureUnit);
            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result)
            {
                await _cacheService.DeleteKeyAsync(RedisDefaultKeys.GetAllMeasureUnits);

                return result;
            }

            return result;
        }

        public async Task<bool> UpdateAsync(UpdateMeasureUnitCommand request)
        {
            var toUpdate = await _dbContext.MeasureUnits.FindAsync(request.Id);

            toUpdate.Name = request.Name;

            _dbContext.MeasureUnits.Update(toUpdate);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result)
            {
                await _cacheService.DeleteKeyAsync(RedisDefaultKeys.GetAllMeasureUnits);

                return result;
            }

            return result;
        }

        public async Task<bool> DeleteAsync(DeleteMeasureUnitCommand request)
        {
            var toDelete = await _dbContext.MeasureUnits.FindAsync(request.Id);

            _dbContext.MeasureUnits.Remove(toDelete);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result)
            {
                await _cacheService.DeleteKeyAsync(RedisDefaultKeys.GetAllMeasureUnits);

                return result;
            }

            return result;
        }
    }
}
