﻿using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMDataManager.Library.DataAccess
{
    public class SaleData : ISaleData
    {
        private readonly ISqlDataAccess sqlDataAccess;
        private readonly IProductData productData;

        public SaleData(ISqlDataAccess sqlDataAccess, IProductData productData)
        {
            this.sqlDataAccess = sqlDataAccess;
            this.productData = productData;
        }
        public void SaveSale(List<SaleDetailModel> saleDetailModels, string cashierId)
        {
            //@TODO: needs modifications
            foreach (var item in saleDetailModels)
            {
                var productInfo = productData.GetProductById(item.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product {item.ProductId} cannot be found");
                }

                item.PurchasePrice = productInfo.RetailPrice * item.Quantity;
                item.Tax = (item.PurchasePrice * ((decimal)productInfo.TaxPercentage / 100));
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

            try
            {
                sqlDataAccess.OpenTransaction("RMData");

                sqlDataAccess.SaveDataInTransaction("dbo.spSalesInsert", new { saleModel.Id, saleModel.Total, saleModel.SubTotal, saleModel.SaleDate, saleModel.CashierId, saleModel.Tax });

                //Get The ID From the sale model
                saleModel.Id = sqlDataAccess.LoadDataInTransaction<int>("dbo.spSalesLookup",
                    new { saleModel.CashierId, saleModel.SaleDate, saleModel.SubTotal, saleModel.Tax, saleModel.Total })
                    .FirstOrDefault();

                //save  the  sale detail models
                foreach (var item in saleDetailModels)
                {
                    item.SaleId = saleModel.Id;
                    sqlDataAccess.SaveDataInTransaction("dbo.spSalesDetailsInsert",
                        new { item.SaleId, item.ProductId, item.Quantity, item.PurchasePrice, item.Tax });
                }
            }
            catch
            {
                sqlDataAccess.RollbackTransasction();
                throw;
            }

            sqlDataAccess.Dispose();
        }
        public List<SaleReportModel> GetSaleReport()
        {
            return sqlDataAccess.LoadData<SaleReportModel>("dbo.spSaleReport", new { }, "RMData");
        }
    }
}
