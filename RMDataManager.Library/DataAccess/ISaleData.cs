using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public interface ISaleData
    {
        List<SaleReportModel> GetSaleReport();
        void SaveSale(List<SaleDetailModel> saleDetailModels, string cashierId);
    }
}