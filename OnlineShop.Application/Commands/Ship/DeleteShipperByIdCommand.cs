using MediatR;
using OnlineShop.Application.Response;

namespace OnlineShop.Application.Commands.Ship
{
    public class DeleteShipperByIdCommand :IRequest<IResponse>
    {
        public DeleteShipperByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
