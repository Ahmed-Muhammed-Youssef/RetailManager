using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library
{
    public interface ISqlDataAccess
    {
        void CommitTransaction();
        void Dispose();
        string GetConnectionString(string name);
        Task<List<T>> LoadData<T>(string storedProcedure, object parameters, string connectionStringName);
        Task<List<T>> LoadDataInTransaction<T>(string storedProcedure, object parameters);
        void OpenTransaction(string connectionStringName);
        void RollbackTransasction();
        Task<int> SaveData(string storedProcedure, object parameters, string connectionStringName);
        Task<int> SaveDataInTransaction(string storedProcedure, object parameters);
    }
}