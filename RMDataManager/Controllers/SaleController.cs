using Microsoft.AspNet.Identity;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using RMDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Sales")]
    public class SaleController : ApiController
    {
        // POST api/Sales
        [HttpPost]
        public IHttpActionResult Post(IEnumerable<SaleModelReceived> salelModelsReceived)
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
            
            SaleData saleData = new SaleData();

            
            saleData.SaveSale(saleDetailModels, RequestContext.Principal.Identity.GetUserId());
            return Ok();
        }
        // GET api/Sales/SalesReport
        [HttpGet]
        [Route("SalesReport")]
        public List<SaleReportModel> GetSaleReport()
        {
            SaleData sale = new SaleData();
            return sale.GetSaleReport();
        }
    }
}
