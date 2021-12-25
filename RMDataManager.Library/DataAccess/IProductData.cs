using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
    }
}