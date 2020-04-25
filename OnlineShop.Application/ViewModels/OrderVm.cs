using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels
{
    public class OrderVm
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetailsVm> OrderDetails { get; set; }
    }
}
