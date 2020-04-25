using OnlineShop.Domain.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Utility
{
    public static class RedisDefaultKeys
    {
        public const string GetAllCategories = "GetAllCategories";
        public const string GetAllVendors = "GetAllVendors";
        public const string GetAllMeasureUnits = "GetAllMeasureUnits";
        public const string GetAllShippers = "GetAllShippers";

    }
}
