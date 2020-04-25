using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
