using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public class InventoryData : IInventoryData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public InventoryData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public List<InventoryModel> GetInventory()
        {
            return sqlDataAccess.LoadData<InventoryModel>("dbo.spInventoryGetAll", new { }, "RMData");
        }
        public void SaveInventoryRecord(InventoryModel inventory)
        {
            sqlDataAccess.SaveData("dbo.spInventoryInsert", inventory, "RMData");
        }
    }
}
