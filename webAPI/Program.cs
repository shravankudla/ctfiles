using ContactsLib;

namespace ConsoleApp1
{
    public class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("creating database");
            ContactContext dbcontext = new ContactContext();
            dbcontext.Database.EnsureCreated();
            Console.WriteLine("created database");
            
        }
    }
}
