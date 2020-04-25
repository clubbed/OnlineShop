using MediatR;
using OnlineShop.Application.Commands.Vendor;
using OnlineShop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Vendor
{
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, string>
    {
        private readonly IShopDbContext dbContext;

        public CreateVendorCommandHandler(IShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = new OnlineShop.Domain.Entities.Vendor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                City = request.City,
                State = request.State,
                TaxId = request.TaxId,
                Discount = request.Discount
            };

            await dbContext.Vendors.AddAsync(vendor);

            var result = await dbContext.SaveChangesAsync();

            return result == 1 ? "Succesfuly created new vendor" : "There was a problem while creating new vendor";
        }
    }
}
