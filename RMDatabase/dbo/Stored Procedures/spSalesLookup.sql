CREATE PROCEDURE [dbo].[spSalesLookup]
	@CashierId NVARCHAR(128),
	@SaleDate DATETIME2,
	@SubTotal MONEY,
	@Tax MONEY,
	@Total MONEy
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id 
	FROM [dbo].[Sales]
	WHERE CashierId = @CashierId AND SaleDate = @SaleDate
			AND SubTotal = @SubTotal AND Tax = @Tax AND Total = @Total;
		
END
