CREATE PROCEDURE [dbo].[spProductsGetById]
	@id int
AS
BEGIN
	set nocount on;
	SELECT Id, ProductName, RetailPrice, TaxPercentage, QuantityInStock, CreateDate, LastModified
	FROM  dbo.Products
	WHERE [Id]  = @id
END