using Models;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class UserService: IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public bool IsUserExists(string email)
        {
            return _userRepository.IsUserExists(email);
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
