using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess.Internal.DataAccess
{
    public class UserData
    {
        private readonly SqlDataAccess sqlDataAccess;
        public UserData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);
        }
        public List<UserModel> GetUserById(string id)
        {
            return sqlDataAccess.LoadData<UserModel>("dbo.spUserLookup", new { Id = id }, "RMData");
        }
    }
}
