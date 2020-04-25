using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
}
