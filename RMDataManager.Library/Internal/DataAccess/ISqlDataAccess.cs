using System.Collections.Generic;

namespace RMDataManager.Library
{
    public interface ISqlDataAccess
    {
        void CommitTransaction();
        void Dispose();
        string GetConnectionString(string name);
        List<T> LoadData<T>(string storedProcedure, object parameters, string connectionStringName);
        List<T> LoadDataInTransaction<T>(string storedProcedure, object parameters);
        void OpenTransaction(string connectionStringName);
        void RollbackTransasction();
        void SaveData(string storedProcedure, object parameters, string connectionStringName);
        void SaveDataInTransaction(string storedProcedure, object parameters);
    }
}