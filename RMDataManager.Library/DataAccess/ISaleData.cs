using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public interface ISaleData
    {
        Task<List<SaleReportModel>> GetSaleReport();
        Task<int> SaveSale(List<SaleDetailModel> saleDetailModels, string cashierId);
    }
}