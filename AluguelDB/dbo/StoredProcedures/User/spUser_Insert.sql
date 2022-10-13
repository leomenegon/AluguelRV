CREATE PROCEDURE [dbo].[spUser_Insert]
	@Username nvarchar(50),
	@Password binary(64),
	@Salt binary(128),
	@Name nvarchar(100),
	@Resident bit,
	@DefaultRoom int
AS
BEGIN

INSERT INTO dbo.Person
([Name], [Resident], [DefaultRoom])
VALUES
(@Name, @Resident, @DefaultRoom)

DECLARE @PersonId INT;
SELECT @PersonId = SCOPE_IDENTITY();

INSERT INTO [dbo].[User]
([Username], [Password], [Salt], [PersonId])
VALUES
(@Username, @Password, @Salt, @PersonId)

END