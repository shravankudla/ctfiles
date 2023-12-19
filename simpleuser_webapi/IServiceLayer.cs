using EFDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServiceLayer
    {
        User AddUser(User user);
        User[] GetAllUsers();
        User UpdateUsers(int uid, string password);
        User GetSingleUser(int uid);
        User DeleteUser(int uid);
        User[] GetUserByName(string name);
    }
}
