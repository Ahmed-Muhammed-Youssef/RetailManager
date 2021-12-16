using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [RoutePrefix("api/Inventory")]
    [Authorize]
    public class InventoryController : ApiController
    {
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("Inventories")]
        public List<InventoryModel> Get()
        {
            InventoryData inventoryData = new InventoryData();
            return inventoryData.GetInventory();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("InsertInventory")]
        public IHttpActionResult Post(InventoryModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            InventoryData inventoryData = new InventoryData();
            inventoryData.SaveInventoryRecord(item);
            return Ok();
        }

    }
}
