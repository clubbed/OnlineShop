using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.Infrastructure
{
    public static class InfrastructureDependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            string connectionString)
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

            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IShopDbContext>(provider => provider.GetRequiredService<ShopDbContext>());

            services.AddAuthentication();

            return services;
        }
    }
}
