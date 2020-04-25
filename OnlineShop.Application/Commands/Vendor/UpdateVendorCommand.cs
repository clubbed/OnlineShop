using MediatR;

namespace OnlineShop.Application.Commands.Vendor
{
    public class UpdateVendorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Discount { get; set; }
        public int TaxId { get; set; }

    }
}
