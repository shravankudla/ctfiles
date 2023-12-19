using System;
using System.Collections.Generic;

namespace WebApiCoreWithEFCore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Projects = new HashSet<Project>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public double Salary { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual EmployeesAddress EmployeesAddress { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
