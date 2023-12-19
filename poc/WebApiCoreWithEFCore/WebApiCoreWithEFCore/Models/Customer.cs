using System;
using System.Collections.Generic;

namespace WebApiCoreWithEFCore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public long ContactNo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
