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
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, bool>
    {
        private readonly IShopDbContext dbContext;

        public UpdateVendorCommandHandler(IShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var updateVendor = await dbContext.Vendors.FindAsync(request.Id);

            if (updateVendor == null)
                throw new ArgumentNullException("Id", "There is no vendor with this id");

            updateVendor.Address = request.Address;
            updateVendor.City = request.City;
            updateVendor.State = request.State;
            updateVendor.Discount = request.Discount;
            updateVendor.TaxId = request.TaxId;

            dbContext.Vendors.Update(updateVendor);

            return await dbContext.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
