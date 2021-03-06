CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ProductName] NVARCHAR(100) NOT NULL, 
	[Description] NVARCHAR(600) NOT NULL, 
	[RetailPrice] MONEY NOT NULL,
	[QuantityInStock] INT NOT NULL DEFAULT 1,
	[CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
	[LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(), 
	[TaxPercentage] FLOAT NOT NULL DEFAULT 0
)
