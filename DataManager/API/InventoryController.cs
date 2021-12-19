using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IInventoryData inventoryData;
        public InventoryController(IInventoryData inventoryData)
        {
            this.inventoryData = inventoryData;
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<InventoryModel>> Get()
        {
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
            inventoryData.SaveInventoryRecord(item);
            return CreatedAtAction(nameof(Post), item);
        }
    }
}
