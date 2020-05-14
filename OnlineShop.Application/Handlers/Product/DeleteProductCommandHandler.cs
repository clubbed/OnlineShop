using MediatR;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Response;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResponse>
    {
        private readonly IShopDbContext _dbContext;
        public DeleteProductCommandHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productDelete = await _dbContext.Products.FindAsync(request.Id);

            if (productDelete == null)
                return new NotFoundResponse();

            _dbContext.Products.Remove(productDelete);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if(result)
            {
                return new OkResponse<string>("Succesfuly removed product");
            }
            else
            {
                return new BadResponse("Something went wrong while removing product");
            }
        }
    }
}
