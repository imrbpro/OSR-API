using Repositories.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Repositories.Helpers.Implementation
{
    public class DbHelper: IDbHelper
    {

        #region Private Variables
        private readonly IConfiguration _configuration;
        private SqlConnection _connection;
        private string _connectionString;
        private SqlCommand cmd;
        private DbTransaction _transaction;
        #endregion
        public DbHelper(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("osr_db");
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public bool ExecuteNonQuery(string sp, SqlParameter[] parameters)
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                using (var connection = _connection)
                {
                    cmd = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = sp
                    };
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    _connection.Open();
                    if (cmd.ExecuteNonQuery() > 0) 
                    {
                        Dispose(); 
                        return true; 
                    }
                    else 
                    { 
                        Dispose(); 
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return false;
            }
        }

        public bool ExecuteNonQuery(string query)
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                using (var connection = _connection)
                {
                    cmd = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = query
                    };
                    _connection.Open();
                    if (cmd.ExecuteNonQuery() > 0) { Dispose(); return true; } else { Dispose(); return false; }
                }
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return false;
            }
        }

        public async Task<DataTable> Get(string sp, SqlParameter[] parameters)
        {
            try
            {

                _connection = new SqlConnection(_connectionString);
                DataTable _Dt = new DataTable();
                using (var connection = _connection)
                {
                    cmd = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = sp
                    };
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    _connection.Open();
                    _Dt.Load(cmd.ExecuteReader());
                    Dispose();
                }
                return _Dt;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return null;
            }


        }

        public async Task<DataTable> Get(string query)
        {
            try
            {

                _connection = new SqlConnection(_connectionString);
                DataTable _Dt = new DataTable();
                using (var connection = _connection)
                {
                    cmd = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = query
                    };
                    _connection.Open();
                    _Dt.Load(cmd.ExecuteReader());
                    Dispose();
                }
                return _Dt;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return null;
            }
        }

        public string GetBy(string sp, SqlParameter[] parameters)
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                DataTable _Dt = new DataTable();
                using (var connection = _connection)
                {
                    cmd = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = sp
                    };
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    _connection.Open();
                    _Dt.Load(cmd.ExecuteReader());
                    Dispose();
                }
                return _Dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return "";
            }

        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                return;
            }
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }
                _transaction = null;
            }
        }
    }
}
