using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<InventoryModel>>> Get()
        {
            return Ok(await inventoryData.GetInventory());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post(InventoryModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await inventoryData.SaveInventoryRecord(item);
            return CreatedAtAction(nameof(Post), item);
        }
    }
}
