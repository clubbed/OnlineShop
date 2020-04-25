using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Product : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public int MeasureUnitId { get; set; }
        public int? VendorId { get; set; }
        public string ImagePath { get; set; }
        public bool IsFeatured { get; set; }
        public bool Active { get; set; }
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
        public Vendor Vendor { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
    }
}
