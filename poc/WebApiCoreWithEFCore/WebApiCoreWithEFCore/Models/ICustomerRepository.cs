namespace WebApiCoreWithEFCore.Models
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        int DeleteCustomer(int id);
    }
}
