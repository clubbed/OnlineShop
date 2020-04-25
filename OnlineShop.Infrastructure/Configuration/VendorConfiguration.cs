using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Configuration
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.City).IsRequired();
            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.State).IsRequired();
            builder.Property(c => c.Discount).HasColumnType("numeric(18,5)");
            builder.HasOne(c => c.Tax);
        }
    }
}
