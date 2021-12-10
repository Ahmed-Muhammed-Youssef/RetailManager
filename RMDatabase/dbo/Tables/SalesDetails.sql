CREATE TABLE [dbo].[SalesDetails]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[SaleId] INT NOT NULL, 
	[ProductId] INT NOT NULL, 
	[Quantity] INT NOT NULL DEFAULT 1,
	[PurchasePrice] MONEY NOT NULL, 
	[Tax] MONEY NOT NULL DEFAULT 0, 
	CONSTRAINT [FK_SalesDetails_ToSales] FOREIGN KEY ([SaleId]) REFERENCES [Sales]([Id]), 
	CONSTRAINT [FK_SalesDetails_ToProducts] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]) 
)
