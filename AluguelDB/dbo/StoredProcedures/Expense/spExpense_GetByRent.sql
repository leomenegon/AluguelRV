CREATE PROCEDURE [dbo].[spExpense_GetByRent] @RentId INT, @IncludeDeleted BIT = 0
AS
BEGIN
	IF (@IncludeDeleted = 0)
	BEGIN
		SELECT [Id], [RentId], [Name], [Description], [Amount]
		FROM dbo.Expense
		WHERE [RentId] = @RentId AND [Deleted] = 0
	END
	ELSE
	BEGIN
		SELECT [Id], [RentId], [Name], [Description], [Amount]
		FROM dbo.Expense
		WHERE [RentId] = @RentId
	END
END