using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
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
    public class GetFeaturedProductsQueryHandler : IRequestHandler<GetFeaturedProductsQuery, IResponse>
    {
        private readonly IShopDbContext _dbContext;

        public GetFeaturedProductsQueryHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IResponse> Handle(GetFeaturedProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Products
                .Where(c => c.IsFeatured == true)
                .Select(c => new ProductVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Qty = c.Qty,
                    MeasureUnit = c.MeasureUnit.Name,
                    Vendor = $"{c.Vendor.FirstName} {c.Vendor.LastName}",
                    IsFeatured = c.IsFeatured,
                    ImagePath = c.ImagePath,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name
                })
                .Take(10)
                .ToListAsync();

            if (products == null || !products.Any())
                return new NotFoundResponse();

            return new OkResponse<List<ProductVM>>(products);
        }
    }
}
