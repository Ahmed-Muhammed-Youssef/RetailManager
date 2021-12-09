using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Products")]
    public class ProductController : ApiController
    {
        // GET: Products/

        [HttpGet]
        public List<ProductModel> GetAll()
        {
            ProductData productData = new ProductData();
            return productData.GetAllProducts();
        }
    }
}
