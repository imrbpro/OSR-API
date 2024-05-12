using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IUserRepository
    {
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public bool IsUserExists(string email);
        public IEnumerable<User> GetAll();

    }
}
