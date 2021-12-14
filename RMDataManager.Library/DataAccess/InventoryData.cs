using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
