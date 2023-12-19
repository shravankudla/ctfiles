using EntityClassesLib;
using System.Text.Json;

namespace DAL
{
    public class CustomerCollectionRepo:IDataAccess
    {
        private List<Customer> allcustomers= new List<Customer>();

        public List<Customer> GetAllCustomers()
        {
             return this.allcustomers;
        }
        public void AddNewCustomer(Customer newcustomer)
            {
                foreach(Customer c in this.allcustomers)
                {
                    if(c.CustomerId == newcustomer.CustomerId)
                    {
                        throw new Exception("Customer already exists");
                    }
                }
                this.allcustomers.Add(newcustomer);
                Console.WriteLine("Customer added successfully");
            }
        
        public void EditCustomer(int customerid, Customer modifiedcustomer)
            {
                bool found = false;
                foreach(Customer c in this.allcustomers)
                {
                    if(c.CustomerId == customerid)
                    {
                        found = true;
                        c.Address = modifiedcustomer.Address;
                        c.CustomerName = modifiedcustomer.CustomerName;
                        break;
                    }
                }
                if(found == false)
                {
                    throw new Exception("Customer not found for editing");
                }
                Console.WriteLine("Customer edited successfully");
            }
            public void DeleteCustomer(int customerid)

            {

                //search the customer

                //if not found throw an exception

                //if found, remove the customer from the List

                //Write a LINQ query to search for a customer

                var result = this.allcustomers.Where(c =>

                                c.CustomerId == customerid).SingleOrDefault();



                if(result == null)

                {

                    throw new Exception("Customer not found for deletion");

                }

                this.allcustomers.Remove(result);

                Console.WriteLine("Customer removed successfully");



            }
        public void PersistData()
        {
            FileStream fs = new FileStream("c:\\customers.json", FileMode.Create, FileAccess.Write);

            //use jason to persist the collection
            JsonSerializer.Serialize<List<Customer>>(fs, this.allcustomers);

            //close the stream
            fs.Close();
            Console.WriteLine("Customer Data Persisted successfully");
        }

        public void ReadData()
        {
            FileStream fs = new FileStream("c:\\customers.json", FileMode.Open, FileAccess.Read);
            this.allcustomers = JsonSerializer.Deserialize<List<Customer>>(fs);
            Console.WriteLine("Customer Data Retrieved Succesfully");
        }
        public string CreateAccount()
        {
            return null;
        }

        public string CreateAccount(Account a)
        {
            throw new NotImplementedException();
        }

        public double Transaction(string transaction, int accid, double amt)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccountsForCustomer(int cid)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccounts(AccountType acctype)
        {
            throw new NotImplementedException();
        }
    }
}