﻿using Dapper;
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
    internal class SqlDataAccess
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
        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}