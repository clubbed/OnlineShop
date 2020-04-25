using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineShop.Application.Queries.Order;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Order
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            if (orders == null || !orders.Any())
                return new NotFoundResponse();

            return new OkResponse<List<OrderVm>>(orders);
        }
    }
}
