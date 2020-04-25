using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Pagination;
using OnlineShop.Application.Queries.Product;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Product
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, IResponse>
    {
        private readonly IShopDbContext _dbContext;

        public GetProductsByCategoryQueryHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IResponse> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Products
                .Include(c => c.Category)
                .Include(c => c.Vendor)
                .Include(c => c.MeasureUnit)
                .Where(c => c.CategoryId == request.Id)
                .Select(c => new ProductVM
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Name = c.Name,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    Price = c.Price,
                    Qty = c.Qty,
                    MeasureUnit = c.MeasureUnit.Name,
                    Vendor = $"{c.Vendor.FirstName} {c.Vendor.LastName}",
                    Id = c.Id
                })
                .AsQueryable();

            if (query == null || !query.Any())
                return new NotFoundResponse();

            var result = await Pagination<ProductVM>.CreateAsync(query, request.PageNumber, request.PageSize);

            var pagedResponse = new PagedResponse<List<ProductVM>>(result, result.PageIndex,
                result.TotalPages, result.HasPreviousPage, result.HasNextPage);

            return pagedResponse;
        }
    }
}
