using DataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace DataManager.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public SaleController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // POST api/Sales
        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public IActionResult Post(IEnumerable<SaleModelReceived> salelModelsReceived)
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

            SaleData saleData = new SaleData(configuration);


            saleData.SaveSale(saleDetailModels, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return CreatedAtAction(nameof(Post), salelModelsReceived);
        }
        // GET api/Sales/SalesReport
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("SalesReport")]
        public ActionResult<List<SaleReportModel>> GetSaleReport()
        {
            SaleData sale = new SaleData(configuration);
            return Ok(sale.GetSaleReport());
        }
    }
}
