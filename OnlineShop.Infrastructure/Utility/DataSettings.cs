using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace OnlineShop.Infrastructure.Utility
{
    public class DataSettings
    {
        public string Active { get; set; }

        public static DataSettings GetDataSettings()
        {
            return new DataSettings { Active = ReadJson() };
        }

        private static string ReadJson()
        {
            //var path = @"C:\Users\Admin\source\repos\OnlineShop\OnlineShop\dataSettings.json";
            var path = @"C:\Users\interd\Source\Repos\OnlineShop\OnlineShop\appsettings.json";
            var text = File.ReadAllText(path);

            var result = JsonConvert.DeserializeObject<DataSettings>(text);

            return result.Active;
        }
    }
}
