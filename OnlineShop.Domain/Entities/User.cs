using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            DeliveryAddresses = new HashSet<DeliveryAddress>();
            Orders = new HashSet<Order>();
        }
        public ICollection<DeliveryAddress> DeliveryAddresses { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
