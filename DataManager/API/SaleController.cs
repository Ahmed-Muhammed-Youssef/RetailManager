using DataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataManager.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly ISaleData saleData;

        public SaleController(ISaleData saleData)
        {
            this.saleData = saleData;
        }
        // POST api/Sales
        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public async Task<IActionResult> Post(IEnumerable<SaleModelReceived> salelModelsReceived)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<SaleDetailModel> saleDetailModels = new List<SaleDetailModel>();
            foreach (var item in salelModelsReceived)
            {
                SaleDetailModel saleModelDetail = new SaleDetailModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                saleDetailModels.Add(saleModelDetail);
            }
            await saleData.SaveSale(saleDetailModels, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return CreatedAtAction(nameof(Post), salelModelsReceived);
        }
        // GET api/Sales/SalesReport
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("SalesReport")]
        public async Task<ActionResult<List<SaleReportModel>>> GetSaleReport()
        {
            return Ok(await saleData.GetSaleReport());
        }
    }
}
