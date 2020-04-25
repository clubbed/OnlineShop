using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Shipper : AuditEntity
    {
        public Shipper()
        {
            ShippingTypes = new HashSet<ShippingType>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public ICollection<ShippingType> ShippingTypes { get; set; }
    }
}
