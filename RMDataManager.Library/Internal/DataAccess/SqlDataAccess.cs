using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RMDataManager.Library
{
    public class SqlDataAccess : IDisposable, ISqlDataAccess
    {
        public SqlDataAccess(IConfiguration configuration, ILogger<SqlDataAccess> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public string GetConnectionString(string name)
        {
            return configuration.GetConnectionString(name);
        }
        public async Task<List<T>> LoadData<T>(string storedProcedure, object parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var query = await connection
                    .QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return query.AsList();
            }
        }
        public async Task<int> SaveData(string storedProcedure, object parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            int rowsAffected;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                rowsAffected = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return rowsAffected;
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool isClosed = false;
        private readonly IConfiguration configuration;
        private readonly ILogger<SqlDataAccess> logger;

        public void OpenTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            isClosed = false;

        }

        public async Task<int> SaveDataInTransaction(string storedProcedure, object parameters)
        {
            return await _connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
            
        }
        public async Task<List<T>> LoadDataInTransaction<T>(string storedProcedure, object parameters)
        {
            var query = await _connection
                  .QueryAsync<T>(storedProcedure, parameters,
                  commandType: CommandType.StoredProcedure, transaction: _transaction);
            return query.AsList();
        }
        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
            isClosed = true;

        }
        public void RollbackTransasction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    CommitTransaction();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Transaction Failed in the dispose method");                   
                }
            }
            _transaction = null;
            _connection = null;
        }
    }
}
