using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Infrastructure.Utility;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Infrastructure
{
    public static class InfrastructureDependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddIdentity<User,Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ShopDbContext>();

            //services.AddIdentityCore<User>()
            //    .AddRoles<Role>().AddEntityFrameworkStores<ShopDbContext>();

            var dataSettings = DataSettings.GetDataSettings();
            
            services.AddDbContext<ShopDbContext>(options =>
            {
                switch (dataSettings.Active)
                {
                    case "MySQL":
                        options.UseMySql(configuration.GetConnectionString("MySQL"));
                        break;
                    case "PostgreSQL":
                        options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
                        break;
                    default:
                        //options.UseSqlServer(connectionString);
                        options.UseSqlServer(configuration.GetConnectionString("OnlineShop"));
                        break;
                }

            });

            services.AddScoped<IShopDbContext>(provider => provider.GetRequiredService<ShopDbContext>());
            services.AddAuthentication();

            return services;
        }
    }
}
