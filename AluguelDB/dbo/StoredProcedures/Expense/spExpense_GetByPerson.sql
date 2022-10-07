CREATE PROCEDURE [dbo].[spExpense_GetByPerson] @RentId INT, @PersonId INT
AS
BEGIN
	DECLARE @ExpenseIdList TABLE ([Id] INT)
	DECLARE @ExpenseId INT
	DECLARE @PersonCount INT
	DECLARE @Result TABLE ([Id] INT, [Name] NVARCHAR(100), [IndividualAmount] SMALLMONEY)

	INSERT INTO @ExpenseIdList
	SELECT e.[Id]
	FROM dbo.ExpensePerson ep
	INNER JOIN dbo.Expense e ON ep.ExpenseId = e.[Id]
	WHERE ep.PersonId = @PersonId
		AND e.[RentId] = @RentId
		AND e.[Deleted] = 0

	WHILE (1 = 1)
	BEGIN
		SET @ExpenseId = NULL

		SELECT TOP (1) @ExpenseId = [Id]
		FROM @ExpenseIdList

		IF @ExpenseId IS NULL
			BREAK

		SELECT @PersonCount = COUNT([PersonId])
		FROM dbo.[ExpensePerson]
		WHERE [ExpenseId] = @ExpenseId

		INSERT @Result
		SELECT [Id], [Name], [Amount] / @PersonCount
		FROM dbo.Expense
		WHERE [Id] = @ExpenseId
			AND [Deleted] = 0

		DELETE TOP (1)
		FROM @ExpenseIdList
	END

	SELECT *
	FROM @Result
END