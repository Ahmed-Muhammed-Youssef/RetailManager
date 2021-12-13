using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library
{
    internal class SqlDataAccess : IDisposable
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public List<T> LoadData<T>(string storedProcedure, object parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection
                    .Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure)
                    .AsList();
            }
        } 
        public void SaveData(string storedProcedure, object parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public void OpenTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

        }

        public void SaveDataInTransaction(string storedProcedure, object parameters)
        {
                _connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
        public List<T> LoadDataInTransaction<T>(string storedProcedure, object parameters)
        {
            return _connection
                  .Query<T>(storedProcedure, parameters,
                  commandType: CommandType.StoredProcedure, transaction: _transaction)
                  .AsList();
        }
        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();

        }
        public void RollbackTransasction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public void Dispose()
        {
            CommitTransaction();
        }
    }
}
