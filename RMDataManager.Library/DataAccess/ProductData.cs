using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public ProductData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
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
