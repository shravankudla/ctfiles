using EntityClassesLib;
namespace DAL
{
    public interface IDataAccess
    {
        List<Customer> GetAllCustomers();
        void AddNewCustomer(Customer c);

        void EditCustomer(int customerid,Customer c);

        void DeleteCustomer(int customerid);

        string CreateAccount(Account a);

        double Transaction(string transaction, int accid, double amt);


        List<Account> GetAccountsForCustomer(int cid);

        List<Account> GetAccounts(AccountType acctype);

        void PersistData();

        void ReadData();

    }
}