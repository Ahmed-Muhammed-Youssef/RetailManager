CREATE TABLE [dbo].[Users]
(
	[UserId] NVARCHAR(128) PRIMARY KEY NOT NULL, 
	[FirstName] NVARCHAR(50) NOT NULL, 
	[LastName] NVARCHAR(50) NOT NULL, 
	[EmailAddress] NVARCHAR(256) NOT NULL, 
	[CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
