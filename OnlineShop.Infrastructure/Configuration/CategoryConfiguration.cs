using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.ParentCategory)
                .WithOne().HasForeignKey<Category>(c => c.ParentCategoryId)
                .IsRequired(false);

            builder.HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(new[]
            {
                new Category{ Id = 1, Name = "Technology"},
                new Category{ Id = 2, Name = "Fashion"},
                new Category{ Id = 3, Name = "Kids"},
                new Category{ Id = 4, Name = "Food"},
            });

        }
    }
}
