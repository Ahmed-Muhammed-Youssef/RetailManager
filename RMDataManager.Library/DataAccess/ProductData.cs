using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData
    {
        private SqlDataAccess sqlDataAccess;
        public ProductData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);
        }
        public List<ProductModel> GetAllProducts()
        {
            return sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetAll", new { }, "RMData");
        }
        public ProductModel GetProductById(int id)
        {
            return sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetById", new { Id = id }, "RMData").FirstOrDefault();
        }
    }
}
