﻿CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RentId] INT NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [Type] TINYINT NOT NULL DEFAULT 1, 
    [Description] NVARCHAR(1000) NULL, 
    [Amount] SMALLMONEY NOT NULL DEFAULT 0, 
    [General] BIT NOT NULL DEFAULT 1,
    [CustomDivision] BIT NOT NULL DEFAULT 0,
    [UserId] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [Deleted] BIT NOT NULL DEFAULT 0,
    [Timestamp] DATETIME2 NULL DEFAULT GETUTCDATE(),
    CONSTRAINT [FK_Expense_Rent] FOREIGN KEY ([RentId]) REFERENCES [Rent]([Id]),
    CONSTRAINT [FK_Expense_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)