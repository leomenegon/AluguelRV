CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NOT NULL UNIQUE, 
    [Password] BINARY(64) NOT NULL, 
    [Salt] BINARY(128) NOT NULL, 
    [PersonId] INT NOT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_User_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
