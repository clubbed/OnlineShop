using MediatR;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;

namespace OnlineShop.Application.Queries.Product
{
    //public class GetProductByIdQuery : IRequest<ProductVM>
    public class GetProductByIdQuery : IRequest<IResponse>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
