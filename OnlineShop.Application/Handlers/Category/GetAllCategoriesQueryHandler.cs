using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using OnlineShop.Application.Caching;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Category;
using OnlineShop.Application.Response;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Category
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IResponse>
    {
        private readonly IShopDbContext _dbContext;
        private readonly ICacheService _cacheService;

        public GetAllCategoriesQueryHandler(IShopDbContext dbContext, ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }
        public async Task<IResponse> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (await _cacheService.KeyExistsAsync(RedisDefaultKeys.GetAllCategories))
            {
                var result = await _cacheService
                    .GetValueAsync<List<CategoryVM>>(RedisDefaultKeys.GetAllCategories);

                return new OkResponse<List<CategoryVM>>(result);
            }
            else
            {
                var categories = await _dbContext.Categories
                       .Include(c => c.ParentCategory)
                       .Select(c => new CategoryVM
                       {
                           Id = c.Id,
                           Name = c.Name,
                           ParentName = c.ParentCategory.Name
                       })
                       .ToListAsync();

                if (categories == null || !categories.Any())
                    return new NotFoundResponse();

                await _cacheService
                    .SetValueAsync<List<CategoryVM>>(RedisDefaultKeys.GetAllCategories, categories);

                return new OkResponse<List<CategoryVM>>(categories);
            }
        }
    }
}
