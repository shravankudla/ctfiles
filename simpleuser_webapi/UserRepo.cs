using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL
{
    public class UserRepo : IUserRepo
    {
        private readonly MyDbContext _dbContext;

        public UserRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private static int nextuid = 1;

        public User AddUser(User user)
        {
            user.Uid = nextuid++;
            User users = new User();
            users.UserName = user.UserName;
            users.Password = user.Password;
            _dbContext.users.Add(users);
            _dbContext.SaveChanges();
            return users;
        }

        public User DeleteUser(int uid)
        {
            User res = _dbContext.users.Where((b) => b.Uid == uid).SingleOrDefault();
            if (res != null)
            {
                _dbContext.users.Remove(res);
                _dbContext.SaveChanges();
            }
            return res;
        }

        public User[] GetAllUsers()
        {
            return _dbContext.users.ToArray();
        }

        public User GetSingleUser(int uid)
        {
            User result = _dbContext.users.Where(b => b.Uid == uid).SingleOrDefault();
            return result;
        }

        public User[] GetUserByName(string name)
        {
            var userlist = _dbContext.users.Where(b => b.UserName == name);
            return userlist.ToArray();
        }

        public User UpdateUsers(int uid, string password)
        {
            User res = _dbContext.users.Find(uid);
            if (res != null)
            {
                res.Password = password;
                _dbContext.SaveChanges();
            }
            return res;
        }
    }
}
