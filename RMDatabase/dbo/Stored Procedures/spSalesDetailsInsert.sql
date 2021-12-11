CREATE PROCEDURE [dbo].[spSalesDetailsInsert]
	@SaleId INT,
	@ProductId INT,
	@Quantity INT,
	@PurchasePrice MONEY,
	@Tax MONEY 
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[SalesDetails] (SaleId, ProductId, Quantity, PurchasePrice, Tax)
		VALUES(@SaleId, @ProductId, @Quantity,@PurchasePrice, @Tax);
END	
