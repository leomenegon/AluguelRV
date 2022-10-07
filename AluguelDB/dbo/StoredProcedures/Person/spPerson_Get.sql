CREATE PROCEDURE [dbo].[spPerson_Get] @Id INT, @IncludeDeleted BIT = 0
AS
BEGIN
	IF (@IncludeDeleted = 0)
	BEGIN
		SELECT [Id], [Name], [Deleted]
		FROM dbo.Person
		WHERE [Id] = @Id AND [Deleted] = 0
	END
	ELSE
	BEGIN
		SELECT [Id], [Name], [Deleted]
		FROM dbo.Person
		WHERE [Id] = @Id
	END
END