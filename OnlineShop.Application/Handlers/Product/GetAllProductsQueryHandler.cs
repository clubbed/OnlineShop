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
using System.Xml.XPath;

namespace OnlineShop.Application.Handlers.Product
{
    //public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductVM>>
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IResponse>
    {
        private readonly IShopDbContext dbContext;

        public GetAllProductsQueryHandler(IShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task<List<ProductVM>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        public async Task<IResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            //var skip = (request.PageNumber - 1) * request.PageSize;
            //var take = request.PageSize;

            //var response = await dbContext.Products
            //                .Include(c => c.MeasureUnit)
            //                .Include(c => c.Vendor)
            //                .Skip(skip)
            //                .Take(take)
            //                .Select(c => new ProductVM
            //                {
            //                    Id = c.Id,
            //                    Name = c.Name,
            //                    Description = c.Description,
            //                    Price = c.Price,
            //                    Qty = c.Qty,
            //                    MeasureUnit = c.MeasureUnit.Name,
            //                    Vendor = $"{c.Vendor.FirstName} {c.Vendor.LastName}"
            //                }).ToListAsync();

            //return response;

            var query = dbContext.Products
                           .Include(c => c.MeasureUnit)
                           .Include(c => c.Vendor)
                           .Include(c => c.Category)
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
                           }).AsQueryable();


            var result = await Pagination<ProductVM>.CreateAsync(query, request.PageNumber, request.PageSize);

            var pagedResponse = new PagedResponse<List<ProductVM>>(result, result.PageIndex, 
                result.TotalPages, result.HasPreviousPage, result.HasNextPage);

            return pagedResponse;
        }
    }
}
