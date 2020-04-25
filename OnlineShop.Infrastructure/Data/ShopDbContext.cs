using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data
{
    public class ShopDbContext 
        : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
        IShopDbContext
    {
        //private readonly ICurrentUserService _currentUser;

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            //ICurrentUserService currentUser)
            : base(options)
        {
            //_currentUser = currentUser;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        //public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<AppOption> AppOptions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new DeliveryAddressConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new MeasureUnitConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailsConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ShipperConfiguration());
            builder.ApplyConfiguration(new ShippingTypeConfiguration());
            //builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new TaxConfiguration());
            builder.ApplyConfiguration(new VendorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUser.Id;
                        entry.Entity.CreatedBy = 0;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.ModifiedBy = _currentUser.Id;
                        entry.Entity.ModifiedBy = 0;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
