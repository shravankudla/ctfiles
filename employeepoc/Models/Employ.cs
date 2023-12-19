using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public partial class Employ
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
