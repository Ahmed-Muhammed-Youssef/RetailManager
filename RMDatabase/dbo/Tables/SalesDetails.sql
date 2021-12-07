CREATE TABLE [dbo].[SalesDetails]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[SaleId] INT NOT NULL, 
	[ProductId] NCHAR(10) NOT NULL, 
	[Quantity] INT NOT NULL DEFAULT 1,
	[PurchasePrice] MONEY NOT NULL, 
	[Tax] MONEY NOT NULL DEFAULT 0, 
)
