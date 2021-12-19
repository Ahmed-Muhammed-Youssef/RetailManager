using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public UserData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public List<UserModel> GetUserById(string id)
        {
            return sqlDataAccess.LoadData<UserModel>("dbo.spUserLookup", new { Id = id }, "RMData");
        }
    }
}
