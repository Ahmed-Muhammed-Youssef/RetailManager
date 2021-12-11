using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(List<SaleDetailModel> saleDetailModels, string cashierId)
        {
            //@TODO: needs modifications
            ProductData product = new ProductData();

            foreach (var item in saleDetailModels)
            {
                var productInfo = product.GetProductById(item.ProductId);

                if(productInfo == null)
                {
                    throw new Exception($"The product {item.ProductId} cannot be found");
                }

                item.PurchasePrice = productInfo.RetailPrice * item.Quantity;
                item.Tax = (item.PurchasePrice * ((decimal)productInfo.TaxPercentage/100));
            }

            //create sale  model
            SaleModel saleModel = new SaleModel
            {
                SubTotal = saleDetailModels.Sum(x => x.PurchasePrice),
                Tax = saleDetailModels.Sum(x => x.Tax),
                CashierId = cashierId
              
            };
            saleModel.Total = saleModel.SubTotal + saleModel.Tax;

            //save sale  model

            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            sqlDataAccess.SaveData("dbo.spSalesInsert", new { saleModel.Total, saleModel.SubTotal, saleModel.SaleDate, saleModel.CashierId, saleModel.Tax }, "RMData");

            //Get The ID From the sale model
            saleModel.Id = sqlDataAccess.LoadData<int>("dbo.spSalesLookup",
                new {saleModel.CashierId, saleModel.SaleDate, saleModel.SubTotal, saleModel.Tax, saleModel.Total }, "RMData")
                .FirstOrDefault();
            //fill the list of  sale models
            foreach (var item in saleDetailModels)
            {
                item.SaleId = saleModel.Id;
            }

            //save  the  sale detail models
            foreach (var item in saleDetailModels)
            {
                sqlDataAccess.SaveData("dbo.spSalesDetailsInsert", 
                    new { item.SaleId, item.ProductId, item.Quantity, item.PurchasePrice, item.Tax }, "RMData");
            }

        }
    }
}
