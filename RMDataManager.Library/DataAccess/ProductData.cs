using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetAllProducts()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            return sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetAll", new { }, "RMData");
        }
        public ProductModel GetProductById(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            return sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetById", new { Id = id }, "RMData").FirstOrDefault();
        }
    }
}
