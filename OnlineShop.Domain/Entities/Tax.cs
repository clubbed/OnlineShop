using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Tax
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public decimal Value { get; set; }
    }
}
