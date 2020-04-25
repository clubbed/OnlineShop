using MediatR;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.CreateAsync(request);

            if (result)
                return new OkResponse<string>("Succesfuly created new order");
            else
                return new BadResponse("There was something wrong with this request");
        }
    }
}
