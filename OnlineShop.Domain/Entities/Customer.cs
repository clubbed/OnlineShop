using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            DeliveryAddresses = new HashSet<DeliveryAddress>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<DeliveryAddress> DeliveryAddresses { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
