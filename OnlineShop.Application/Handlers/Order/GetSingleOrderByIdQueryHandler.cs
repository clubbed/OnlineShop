using MediatR;
using OnlineShop.Application.Queries.Order;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Order
{
    public class GetSingleOrderByIdQueryHandler : IRequestHandler<GetSingleOrderByIdQuery, IResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetSingleOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IResponse> Handle(GetSingleOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetSingleAsync(request.Id);

            if (order == null)
                return new NotFoundResponse();

            return new OkResponse<OrderVm>(order);
        }
    }
}
