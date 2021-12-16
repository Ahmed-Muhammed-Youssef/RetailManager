using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize(Roles = "Cashier")]
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
