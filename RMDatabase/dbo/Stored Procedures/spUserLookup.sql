CREATE PROCEDURE [dbo].[spUserLookup]
	@id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UserId, FirstName, LastName, EmailAddress,  CreatedDate
	FROM dbo.Users
	WHERE UserId = @id;
END