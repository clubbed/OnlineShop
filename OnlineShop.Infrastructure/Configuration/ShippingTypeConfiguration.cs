using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Configuration
{
    public class ShippingTypeConfiguration : IEntityTypeConfiguration<ShippingType>
    {
        public void Configure(EntityTypeBuilder<ShippingType> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Label).IsRequired();

            builder.HasData(new[]
            {
                new ShippingType{ Id = 1, Label = "Toke"},
                new ShippingType{ Id = 2, Label = "Ajer"},
            });
        }
    }
}
