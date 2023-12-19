namespace Employee.Models
{
    public interface IEmployeeRepo
    {
        List<Employ> GetAll();
        Employ EmployeeGet(int id);
        void Add(Employ employee);
        void Edit(Employ employee);
        void Delete(Employ employee);
        Employ GetByDept(int deptId);
    }
}
