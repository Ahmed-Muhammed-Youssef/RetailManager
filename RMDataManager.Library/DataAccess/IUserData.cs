using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUserById(string id);
    }
}