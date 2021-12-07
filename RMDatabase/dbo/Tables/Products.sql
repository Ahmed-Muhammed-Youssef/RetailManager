CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ProductName] NVARCHAR(100) NOT NULL, 
	[Description] NVARCHAR(600) NOT NULL, 
	[RetailPrice] NCHAR(10) NOT NULL,
	[CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
	[LastModified] DATETIME2 NOT NULL DEFAULT getutcdate()
)
