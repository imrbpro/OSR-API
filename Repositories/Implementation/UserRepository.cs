using Models;
using Repositories.Helpers.Implementation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interface;
using Repositories.Helpers.Interface;

namespace Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbHelper _dbHelper;

        public UserRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool AddUser(User user)
        {
            string sp = "spCreateUser";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Role", user.Role),
            };
            return _dbHelper.ExecuteNonQuery(sp, parameters);
        }

        public bool UpdateUser(User user)
        {
            string sp = "spUpdateUser";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Role", user.Role),
            };
            return _dbHelper.ExecuteNonQuery(sp, parameters);
        }

        public bool DeleteUser(int id)
        {
            string sp = "spDeleteUser";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            return _dbHelper.ExecuteNonQuery(sp, parameters);
        }

        public IEnumerable<User> GetAll()
        {
            string sp = "spGetAllUsers";

            var dataTable = _dbHelper.Get(sp, null);

            if (dataTable == null || dataTable.Result.Rows.Count == 0)
            {
                yield return null;
            }

            foreach (DataRow row in dataTable.Result.Rows)
            {

                yield return new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Email = row["Email"].ToString(),
                    Role = row["Role"].ToString()
                };
            }

        }

        public bool IsUserExists(string email)
        {
            string sp = "spCheckUserExists";
            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter( "@Email", email )
            };
            bool IsExist = _dbHelper.ExecuteNonQuery(sp, parameter);
            return IsExist;
        }
    }
}
