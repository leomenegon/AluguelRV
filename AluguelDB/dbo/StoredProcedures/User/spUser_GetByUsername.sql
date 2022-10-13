CREATE PROCEDURE [dbo].[spUser_GetByUsername]
	@Username nvarchar(50)
AS
BEGIN

SELECT [Id], [Username], [Password], [Salt], [PersonId], [Deleted]
FROM [dbo].[User]
WHERE [Username] = @Username
AND [Deleted] = 0

END