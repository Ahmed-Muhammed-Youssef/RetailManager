CREATE PROCEDURE [dbo].[spProductsGetAll]
AS
BEGIN
	set nocount on;
	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock
	FROM dbo.Products
	ORDER BY ProductName;
END