using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Behaviors;
using OnlineShop.Application.Caching;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Repositories.MeasureUnit;
using OnlineShop.Application.Repositories.Order;
using StackExchange.Redis;
using System;
using System.Reflection;

namespace OnlineShop.Application
{
    public static class ApplicationDependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("OnlineShop.Application");

            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(assembly);

            services.AddSingleton<IConnectionMultiplexer>(c => ConnectionMultiplexer.Connect("localhost:6379"));
            services.AddSingleton<ICacheService, RedisCacheService>();

            services.AddScoped<IMeasureUnitRepository, MeasureUnitRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
