using DAL;
using EntityClassesLib;
namespace BankServiceLayer

{




    public class BankServiceLayer1

    {

          //  private CustomerCollectionRepo dal = new CustomerCollectionRepo();
        private CustomerDBRepo dal=new CustomerDBRepo();

        public List<Customer> HttpGetAllCustomers()

        {

                return this.dal.GetAllCustomers();

        }



        public void HttpPostCustomer(Customer newcustomer)

        {

            this.dal.AddNewCustomer(newcustomer);

        }



        public void PutCustomer(int custid, Customer modifiedcustomer)

        {

            this.dal.EditCustomer(custid, modifiedcustomer);

        }



        public void DeleteCustomer(int custid)

        {

            this.dal.DeleteCustomer(custid);

        }
        public void PersistData()
        {
            this.dal.PersistData();
        }
        public void ReadData()
        {
            //this.dal.ReadData();
        }
        public string CreateAcc(Account acc)
        {
            return this.dal.CreateAccount(acc);
        }
        public List<Account> GetAccId(int id)
        {
            return this.dal.GetAccountsForCustomer(id);
        }
        public List<Account> GetAccType(AccountType type)
        {
            return this.dal.GetAccounts(type);
        }
        public double Transaction(string transaction, int accid, double amt)
        {
            return this.dal.Transaction(transaction, accid, amt);
        }
    }

}