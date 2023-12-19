using EntityClassesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;
using Microsoft.VisualBasic;

namespace DAL
{
    public class CustomerDBRepo : IDataAccess
    {
        private SqlConnection conn;
        private SqlCommand comm;
        private SqlDataReader reader;
        public List<Customer> custlist = new List<Customer>();
        public List<Account> acclist = new List<Account>();

        public CustomerDBRepo()
        {
            //this.conn = new SqlConnection("server=CTAADPG038QAW\\SQLEXPRESS2019;database=cessnaDB;integrated security=true;TrustServerCertificate=true");
           this.conn = new SqlConnection("server=CTAADPG038QAW\\SQLEXPRESS2019;database=cessnaDB;uid=sa;pwd=Password_123;TrustServerCertificate=true"); 
           conn.Open();
           Console.WriteLine("Dal connected to sql sever");
        }

        public void AddNewCustomer(Customer c)
        {
            bool ab = true;
            foreach (Customer cc in custlist)
            {
                if (cc.CustomerId == c.CustomerId)
                {
                    ab = false;
                    break;
                }
            }
            if (ab == false)
            {
                throw new Exception("Customer id not found");
            }
            string sql = "insert into customers values(@cid,@cname,@city, @state, @email)";
            comm= new SqlCommand(sql);
            comm.Connection= conn;
            
            //comm.CommandType = CommandType.StoredProcedure;
            //comm.CommandText = "InsertCustomer";
            comm.Parameters.AddWithValue("@cid", c.CustomerId);
            comm.Parameters.AddWithValue("@cname",c.CustomerName);
            comm.Parameters.AddWithValue("@city", c.Address.City);
            comm.Parameters.AddWithValue("@state", c.Address.State);
            comm.Parameters.AddWithValue("@email", c.Email);

            int recordinserted=comm.ExecuteNonQuery();
            Console.WriteLine("{0} records inserted",recordinserted);
        }

        public void DeleteCustomer(int customerid)
        {
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "InsertCustomer";
            comm.Parameters.AddWithValue("@cid", customerid);
            int recorddeleted = comm.ExecuteNonQuery();
            Console.WriteLine("{0} records deleted", recorddeleted);
        }

        public void EditCustomer(int customerid, Customer c)
        {
            bool ab = false;
            foreach (Customer cc in custlist)
            {
                if (cc.CustomerId == customerid)
                {
                    ab = true;
                    break;
                }
            }
            if (ab == false)
            {
                throw new Exception("Customer id not found");
            }
            else
            {
                string edit = "update customers set customername = @cname,city = @city,state = @state,email = @email where customerid = @cid;";
                comm = new SqlCommand(edit);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@cid", c.CustomerId);
                comm.Parameters.AddWithValue("@cname", c.CustomerName);
                comm.Parameters.AddWithValue("@city", c.Address.City);
                comm.Parameters.AddWithValue("@state", c.Address.State);
                comm.Parameters.AddWithValue("@email", c.Email);

                int recordinserted = comm.ExecuteNonQuery();
                Console.WriteLine("{0} records inserted", recordinserted);

            }
        }

        public List<Customer> GetAllCustomers()
        {
            //throw new NotImplementedException();
            List<Customer> allcustomers=new List<Customer>();
            string sql = "select * from customers";
            comm = new SqlCommand(sql);
            comm.Connection = conn;     //associate command with connection



            reader = comm.ExecuteReader();
            if (reader.HasRows == false)
            {
                Console.WriteLine("No customers to show");
            }
            else
            {
                reader.Read();
                //read each now one by one and get the columns
                Customer c = new Customer();
                c.CustomerId = (int)reader["customerid"];
                c.CustomerName = reader["customername"].ToString();
                CustomerAddress ca = new CustomerAddress();
                ca.City = reader["city"].ToString();
                ca.State = reader["state"].ToString();
                c.Address = ca;
                allcustomers.Add(c);
            }
            reader.Close();
            return allcustomers;
        }

        public void PersistData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            if (this.conn != null)
            {
                conn.Close();
                Console.WriteLine("Sql connection closed");
            }
        }

        public string CreateAccount(Account a)
        {
            bool ab=false;
            foreach(Customer c in custlist)
            {
                if(c.CustomerId==a.CustomerId)
                {
                    ab = true; 
                    break;
                }
            }
            if (ab == false)
            {
                throw new Exception("Customer id not found");
            }
            else
            {
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "CreateAccount";
                comm.Parameters.AddWithValue("@aid", a.AccountId);
                comm.Parameters.AddWithValue("@ciid", a.CustomerId);
                comm.Parameters.AddWithValue("@aid", a.AccType);
                comm.Parameters.AddWithValue("@bal", a.Balance);
                comm.ExecuteNonQuery();
                return "Account Created";
            }
        }

        public double Transaction(string transaction, int accid, double amt)
        {
            string sql = "select * from accounts";
            comm = new SqlCommand(sql);
            comm.Connection = conn;
            double bal=0.0;

            reader = comm.ExecuteReader();
            //read each now one by one and get the columns
            if (accid == (int)reader["accid"])
            {
                bal = (double)reader["balance"];
            }
            if(transaction=="deposit")
            {
                bal += amt;
            }
            else
            {
                bal -= amt;
            }
            string update = "update accounts balance=@bal where accid=@accid";
            comm = new SqlCommand(update);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@bal",bal );
            comm.Parameters.AddWithValue("@cname",accid);

            comm.ExecuteNonQuery();
            return bal;
        }


        public List<Account> GetAccountsForCustomer(int cid)
        {
            List<Account> ac = new List<Account>();
            string sql = "select * from accounts";
            comm = new SqlCommand(sql);
            comm.Connection = conn;

            reader = comm.ExecuteReader();
            if (reader.HasRows == false)
            {
                Console.WriteLine("NO ACCOUNTS FOUND");
            }

            else
            {
                if (cid == (int)reader["customerid"])
                {
                    Account acc = new Account();
                    acc.AccountId = (int)reader["accid"];
                    acc.CustomerId = (int)reader["customerid"];
                    acc.Balance = (double)reader["balance"];
                    acc.AccType = (AccountType)reader["balance"];
                    ac.Add(acc);
                }

                reader.Close();
                
            }
            return ac;
        }

        public List<Account> GetAccounts(AccountType acctype)
        {
            List<Account> ac = new List<Account>();
            string sql = "select * from accounts";
            comm = new SqlCommand(sql);
            comm.Connection = conn;

            reader = comm.ExecuteReader();
            if (reader.HasRows == false)
            {
                Console.WriteLine("NO ACCOUNTS FOUND");
            }

            else
            {
                if (acctype == (AccountType)reader["balance"])
                {
                    Account acc = new Account();
                    acc.AccountId = (int)reader["accid"];
                    acc.CustomerId = (int)reader["customerid"];
                    acc.Balance = (double)reader["balance"];
                    acc.AccType = (AccountType)reader["balance"];
                    ac.Add(acc);
                }

                reader.Close();

            }
            return ac;
        }

    }
}
