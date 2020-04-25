using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IShopDbContext
    {
        DbSet<AppOption> AppOptions { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Tax> Taxes { get; set; }
        DbSet<MeasureUnit> MeasureUnits { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Vendor> Vendors { get; set; }
        DbSet<Shipper> Shippers { get; set; }
        DbSet<ShippingType> ShippingTypes { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        //DbSet<Stock> Stocks { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetails> OrderDetails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
