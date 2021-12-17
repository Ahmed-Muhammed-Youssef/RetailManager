using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {
        // GET: Products/

        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<ProductModel>> GetAll()
        {
            ProductData productData = new ProductData();
            return Ok(productData.GetAllProducts());
        }
    }
}
