using System;
using System.Collections.Generic;

namespace WebApiCoreWithEFCore.Models
{
    public partial class EmployeesAddress
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;
    }
}
