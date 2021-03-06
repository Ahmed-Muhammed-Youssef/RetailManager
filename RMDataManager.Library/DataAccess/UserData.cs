using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public UserData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public async Task<List<UserModel>> GetUserById(string id)
        {
            return await sqlDataAccess.LoadData<UserModel>("dbo.spUserLookup", new { Id = id }, "RMData");
        }
    }
}
