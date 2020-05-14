using MediatR;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Response;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResponse>
    {
        private readonly IShopDbContext _dbContext;
        private readonly IUploadImageService _imageService;

        public UpdateProductCommandHandler(IShopDbContext dbContext,
            IUploadImageService imageService)
        {
            _dbContext = dbContext;
            _imageService = imageService;
        }

        public async Task<IResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productUpdate = await _dbContext.Products.FindAsync(request.Id);

            if (productUpdate == null)
                return new NotFoundResponse();

            string imagePath = string.Empty;

            if (request.Image != null)
                imagePath = await _imageService.UploadAsync(request.Image);

            productUpdate.Name = request.Name;
            productUpdate.Description = request.Description;
            productUpdate.MeasureUnitId = request.MeasureUnit;
            productUpdate.VendorId = request.Vendor;
            productUpdate.Price = request.Price;
            productUpdate.Qty = request.Qty;
            productUpdate.ImagePath = imagePath;

            _dbContext.Products.Update(productUpdate);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if(result)
            {
                return new OkResponse<string>("Succesfuly updated product");
            }
            else
            {
                return new BadResponse("Something went wrong");
            }
        }
    }
}
