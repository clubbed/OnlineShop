using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Vendor;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Vendor
{
    public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, VendorVM>
    {
        private readonly IShopDbContext dbContext;

        public GetVendorByIdQueryHandler(IShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VendorVM> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
        {
            var vendor = await dbContext.Vendors
                .Include(c => c.Tax)
                .FirstAsync(c => c.Id == request.Id);

            if (vendor == null)
                throw new ArgumentNullException("Id", "There is no vendor with this id");

            return new VendorVM
            {
                FirstName = vendor.FirstName,
                LastName = vendor.LastName,
                Address = vendor.Address,
                City = vendor.City,
                State = vendor.State,
                Tax = vendor.Tax.Value
            };

        }
    }
}
