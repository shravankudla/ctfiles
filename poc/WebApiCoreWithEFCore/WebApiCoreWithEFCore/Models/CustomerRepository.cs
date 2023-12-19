using System.Reflection;

namespace WebApiCoreWithEFCore.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        DN16DecContext context = new DN16DecContext();
        public Customer AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            int result = context.SaveChanges();
            if (result > 0)
                return customer;
            else
                return null;
        }

        public int DeleteCustomer(int id)
        {
            Customer existingCutsomer = context.Customers.FirstOrDefault(cust => cust.CustomerId == id);
            int result = 0;
            if (existingCutsomer != null)
            {
                context.Customers.Remove(existingCutsomer);
                result = context.SaveChanges();
            }
            return result;
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.FirstOrDefault(cust => cust.CustomerId == id);
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            Customer existingCutsomer = context.Customers.FirstOrDefault(cust => cust.CustomerId == id);
            if(existingCutsomer!=null)
            {
                existingCutsomer.FirstName = customer.FirstName;
                existingCutsomer.LastName = customer.LastName;
                existingCutsomer.Address = customer.Address;
                existingCutsomer.ContactNo = customer.ContactNo;
                int result = context.SaveChanges();
                if(result>0)
                    return existingCutsomer;
            }
            return null;
        }
    }
}
