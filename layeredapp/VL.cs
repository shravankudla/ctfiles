using System.Text.RegularExpressions;

namespace ValidationLayer
{
    public class Validator
    {
        public static bool ValidateCustomerID(int customerid)
        {
            Regex r = new Regex(@"^\d{1,3}$");
            if (r.IsMatch(customerid.ToString()))
            {
                return true;        //validation succesful
            }
            return false;
        }
        public static bool ValidateCustomerEmail(string email)
        {
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (r.IsMatch(email))
            {
                return true;        //validation succesful
            }
            return false;
        }
    }
}