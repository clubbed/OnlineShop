using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain
{
    public class AuditEntity
    {
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
