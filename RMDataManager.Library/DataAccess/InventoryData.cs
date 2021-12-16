using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public class InventoryData
    {
        public List<InventoryModel> GetInventory()
        {
            var sqlDataAccess = new SqlDataAccess();

            return sqlDataAccess.LoadData<InventoryModel>("dbo.spInventoryGetAll", new { }, "RMData");
        }
        public void SaveInventoryRecord(InventoryModel inventory)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            sqlDataAccess.SaveData("dbo.spInventoryInsert", inventory, "RMData");
        }
    }
}
