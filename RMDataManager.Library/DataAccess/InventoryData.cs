using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class InventoryData : IInventoryData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public InventoryData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public async Task<List<InventoryModel>> GetInventory()
        {
            return await sqlDataAccess.LoadData<InventoryModel>("dbo.spInventoryGetAll", new { }, "RMData");
        }
        public async Task<int> SaveInventoryRecord(InventoryModel inventory)
        {
            return await sqlDataAccess.SaveData("dbo.spInventoryInsert", inventory, "RMData");
        }
    }
}
