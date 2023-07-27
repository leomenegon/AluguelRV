CREATE TABLE [dbo].[RentPayment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL, 
    [RentId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Amount] SMALLMONEY NOT NULL, 
    [ReceiptPath] NVARCHAR(200) NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [Timestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT [FK_RentPayment_Rent] FOREIGN KEY ([RentId]) REFERENCES [Rent]([Id]),
    CONSTRAINT [FK_RentPayment_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
    CONSTRAINT [FK_RentPayment_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)