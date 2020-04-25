using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }

        public User User { get; set; }
    }
}
