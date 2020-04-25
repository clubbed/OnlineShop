using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Vendor;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Vendor
{
    public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, List<VendorVM>>
    {
        private readonly IShopDbContext dbContext;

        public GetAllVendorsQueryHandler(IShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<VendorVM>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
        {
            var response = await dbContext.Vendors
                .Include(c => c.Tax)
                .Select(c => new VendorVM
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    City = c.City,
                    Address = c.Address,
                    State = c.State,
                    Tax = c.Tax.Value
                }).ToListAsync();

            return response;
        }
    }
}
