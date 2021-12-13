CREATE PROCEDURE [dbo].[spSalesInsert]
	@Id INT OUTPUT,
	@CashierId nvarchar(128),
	@SaleDate DATETIME2,
	@SubTotal MONEY,
	@Tax MONEY,
	@Total MONEY
AS
	
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Sales(CashierId, SaleDate,  SubTotal, Tax,  Total)
		VALUES (@CashierId, @SaleDate,  @SubTotal, @Tax,  @Total);
	SELECT @Id = SCOPE_IDENTITY();
END
