using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetAllProducts()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            return sqlDataAccess.LoadData<ProductModel>("dbo.spProductsGetAll", new { }, "RMData");
        }
    }
}
