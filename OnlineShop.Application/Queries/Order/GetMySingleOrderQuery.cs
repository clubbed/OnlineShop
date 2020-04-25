using MediatR;
using OnlineShop.Application.Response;

namespace OnlineShop.Application.Queries.Order
{
    public class GetMySingleOrderQuery : IRequest<IResponse>
    {
        public GetMySingleOrderQuery(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public int Id { get; }
        public int UserId { get; }
    }
}
