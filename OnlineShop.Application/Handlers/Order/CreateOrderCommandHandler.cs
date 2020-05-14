using MediatR;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Interfaces;
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
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }
        public async Task<IResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            request.InvoiceDate = DateTime.Now;
            request.UserId = _currentUserService.Id;

            var result = await _orderRepository.CreateAsync(request);

            if (result)
                return new OkResponse<string>("Succesfuly created new order");
            else
                return new BadResponse("There was something wrong with this request");
        }
    }
}
