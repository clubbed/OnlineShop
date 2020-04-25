using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Configuration
{
    public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();

            builder.HasData(new[]
            {
                new MeasureUnit { Id = 1, Name = "Cope"},
                new MeasureUnit { Id = 2, Name = "Liter" },
                new MeasureUnit { Id = 3, Name = "Kilogram"}
            });
        }
    }
}
