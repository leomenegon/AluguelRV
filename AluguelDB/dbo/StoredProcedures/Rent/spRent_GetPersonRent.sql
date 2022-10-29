CREATE PROCEDURE [dbo].[spRent_GetPersonRent]
	@PersonId int,
	@RentId int
AS
BEGIN
	DECLARE @Data TABLE (
		[Id] INT
		,[Name] NVARCHAR(100)
		,[Type] INT
		,IndividualAmount SMALLMONEY
		,Amount SMALLMONEY
		)
	DECLARE @Room TABLE (
		[RoomId] INT
		,[Name] NVARCHAR(100)
		,RoomAmount SMALLMONEY
		)
	DECLARE @PersonAmount SMALLMONEY
	DECLARE @PersonCount INT

	INSERT INTO @Data
	EXEC dbo.spExpense_GetByPerson 1
		,1

	INSERT INTO @Room
	EXEC dbo.spRent_GetRoomAmountByPerson 1
		,1

	SELECT @PersonAmount = SUM(IndividualAmount)
	FROM @Data

	SELECT @PersonCount = COUNT(PersonId)
	FROM dbo.RentRoomPerson
	WHERE RentId = 1

	SELECT [Id]
		,[Name]
		,[Month]
		,[Year]
		,[Amount]
		,[Percentage]
		,[Closed]
		,[Amount] * [Percentage] / 100 / @PersonCount + @PersonAmount IndividualRent
	FROM dbo.Rent
	WHERE [Id] = 1
END