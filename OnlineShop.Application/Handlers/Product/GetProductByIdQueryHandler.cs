using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Product;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IResponse>
    {
        private readonly IShopDbContext _dbContext;

        public GetProductByIdQueryHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .Include(c => c.MeasureUnit)
                .Include(c => c.Vendor)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if(product == null)
            {
                return new NotFoundResponse("There is no product with this id");
            }

            var productVm = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty,
                MeasureUnit = product.MeasureUnit.Name,
                Vendor = $"{product.Vendor.FirstName} {product.Vendor.LastName}",
                IsFeatured = product.IsFeatured,
                ImagePath = product.ImagePath,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name
            };

            return new OkResponse<ProductVM>(productVm);
        }
    }
}
