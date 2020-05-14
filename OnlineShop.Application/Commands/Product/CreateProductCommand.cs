using MediatR;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.Commands.Product
{
    public class CreateProductCommand : IRequest<object>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public int MeasureUnit { get; set; }
        public int Vendor { get; set; }
        public int Category { get; set; }
        public IFormFile Image { get; set; }
    }
}
