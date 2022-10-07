CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RentId] INT NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [Type] TINYINT NOT NULL DEFAULT 1, 
    [Description] NVARCHAR(1000) NULL, 
    [Amount] SMALLMONEY NOT NULL DEFAULT 0, 
    [CustomDivsion] BIT NOT NULL DEFAULT 0, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Expense_Rent] FOREIGN KEY ([RentId]) REFERENCES [Rent]([Id])
)
