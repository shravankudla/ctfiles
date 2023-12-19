using BankServiceLayer;
using EntityClassesLib;
using loggerLib;
using System;
using System.Text;
namespace BusinessLogic
{
    public class BusinessLogic1
    {
        private BankServiceLayer1 bs = new BankServiceLayer1();
        private Filelogger filelogger=new Filelogger();
        public List<RevisedCustomer> ObtainAllCustomerList()
        {
            using (filelogger) 
            { 
            this.filelogger.Log("ObtainAllCustomers() called at: " + DateTime.Now);
        }//this.filelogger.Dispose();

                List<Customer> customers = bs.HttpGetAllCustomers();
                List<RevisedCustomer> result = new List<RevisedCustomer>();
                foreach(Customer cm in customers)
                {
                   RevisedCustomer rc = new RevisedCustomer();
                   rc.CID = cm.CustomerId;
                   rc.CName = cm.CustomerName.ToUpper();
                   rc.Address = cm.Address.City +" " +cm.Address.State;
                   result.Add(rc);
                }
                return result;
        }
    
        public void  InsertCustomer(int cid, string cname, string city, string state,string email)
        {
            using (filelogger)
            {
                this.filelogger.Log("InsertCustomer() called at: " + DateTime.Now);
            }
            //this.filelogger.Dispose();
            //List<Customer> customers = bs.HttpGetAllCustomers();
            Customer hah=new Customer();
            // foreach(Customer c in customers)
            // {
            //     if(c.CustomerId == cid)
            //     {
            //         throw new Exception("Kyaa kar raha hein bsdk");
            //     }
            // }
            CustomerAddress ca = new CustomerAddress();
            ca.City = city;
            ca.State = state;
            hah.CustomerId = cid;
            hah.CustomerName = cname;
            hah.Email = email;
            hah.Address=ca;

            bs.HttpPostCustomer(hah);
        }
        public void ModifyCustomer(int cid, string newname, string newcity, string newstate,string email)
        {
            using (filelogger)
            {
                this.filelogger.Log("ModifyCustomer() called at: " + DateTime.Now);
            }
            List<Customer> customers = bs.HttpGetAllCustomers();
           // List<RevisedCustomer> result = new List<RevisedCustomer>();
            
            foreach(Customer cm in customers)
            {
                if(cm.CustomerId==cid)
                {
                    //RevisedCustomer rc = new RevisedCustomer();
                    cm.CustomerId = cid;
                    cm.CustomerName=newname;
                    cm.Email= email;
                    CustomerAddress ca = new CustomerAddress();
                    ca.City = newcity;
                    ca.State = newstate;
                    
                    cm.Address=ca;
                    bs.PutCustomer(cid,cm);
                    break;
                    //result.Add(rc);
                }
                else
                {
                    throw new Exception("Customer ID not found");
                }
            }
            
        }
        public void RemoveCustomer(int cid)
        {
            using (filelogger)
            {
                this.filelogger.Log("RemoveCustomer() called at: " + DateTime.Now);
            }
            bs.DeleteCustomer(cid);
        }
        public void PersistData()
        {
            this.bs.PersistData();
        }
        public void ReadData()
        {
            this.bs.ReadData();
        }
        public List<Account> GetAccId(int id)
        {
            return this.bs.GetAccId(id);
        }
        public List<Account> GetAccType(AccountType type)
        {
            return this.bs.GetAccType(type);
        }
        public string CreateAcc(int accid,int cid,int acctype,int bal)
        {
            Account acc = new Account();
            AccountType at;
            acc.AccountId = accid;
            acc.CustomerId = cid;
            at = (AccountType)acctype;
            acc.AccType = at;
            acc.Balance = bal;
            return this.bs.CreateAcc(acc);
        }
        public double Transaction(string transaction, int accid, double amt)
        {
            return this.bs.Transaction(transaction, accid, amt);
        }

    }
    public class RevisedCustomer
    {
        public int CID { get; set; }
        public string CName { get; set;}
        public string Address { get; set; }
        public override string ToString()
        {
            // string
            // details = this.CID.ToString();
            // details += ", " +this.CName;
            // details += ", " +this.Address;
            // return details;
            StringBuilder sb = new StringBuilder();
                    sb.Append("Customer Id:" +this.CID);
                    sb.Append("\nCustomer Name:" +this.CName);
                    sb.Append("\nCustomer City & State:" +this.Address);
                    return sb.ToString();
        }
    }
}