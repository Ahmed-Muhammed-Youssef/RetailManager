using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public ProductData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetAll", new { }, "RMData");
        }
        public async Task<ProductModel> GetProductById(int id)
        {
            var query = await sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetById", new { Id = id }, "RMData");
            return query.FirstOrDefault();
        }
    }
}
