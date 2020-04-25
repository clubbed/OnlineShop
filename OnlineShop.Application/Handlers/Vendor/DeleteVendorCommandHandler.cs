using MediatR;
using OnlineShop.Application.Commands.Vendor;
using OnlineShop.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Vendor
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, bool>
    {
        private readonly IShopDbContext dbContext;

        public DeleteVendorCommandHandler(IShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var deleteVendor = await dbContext.Vendors.FindAsync(request.Id);

            if (deleteVendor == null)
                throw new ArgumentNullException("Id", "There is no vendor with this id");

            dbContext.Vendors.Remove(deleteVendor);

            return await dbContext.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
