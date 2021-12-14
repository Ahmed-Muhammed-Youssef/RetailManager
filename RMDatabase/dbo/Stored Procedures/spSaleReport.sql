CREATE PROCEDURE [dbo].[spSaleReport]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT s.[SaleDate], s.[SubTotal], s.[Tax], s.[Total], u.FirstName, u.LastName, u.EmailAddress
	FROM dbo.Sales AS s
	INNER JOIN dbo.Users AS u ON s.CashierId = u.UserId;
END