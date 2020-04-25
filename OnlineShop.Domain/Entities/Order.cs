using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Order : AuditEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
