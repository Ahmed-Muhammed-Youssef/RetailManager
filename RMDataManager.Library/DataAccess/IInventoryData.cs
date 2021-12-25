using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        Task<List<InventoryModel>> GetInventory();
        Task<int> SaveInventoryRecord(InventoryModel inventory);
    }
}