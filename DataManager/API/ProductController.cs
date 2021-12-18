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
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: Products/

        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<ProductModel>> GetAll()
        {
            ProductData productData = new ProductData(configuration);
            return Ok(productData.GetAllProducts());
        }
    }
}
