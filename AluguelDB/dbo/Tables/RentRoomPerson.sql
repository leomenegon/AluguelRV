CREATE TABLE [dbo].[RentRoomPerson]
(
	[RentId] INT NOT NULL, 
    [RoomId] INT NOT NULL, 
    [PersonId] INT NOT NULL, 
    CONSTRAINT [FK_RentRoomPerson_Rent] FOREIGN KEY ([RentId]) REFERENCES [Rent]([Id]),
    CONSTRAINT [FK_RentRoomPerson_Room] FOREIGN KEY ([RoomId]) REFERENCES [Room]([Id]),
    CONSTRAINT [FK_RentRoomPerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
