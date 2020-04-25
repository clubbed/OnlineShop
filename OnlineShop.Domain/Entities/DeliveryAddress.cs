using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Active { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
