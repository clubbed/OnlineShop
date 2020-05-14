using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using System;

namespace OnlineShop.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new[]
{
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()},
                new Role { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER", ConcurrencyStamp = Guid.NewGuid().ToString()}
            });
        }
    }
}
