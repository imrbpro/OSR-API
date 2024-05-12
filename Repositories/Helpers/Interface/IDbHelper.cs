using System.Data;
using System.Data.SqlClient;

namespace Repositories.Helpers.Interface
{
    public interface IDbHelper
    {
        Task<DataTable> Get(string sp, SqlParameter[] parameters);
        Task<DataTable> Get(string query);
        string GetBy(string sp, SqlParameter[] parameters);
        bool ExecuteNonQuery(string sp, SqlParameter[] parameters);
        bool ExecuteNonQuery(string query);
        void Dispose();
        void RollbackTransaction();


    }
}
