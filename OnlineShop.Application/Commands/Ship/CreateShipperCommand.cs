using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.Ship
{
    public class CreateShipperCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<int> ShippingTypes { get; set; }
    }
}
