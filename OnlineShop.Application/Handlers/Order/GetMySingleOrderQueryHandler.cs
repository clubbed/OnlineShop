using MediatR;
using OnlineShop.Application.Queries.Order;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Order
{
    class GetMySingleOrderQueryHandler : IRequestHandler<GetMySingleOrderQuery, IResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetMySingleOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IResponse> Handle(GetMySingleOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository
                .GetSingleByUserAsync(request.Id, request.UserId);

            if (order == null)
                return new NotFoundResponse();

            return new OkResponse<OrderVm>(order);
        }
    }
}
