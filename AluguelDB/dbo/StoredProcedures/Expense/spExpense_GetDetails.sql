CREATE PROCEDURE [dbo].[spExpense_GetDetails]
	@Id int,
	@PersonId int
AS
BEGIN
	DECLARE @PersonCount INT
	DECLARE @Result TABLE ([Id] INT, [RentId] INT, [Name] NVARCHAR(100), [Type] TINYINT, [Description] NVARCHAR(1000), [IndividualAmount] SMALLMONEY, [Amount] SMALLMONEY)
	DECLARE @IsCustom BIT
	DECLARE @CustomAmount SMALLMONEY

	SELECT TOP (1) @IsCustom = [CustomDivision]
    FROM dbo.Expense
	WHERE [Id] = @Id
	AND [Deleted] = 0

	IF @IsCustom = 0
	BEGIN

		SELECT @PersonCount = COUNT([PersonId])
		FROM dbo.[ExpensePerson]
		WHERE [ExpenseId] = @Id

		INSERT @Result
		SELECT [Id], [RentId], [Name], [Type], [Description], [Amount] / @PersonCount, [Amount]
		FROM dbo.Expense
		WHERE [Id] = @Id
		AND [Deleted] = 0

	END

	ELSE
	BEGIN

		SELECT @CustomAmount = [CustomAmount]
		FROM dbo.ExpensePerson
		WHERE [ExpenseId] = @Id
		AND [PersonId] = @PersonId

		INSERT @Result
		SELECT [Id], [RentId], [Name], [Type], [Description], @CustomAmount, [Amount]
		FROM dbo.Expense
		WHERE [Id] = @Id
		AND [Deleted] = 0
	
	END

	SELECT *
	FROM @Result
END
