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
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }

        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
