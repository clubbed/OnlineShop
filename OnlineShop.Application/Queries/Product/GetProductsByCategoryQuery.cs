using MediatR;
using OnlineShop.Application.Response;

namespace OnlineShop.Application.Queries.Product
{
    public class GetProductsByCategoryQuery : IRequest<IResponse>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
