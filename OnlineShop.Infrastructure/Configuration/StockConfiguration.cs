using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Qty).HasColumnType("numeric(18,5)").IsRequired();

            //builder.HasOne(c => c.Product)
            //    .WithOne(p => p.Stock)
            //    .HasForeignKey<Stock>(c => c.ProductId)
            //    //.HasForeignKey<Product>(c => c.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
