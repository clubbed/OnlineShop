using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Queries.Order;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Order
{
    public class GetMyOrdersQueryHandler : IRequestHandler<GetMyOrdersQuery, IResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetMyOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IResponse> Handle(GetMyOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllByUserAsync(request.UserId);

            if (orders == null || !orders.Any())
                return new NotFoundResponse();

            return new OkResponse<List<OrderVm>>(orders);
        }
    }
}
