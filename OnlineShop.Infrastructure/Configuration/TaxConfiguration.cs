using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Configuration
{
    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Label).IsRequired();
            builder.Property(c => c.Value).HasColumnType("numeric(18,5)").IsRequired();

            builder.HasData(new[]
            {
                new Tax { Id = 1, Label = "Vat0", Value = 0.0000m },
                new Tax { Id = 2, Label = "Vat8", Value = 8.0000m },
                new Tax { Id = 3, Label = "Vat18", Value = 18.0000m }
            });
        }
    }
}
