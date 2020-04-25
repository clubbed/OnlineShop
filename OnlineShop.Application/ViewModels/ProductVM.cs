using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MeasureUnit { get; set; }
        public string Vendor { get; set; }
        public string Shipper { get; set; }
        public decimal Qty { get; set; }
        public bool IsFeatured { get; set; }
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
