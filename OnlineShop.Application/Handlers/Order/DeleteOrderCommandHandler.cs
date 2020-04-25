using MediatR;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Order
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.DeleteAsync(request);

            if (result)
                return new OkResponse<string>();
            else
                return new NotFoundResponse();
        }
    }
}
