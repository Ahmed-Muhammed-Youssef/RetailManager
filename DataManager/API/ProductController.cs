using Microsoft.AspNetCore.Authorization;
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
        private readonly IProductData productData;

        public ProductController(IProductData productData)
        {
            this.productData = productData;
        }
        // GET: Products/

        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {

            return Ok(await productData.GetAllProducts());
        }
    }
}
