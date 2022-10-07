CREATE PROCEDURE [dbo].[spRent_GetAll] @IncludeDeleted BIT = 0
AS
BEGIN
	IF (@IncludeDeleted = 0)
	BEGIN
		SELECT [Id], [Name], [Date], [Amount], [Percentage], [Closed], [Deleted]
		FROM dbo.Rent
		WHERE [Deleted] = 0
	END
	ELSE
	BEGIN
		SELECT [Id], [Name], [Date], [Amount], [Percentage], [Closed], [Deleted]
		FROM dbo.Rent
	END
END