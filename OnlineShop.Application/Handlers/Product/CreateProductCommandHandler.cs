using MediatR;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, object>
    {
        private readonly IShopDbContext dbContext;
        private readonly IUploadImageService _imageService;

        public CreateProductCommandHandler(IShopDbContext dbContext,
            IUploadImageService imageService)
        {
            this.dbContext = dbContext;
            _imageService = imageService;
        }

        public async Task<object> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            string imagePath = string.Empty;

            if (request.Image != null)
                imagePath = await _imageService.UploadAsync(request.Image);

            var product = new OnlineShop.Domain.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                MeasureUnitId = request.MeasureUnit,
                VendorId = request.Vendor,
                Qty = request.Qty,
                ImagePath = imagePath,
                Active = true
            };

            try
            {
                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();

                return new { message = "Succesfuly created product" };
            }
            catch (Exception ex)
            {
                return new { error = ex.Message };
            }

        }
    }
}
