namespace Employee.Models
{
    public class MyEmployeeRepo : IEmployeeRepo
    {
        POCContext context=new POCContext();
        public void Add(Employ employee)
        {
            context.Add(employee);
            context.SaveChanges();
        }

        public void Delete(Employ employee)
        {
            Employ exemployee = context.Employees.FirstOrDefault(emp=>emp.EmployeeId==employee.EmployeeId);
            if(exemployee!=null)
            {
                context.Employees.Remove(exemployee);
                context.SaveChanges();
            }
        }

        public void Edit(Employ employee)
        {
            Employ exemployee = context.Employees.FirstOrDefault(emp => emp.EmployeeId == employee.EmployeeId);
            if (exemployee != null)
            {
                exemployee.FirstName=employee.FirstName;
                exemployee.LastName=employee.LastName;
                exemployee.Salary=employee.Salary;
                exemployee.DepartmentId=employee.DepartmentId;
            }
        }
        public Employ EmployeeGet(int id)
        {
            //Employee exemployee = 
            return context.Employees.FirstOrDefault(emp => emp.EmployeeId == id);
            /*if (exemployee != null)
            {
                return exemployee;
            }
            else
                return null;*/
        }

        public List<Employ> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employ GetByDept(int deptId)
        {
            return context.Employees.FirstOrDefault(emp => emp.DepartmentId == deptId);
        }
    }
}
