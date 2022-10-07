CREATE PROCEDURE [dbo].[spPerson_GetAll] @IncludeDeleted BIT = 0
AS
BEGIN
	IF (@IncludeDeleted = 0)
	BEGIN
		SELECT [Id], [Name], [Deleted]
		FROM dbo.Person
		WHERE [Deleted] = 0
	END
	ELSE
	BEGIN
		SELECT [Id], [Name], [Deleted]
		FROM dbo.Person
	END
END