using System;
using System.Collections.Generic;

namespace WebApiCoreWithEFCore.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
