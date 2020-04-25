using MediatR;
using OnlineShop.Application.Response;

namespace OnlineShop.Application.Queries.Order
{
    public class GetAllOrdersQuery : IRequest<IResponse>
    {
    }
}
