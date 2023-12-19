using EFDAL;
namespace ServiceLayer
{
    public class ServiceLayerr: IServiceLayer
    {
        private readonly IUserRepo userRepo;

        public ServiceLayerr(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        public User AddUser(User user)
        {
            return userRepo.AddUser(user);
        }

        public User[] GetAllUsers()
        {
            return userRepo.GetAllUsers();
        }

        public User UpdateUsers(int uid, string password)
        {
            return userRepo.UpdateUsers(uid, password);
        }

        public User GetSingleUser(int uid)
        {
            return userRepo.GetSingleUser(uid);
        }

        public User DeleteUser(int uid)
        {
            return userRepo.DeleteUser(uid);
        }

        public User[] GetUserByName(string name)
        {
            return userRepo.GetUserByName(name);
        }
    }
}