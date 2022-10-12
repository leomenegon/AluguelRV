CREATE PROCEDURE [dbo].[spExpense_GetAll]
	@IncludeDeleted bit = 0
AS
BEGIN
	IF (@IncludeDeleted = 0)
	BEGIN
		SELECT [Id], [RentId], [Name], [Type], [Description], [Amount], [CustomDivsion], [Deleted]
		FROM dbo.Expense
		WHERE [Deleted] = 0	
	END
	ELSE
	BEGIN
		SELECT [Id], [RentId], [Name], [Type], [Description], [Amount], [CustomDivsion], [Deleted]
		FROM dbo.Expense
	END
END
