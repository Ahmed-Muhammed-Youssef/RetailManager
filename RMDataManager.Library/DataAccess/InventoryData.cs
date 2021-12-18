using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public class InventoryData
    {
        private readonly SqlDataAccess sqlDataAccess;
        public InventoryData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);
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
