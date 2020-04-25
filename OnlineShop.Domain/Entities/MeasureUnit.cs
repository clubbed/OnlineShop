using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Entities
{
    public class MeasureUnit : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
