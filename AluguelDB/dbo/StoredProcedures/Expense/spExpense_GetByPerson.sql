CREATE PROCEDURE [dbo].[spExpense_GetByPerson] @RentId INT, @PersonId INT
AS
BEGIN
	DECLARE @ExpenseIdList TABLE ([Id] INT, [CustomDivsion] BIT)
	DECLARE @ExpenseId INT
	DECLARE @PersonCount INT
	DECLARE @Result TABLE ([Id] INT, [Name] NVARCHAR(100), [Type] TINYINT, [IndividualAmount] SMALLMONEY, [Amount] SMALLMONEY)
	DECLARE @IsCustom BIT
	DECLARE @CustomAmount SMALLMONEY

	INSERT INTO @ExpenseIdList
	SELECT e.[Id], e.[CustomDivision]
	FROM dbo.ExpensePerson ep
	INNER JOIN dbo.Expense e ON ep.ExpenseId = e.[Id]
	WHERE ep.PersonId = @PersonId
		AND e.[RentId] = @RentId
		AND e.[Deleted] = 0

	WHILE (1 = 1)
	BEGIN
		SET @ExpenseId = NULL
		SET @IsCustom = NULL

		SELECT TOP (1) @ExpenseId = [Id]
		FROM @ExpenseIdList

		SELECT TOP (1) @IsCustom = [CustomDivsion]
		FROM @ExpenseIdList

		IF @ExpenseId IS NULL
			BREAK

		IF @IsCustom = 0
		BEGIN

			SELECT @PersonCount = COUNT([PersonId])
			FROM dbo.[ExpensePerson]
			WHERE [ExpenseId] = @ExpenseId

			INSERT @Result
			SELECT [Id], [Name], [Type], [Amount] / @PersonCount, [Amount]
			FROM dbo.Expense
			WHERE [Id] = @ExpenseId
				AND [Deleted] = 0

		END

		ELSE
		BEGIN

			SELECT @CustomAmount = [CustomAmount]
			FROM dbo.ExpensePerson
			WHERE [ExpenseId] = @ExpenseId
			AND [PersonId] = @PersonId

			INSERT @Result
			SELECT [Id], [Name], [Type], @CustomAmount, [Amount]
			FROM dbo.Expense
			WHERE [Id] = @ExpenseId
				AND [Deleted] = 0
		END

		DELETE TOP (1)
		FROM @ExpenseIdList
	END

	SELECT *
	FROM @Result
END