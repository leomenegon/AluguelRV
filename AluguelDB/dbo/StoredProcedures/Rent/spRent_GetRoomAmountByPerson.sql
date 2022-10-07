CREATE PROCEDURE [dbo].[spRent_GetRoomAmountByPerson]
	@RentId int,
	@PersonId int
AS
BEGIN

	DECLARE @RoomMemberCount INT
	DECLARE @RoomId INT
	DECLARE @RentAmount INT

	SELECT @RentAmount = [Amount]
	FROM dbo.Rent
	WHERE [Id] = @RentId

	SELECT TOP(1) @RoomId = [RoomId] 
	FROM dbo.RentRoomPerson 
	WHERE [PersonId] = @PersonId 
	AND [RentId] = @RentId

	SELECT @RoomMemberCount = COUNT([PersonId])
	FROM dbo.[RentRoomPerson]
	WHERE [RentId] = @RentId
	AND [RoomId] = @RoomId

	SELECT [Id] RoomId, [Name],
	@RentAmount * [Percentage] / @RoomMemberCount / 100 RoomAmount
	FROM dbo.Room
	WHERE [Id] = @RoomId

END
