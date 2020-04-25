using MediatR;

namespace OnlineShop.Application.Commands.Vendor
{
    public class DeleteVendorCommand : IRequest<bool>
    {
        public DeleteVendorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
