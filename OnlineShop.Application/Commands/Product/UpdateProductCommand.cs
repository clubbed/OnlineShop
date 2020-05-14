using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.Product
{
    public class UpdateProductCommand : IRequest<IResponse>
    {
        public int Id { get; set; }
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
