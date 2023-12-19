using System;
using System.Collections.Generic;

namespace Employee.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employ>();
        }
        
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Employ> Employees { get; set; }
    }
}
