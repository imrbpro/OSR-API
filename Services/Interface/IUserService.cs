using Models;

namespace Services.Interface
{
    public interface IUserService
    {
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public bool IsUserExists(string email);
        public IEnumerable<User> GetAll();
    }
}
