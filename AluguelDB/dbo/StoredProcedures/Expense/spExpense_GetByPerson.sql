CREATE PROCEDURE [dbo].[spExpense_GetByPerson]
	@RentId INT,
	@PersonId INT
AS
BEGIN
	DECLARE @ExpenseIdList TABLE ([Id] INT, [CustomDivsion] BIT, [General] BIT)
	DECLARE @ExpenseId INT
	DECLARE @RentPersonCount INT
	DECLARE @PersonCount INT
	DECLARE @Result TABLE ([Id] INT, [Name] NVARCHAR(100), [Type] TINYINT, [IndividualAmount] SMALLMONEY, [Amount] SMALLMONEY)
	DECLARE @IsCustom BIT
	DECLARE @IsGeneral BIT
	DECLARE @CustomAmount SMALLMONEY

	SELECT @RentPersonCount = COUNT([PersonId])
	FROM dbo.[RentRoomPerson]
	WHERE [RentId] = @RentId

	INSERT INTO @ExpenseIdList
	SELECT e.[Id], e.[CustomDivision], 0 -- < General = 0
	FROM dbo.[ExpensePerson] ep
	INNER JOIN dbo.[Expense] e ON ep.[ExpenseId] = e.[Id]
	WHERE ep.[PersonId] = @PersonId
	AND e.[RentId] = @RentId
	AND e.[Deleted] = 0

	INSERT INTO @ExpenseIdList
	SELECT [Id], 0, [General]
	FROM dbo.[Expense]
	WHERE [RentId] = @RentId
	AND [General] = 1
	AND [Deleted] = 0

	WHILE (1 = 1)
	BEGIN
		SET @ExpenseId = NULL
		SET @IsCustom = NULL
		SET @IsGeneral = NULL

		SELECT TOP (1)
		@ExpenseId = [Id],
		@IsCustom = [CustomDivsion],
		@IsGeneral = [General]
		FROM @ExpenseIdList

		IF @ExpenseId IS NULL
			BREAK

		IF @IsCustom != 1
		BEGIN
			IF @IsGeneral = 0 -- Gasto divido igualmente entre participantes
			BEGIN
				SELECT @PersonCount = COUNT([PersonId])
				FROM dbo.[ExpensePerson]
				WHERE [ExpenseId] = @ExpenseId

				INSERT @Result
				SELECT [Id], [Name], [Type], [Amount] / @PersonCount, [Amount]
				FROM dbo.[Expense]
				WHERE [Id] = @ExpenseId
				AND [Deleted] = 0
			END
			ELSE -- Gasto geral dividido entre todos os moradores
			BEGIN
				INSERT @Result
				SELECT [Id], [Name], [Type], [Amount] / @RentPersonCount, [Amount]
				FROM dbo.[Expense]
				WHERE [Id] = @ExpenseId
				AND [Deleted] = 0
			END
		END

		ELSE -- gasto com divisão personalizada entre participantes
		BEGIN
			SELECT @CustomAmount = [CustomAmount]
			FROM dbo.[ExpensePerson]
			WHERE [ExpenseId] = @ExpenseId
			AND [PersonId] = @PersonId

			INSERT @Result
			SELECT [Id], [Name], [Type], @CustomAmount, [Amount]
			FROM dbo.[Expense]
			WHERE [Id] = @ExpenseId
			AND [Deleted] = 0
		END

		DELETE TOP (1)
		FROM @ExpenseIdList
	END

	SELECT *
	FROM @Result
END