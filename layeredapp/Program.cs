using loggerLib;
using DAL;
using EntityClassesLib;
using BankServiceLayer;
using BusinessLogic;

namespace TestingApp
{
    class Program{
        static void Main()
        {
            // ILogger filelogger=new Filelogger();
            // filelogger.Log("");
            // using(ILogger filelogger = new Filelogger())
            // {
            //     filelogger.Log("Hello");
            // }
            //-------------
            // BusinessLogic1 bl = new BusinessLogic1();
            // bl.InsertCustomer(1,"customer1","TN","Chennai");
            // bl.InsertCustomer(1,"customer 2","MH","Mumbai");
            //-----------
            BusinessLogic1 bl = new BusinessLogic1();

                bl.InsertCustomer(1, "customer1", "Mumbai", "MAH");

                bl.InsertCustomer(2, "customer2", "Chennai", "TN");

                bl.InsertCustomer(3, "customer3", "Mangalore", "TL");
            

            //bl.InsertCustomer(3, "customer3", "Chennai", "TN");
            //------------
            // Customer c1 = new Customer();
            // c1.CustomerId = 1;

            // CustomerAddress c1address = new CustomerAddress();

            // c1address.City = "BANGALORE";
            // c1address.State = "KARNATAKA";
            // c1.CustomerName = "Customer1";
            // c1.Address = c1address;

            
            // Customer c2 = new Customer();
            // c2.CustomerId = 2;
            // c2.CustomerName = "Customer2";
            // CustomerAddress c2address = new CustomerAddress();
            // c2address.City = "CHENNAI";
            // c2address.State = "TN";
            // c2.Address = c2address;
            // b1.ObtainAllCustomerList();
            // bl.HttpPostCustomer(c2);
           List<RevisedCustomer> customers = bl.ObtainAllCustomerList();
            foreach(var c in customers)
            {
                Console.WriteLine("Customer id: {0}", c.CID);
                Console.WriteLine("Customer name: {0}", c.CName);
                Console.WriteLine("Address: {0}", c.Address);
                Console.WriteLine();
            }
            //-----------
            bl.ModifyCustomer(1,"Cust 2","Pune","MH");
            List<RevisedCustomer> customer = bl.ObtainAllCustomerList();
            foreach(var c in customer)
            {
                Console.WriteLine("Customer id: {0}", c.CID);
                Console.WriteLine("Customer name: {0}", c.CName);
                Console.WriteLine("Address: {0}", c.Address);
                Console.WriteLine();
            }
            bl.RemoveCustomer(1);
            List<RevisedCustomer> cust = bl.ObtainAllCustomerList();
            foreach(var c in cust)
            {
                Console.WriteLine("Customer id: {0}", c.CID);
                Console.WriteLine("Customer name: {0}", c.CName);
                Console.WriteLine("Address: {0}", c.Address);
                Console.WriteLine();
            }
            //-------
        //    IDataAccess dataaccess = new CustomerCollectionRepo();

        //     Customer c1 = new Customer();

        //     c1.CustomerId = 1;

        //     CustomerAddress c1address = new CustomerAddress();

        //     c1address.City = "BANGALORE";

        //     c1address.State = "KARNATAKA";




        //     c1.CustomerName = "Customer1";

        //     c1.Address = c1address;



        //     Customer c2 = new Customer();

        //     c2.CustomerId = 2;

        //     c2.CustomerName = "Customer2";

        //     CustomerAddress c2address = new CustomerAddress();

        //     c2address.City = "CHENNAI";

        //     c2address.State = "TN";

        //     c2.Address = c2address;



        //     dataaccess.AddNewCustomer(c1);

        //     dataaccess.AddNewCustomer(c2);



        //     foreach(Customer c in dataaccess.GetAllCustomers())

        //     {

        //         Console.WriteLine(c.CustomerId);

        //         Console.WriteLine(c.CustomerName);

        //         Console.WriteLine(c.Address.City);

        //         Console.WriteLine(c.Address.State);

        //         Console.WriteLine();

        //     }




        //     //dataaccess.EditCustomer(100, c1);



        //     c1.CustomerName = "***";

        //     dataaccess.EditCustomer(1, c1);



        //     foreach(Customer c in dataaccess.GetAllCustomers())

        //     {

        //         Console.WriteLine(c.CustomerId);

        //         Console.WriteLine(c.CustomerName);

        //         Console.WriteLine(c.Address.City);

        //         Console.WriteLine(c.Address.State);

        //         Console.WriteLine();

        //     }
        //     dataaccess.DeleteCustomer(1);
        }
    }
}