using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
    }
}