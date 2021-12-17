using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace DataManager.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<InventoryModel>> Get()
        {
            InventoryData inventoryData = new InventoryData();
            return Ok(inventoryData.GetInventory());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("add")]
        public IActionResult Post(InventoryModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            InventoryData inventoryData = new InventoryData();
            inventoryData.SaveInventoryRecord(item);
            return CreatedAtAction(nameof(Post), item);
        }
    }
}
