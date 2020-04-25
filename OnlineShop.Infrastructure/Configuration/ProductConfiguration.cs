using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.MeasureUnitId).IsRequired();
            builder.HasOne(c => c.MeasureUnit);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Qty).HasColumnType("numeric(18,5)").IsRequired();
            builder.Property(c => c.Price).HasColumnType("numeric(18,5)").IsRequired();

            //builder.Property(c => c.ShipperId).IsRequired();
            //builder.HasOne(c => c.Shipper);

            //builder.Property(c => c.VendorId).IsRequired();
            //builder.HasOne(c => c.Vendor);

            //builder.HasOne(c => c.Stock)
            //    .WithOne(s => s.Product)
            //    .HasForeignKey<Product>(c => c.StockId)
            //    //.HasForeignKey<Stock>(c => c.Id)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
