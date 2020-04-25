using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.Vendor
{
    public class CreateVendorCommand : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Discount { get; set; }
        public int TaxId { get; set; }
    }
}
